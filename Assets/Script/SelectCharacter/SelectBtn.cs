using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBtn : MonoBehaviour
{
    public void upBtn()
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

    public void downBtn()
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
}
