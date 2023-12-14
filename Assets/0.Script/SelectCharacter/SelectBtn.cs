using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBtn : MonoBehaviour
{
    public Button[] buttons;
    Outline[] outlines;
    public GameObject showEffectPanel;
    public float effectTime;
    Vector3 originPos = new Vector3(870, 0, 0);
    private void Start()
    {
        for(int e =0; e < buttons.Length; e++)
        {
            outlines[e] = buttons[e].GetComponent<Outline>();
        }
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
        /*      SelectKeyboard.selectBtn = 1;
              selectKeyboard.buttonOutlines[0].effectColor = Color.green;
              selectKeyboard.buttonOutlines[1].effectColor = Color.white;

              selectKeyboard.buttonSelects[0].gameObject.SetActive(true);
              selectKeyboard.buttonSelects[1].gameObject.SetActive(false);*/

        outlines[0].effectColor = Color.green;
        outlines[1].effectColor = Color.white;


    }
    public void outupBtn()
    {
        SelectKeyboard.isMouseuse = false;
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.white;

    }
    public void ondownBtn()
    {
        //  SelectKeyboard.isMouseuse = true;
        /*     SelectKeyboard.selectBtn = 0;
             selectKeyboard.buttonOutlines[0].effectColor = Color.white;
             selectKeyboard.buttonOutlines[1].effectColor = Color.green;


             selectKeyboard.buttonSelects[0].gameObject.SetActive(false);
             selectKeyboard.buttonSelects[1].gameObject.SetActive(true);*/
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.green;
    }
    public void outdownBtn()
    {
        SelectKeyboard.isMouseuse = false;
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.white;
    }
}
