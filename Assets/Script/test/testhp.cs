using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testhp : MonoBehaviour
{
    bool isBtnOn;

    private void Start()
    {
        isBtnOn = false;
    }
    public void InfinityHp()
    {
        isBtnOn = true;
    }

    private void Update()
    {
        if(isBtnOn)
        {
            PlayerHpBar.currentHp = 100f;
        }
    }
}
