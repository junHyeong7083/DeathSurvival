using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnEffect : MonoBehaviour
{ 
    public Text StartTxt;
    public Text ExitTxt;
    Outline StartBtnOutline;
    Outline ExitBtnOutline;
    private void Start()
    {
        StartBtnOutline = StartTxt.GetComponent<Outline>();
        ExitBtnOutline = ExitTxt.GetComponent<Outline>();
    }
    public void OnMouseStartBtn()
    {
        StartBtnOutline.effectColor = Color.red;
    }

    public void OutMouseStartBtn()
    {
        StartBtnOutline.effectColor = Color.white;
    }

    public void OnMouseExitBtn()
    {
        ExitBtnOutline.effectColor = Color.black;
    }

    public void OutMouseExitBtn()
    {
        ExitBtnOutline.effectColor = Color.white;
    }
}
