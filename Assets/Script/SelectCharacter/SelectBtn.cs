using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBtn : MonoBehaviour
{
    SelectKeyboard selectKeyboard;

    private void Start()
    {
        selectKeyboard = GetComponent<SelectKeyboard>();
    }

    public void rightBtn()
    {
        SelectKeyboard.currentIndex++;
        if (SelectKeyboard.currentIndex > 2)
        {
            SelectKeyboard.currentIndex = 0;
            SelectKeyboard.isClick = true;
        }
        else
        {
            SelectKeyboard.isClick = true;
        }
    }

    public void leftBtn()
    {
        SelectKeyboard.currentIndex--;
        if (SelectKeyboard.currentIndex < 0)
        {
            SelectKeyboard.currentIndex = 2;
            SelectKeyboard.isClick = true;
        }
        else
        {
            SelectKeyboard.isClick = true;
        }
    }

    public void onupBtn()
    {
      //  SelectKeyboard.isMouseuse = true;
        SelectKeyboard.selectBtn = 1;
        selectKeyboard.buttonOutlines[0].effectColor = Color.green;
        selectKeyboard.buttonOutlines[1].effectColor = Color.white;

        selectKeyboard.buttonSelects[0].gameObject.SetActive(true);
        selectKeyboard.buttonSelects[1].gameObject.SetActive(false);
    }
    public void outupBtn()
    {
        SelectKeyboard.isMouseuse = false;
    }
    public void ondownBtn()
    {
      //  SelectKeyboard.isMouseuse = true;
        SelectKeyboard.selectBtn = 0;
        selectKeyboard.buttonOutlines[0].effectColor = Color.white;
        selectKeyboard.buttonOutlines[1].effectColor = Color.green;


        selectKeyboard.buttonSelects[0].gameObject.SetActive(false);
        selectKeyboard.buttonSelects[1].gameObject.SetActive(true);
    }
    public void outdownBtn()
    {
        SelectKeyboard.isMouseuse = false;
    }
}
