using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonMaster : MonoBehaviour
{
    public TMPro.TextMeshProUGUI result;
    public float first = 0f;
    public float next = 0f;
    public int operation; 
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;
    public GameObject Button9;
    public GameObject Button0;
    public GameObject ButtonC;
    public GameObject ButtonNot;
    public GameObject ButtonBac;
    public GameObject ButtonDiv;
    public GameObject ButtonMul;
    public GameObject ButtonAdd;
    public GameObject ButtonSub;
    public GameObject ButtonEqu;
    public GameObject ButtonDot;

    public GameObject[] NumberList;
    public GameObject[] ActionList;

    void Start()
    {
        NumberList = new GameObject[10] {Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9};
        ActionList = new GameObject[4] {ButtonAdd, ButtonSub, ButtonMul, ButtonDiv};
        result.text = "0";
    }


    public void action(GameObject button)
    {
        first = float.Parse(result.text);
        int index = Array.IndexOf<GameObject>(ActionList, button);
        if (index <= 3)
        {
            operation = index;
        }
        else
        {
            throw new ArgumentException("Incorrect Button Usage.");
        }
        result.text = "";
    }

    public void digit(GameObject button)
    {
        int index = Array.IndexOf<GameObject>(NumberList, button);
        if (result.text == "")
        {
            result.text = Convert.ToString(index);
        }
        else
        {
            result.text = result.text + Convert.ToString(index);
        }
    } 

    public void equalsOperation()
    {
        float answer = 0f;
        next = float.Parse(result.text);

        if (operation == 0)
        {
            answer = first + next;
        }
        else if (operation == 1)
        {
            answer = first - next;
        }
        else if (operation == 2)
        {
            answer = first * next;
        }
        else
        {
            answer = first / next;
        }

        result.text = answer.ToString();
    }

    public void notOperation()
    {
        float hold = float.Parse(result.text) * -1;
        result.text = Convert.ToString(hold);
    }

    public void clearOperation()
    {
        result.text = "";
    }

    public void dotOperation()
    {
        result.text = result.text + ".";
    }

    public void backOperation()
    {
        if (result.text.Length > 0)
        {
            result.text = result.text.Remove(result.text.Length - 1);
        }
    }
    public void updateResult(string Text)
    {
        result.text = Text;
    }
}