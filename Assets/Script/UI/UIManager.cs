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
    }

    public void OutOption()
    {
        isPause = false;
        optionPanel.SetActive(false);
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
                isClick = true;
            }

        }
        else if(isClick)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = false;
                optionPanel.SetActive(false);
                isClick = false;
            }
        }

        if(isPause) { Time.timeScale = 0f; }
        else if(!isPause){ Time.timeScale = 1f; }
        #endregion
    }
}
