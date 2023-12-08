using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text[] timerText; // 0 - second / 1 -minute
    float Timer;

    public static bool isClear = false;
    void Start()
    {
        isClear = false;
        Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if((Timer % 60) < 10)
            timerText[0].text = "0" + ((int)Timer % 60).ToString();
        else
            timerText[0].text = ((int)Timer % 60).ToString();

        if((Timer / 60 % 60) < 10)
            timerText[1].text ="0" + ((int)Timer / 60 % 60).ToString();
        else
            timerText[1].text = ((int)Timer / 60 % 60).ToString();



        if(((Timer % 60) >= 30 ))
        {
            Debug.Log("!@#3");
            isClear = true;
        }
    }
}
