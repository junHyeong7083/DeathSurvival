using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Test
    int currentScreenIndex = 0;
    bool isfullScreen = false;
    public void BasicScreen()
    {
        currentScreenIndex = 0;
        if(!isfullScreen)
           Screen.SetResolution(640, 360, false);
        if (isfullScreen)
            Screen.SetResolution(640, 360, true);
    }

    public void TwoScreen()
    {
        currentScreenIndex = 1;
        if(!isfullScreen)
            Screen.SetResolution(960, 540, false);
        if (isfullScreen)
            Screen.SetResolution(960, 540, true);
    }

    public void ThreeScreen()
    {
        currentScreenIndex = 2;
        if(!isfullScreen)
            Screen.SetResolution(1280, 720, false);
        if(isfullScreen)
            Screen.SetResolution(1280, 720, true);
    }

    public void FullScreen()
    {
        if(!isfullScreen)
        {
            isfullScreen = true;
            Debug.Log("!!");
            switch (currentScreenIndex)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    break;

                case 1:
                    Screen.SetResolution(960, 540, true);
                    break;

                case 2:
                    Screen.SetResolution(1280, 720, true);
                    break;
            }
        }
        else if(isfullScreen)
        {
            isfullScreen = false;
            Debug.Log("!!222");
            switch (currentScreenIndex)
            {
                case 0:
                    Screen.SetResolution(640, 360, false);
                    break;

                case 1:
                    Screen.SetResolution(960, 540, false);
                    break;

                case 2:
                    Screen.SetResolution(1280, 720, false);
                    break;
            }
        }

    }
    #endregion

    private void Start()
    {
        //Screen.SetResolution(640, 360, false);
    }
    void Update()
    {

    }
}
