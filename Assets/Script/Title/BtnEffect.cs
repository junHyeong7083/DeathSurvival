using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnEffect : MonoBehaviour
{ 
    public Text StartTxt;
    Outline StartBtnOutline;

    private void Start()
    {
        StartBtnOutline = StartTxt.GetComponent<Outline>();
    }
    public void OnMouseBtn()
    {
        StartBtnOutline.effectColor = Color.red;
    }

    public void OutMouseBtn()
    {
        StartBtnOutline.effectColor = Color.white;
    }
}
