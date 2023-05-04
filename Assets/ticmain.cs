using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ticmain : MonoBehaviour
{
    public GameObject btn, parent;
    public Text playerturn;
    GameObject[,] b;
    int cube = 3;
    int cnt;
    
    // Start is called before the first frame update
    void Start()
    {
        b = new GameObject[cube,cube];
        for (int i = 0; i < cube; i++)
        {
            for (int j = 0; j < cube; j++)
            {
                GameObject g = Instantiate(btn, parent.transform);
                b[i,j] = g;
                g.GetComponent<Button>().onClick.AddListener(() => getnum(g));
            }
        }
    }


    void getnum(GameObject a)
    {
        if (cnt % 2 == 0)
        {
            a.GetComponentInChildren<Text>().text = "X";
            a.GetComponentInChildren<Text>().color = Color.blue;
            a.GetComponent<Button>().interactable = false;
        }
        else
        {
            a.GetComponentInChildren<Text>().text = "O";
            a.GetComponentInChildren<Text>().color = Color.red;
            a.GetComponent<Button>().interactable = false;
        }
        cnt++;
        check();
    }
    // Update is called once per frame
    void Update()
    {
        if(cnt % 2 == 0)
        {
            playerturn.text = "Player X turn";
        }
        else
        {
            playerturn.text = "Player O turn";
        }
    }
    int tmpx, tmpo;
    void check()
    {
        //Horizontal
        for (int i = 0; i < cube; i++)
        {
            for (int j = 0 ; j < cube; j++)
            {
                if(b[i, j].GetComponentInChildren<Text>().text == "X")
                {
                    tmpx++;
                }
                if(b[i,j].GetComponentInChildren<Text>().text == "O")
                {
                    tmpo++;
                }
            }
            win(tmpx, tmpo);
        }
        //verical
        for (int i = 0; i < cube; i++)
        {
            for (int j = 0; j < cube; j++)
            {
                if (b[j, i].GetComponentInChildren<Text>().text == "X")
                {
                    tmpx++;
                }
                if (b[j, i].GetComponentInChildren<Text>().text == "O")
                {
                    tmpo++;
                }
            }
            win(tmpx, tmpo);
        }
        //diagonal
        //left to right
        for (int i = 0; i < cube; i++)
        {

            if (b[i, i].GetComponentInChildren<Text>().text == "X")
            {
                tmpx++;
            }
            if (b[i, i].GetComponentInChildren<Text>().text == "O")
            {
                tmpo++;
            }
        }
        win(tmpx, tmpo);
        //right to left
        int c1 = cube - 1;
        for (int i = 0; i < cube; i++)
        {

            if (b[i, (c1 - i)].GetComponentInChildren<Text>().text == "X")
            {
                tmpx++;
            }
            if (b[i, (c1 - i)].GetComponentInChildren<Text>().text == "O")
            {
                tmpo++;
            }
        }
        win(tmpx, tmpo);
    }

    void win(int z,int y)
    {
        if(z == cube)
        {
            print("Player X is winner");
        }
        if(y == cube)
        {
            print("player O is winnnr");
        }
        tmpx = 0;
        tmpo = 0;
    }
}
