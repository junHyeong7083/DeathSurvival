using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button OptionBtn;
    public GameObject optionPanel;

   // public Text levelTxt;
    public static bool isPause;
    bool isClick = false;
    private void Start()
    {
        isClick = false;
        optionPanel.SetActive(false);
    }
    public void OnOption()
    {
        isPause = true;
        optionPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OutOption()
    {
        isPause = false;
        optionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        //levelTxt.text = "Level : " + DataManager.currentLevel.ToString();
        #region ESC Click
        if (!isClick)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = true; 
                optionPanel.SetActive(true);
                Time.timeScale = 0f;
                isClick = true;
            }

        }
        else if(isClick)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = false;
                optionPanel.SetActive(false);
                Time.timeScale = 1f;
                isClick = false;
            }
        }
        #endregion
    }
}
