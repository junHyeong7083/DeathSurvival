using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        else if (isfullScreen)
            Screen.SetResolution(640, 360, true);
    }

    public void TwoScreen()
    {
        currentScreenIndex = 1;
        if(!isfullScreen)
            Screen.SetResolution(960, 540, false);
        else if (isfullScreen)
            Screen.SetResolution(960, 540, true);
    }

    public void ThreeScreen()
    {
        currentScreenIndex = 2;
        if(!isfullScreen)
            Screen.SetResolution(1280, 720, false);
        else if(isfullScreen)
            Screen.SetResolution(1280, 720, true);
    }

    public void FullScreen()
    {
        if(!isfullScreen)
        {
            isfullScreen = true;
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
        //   SoundManager.Instance.PlaySound();
        //Screen.SetResolution(640, 360, false);
        if(SceneManager.GetActiveScene().name == "Title") // 타이틀씬에서 사운드재생
        {
            SoundManager.Instance.SetBGMSound(1, PlayerPrefs.GetFloat("masterSound") * PlayerPrefs.GetFloat("bgmSound"));
            SoundManager.Instance.PlaySound();
        }
    }
    void Update()
    {

    }
}
