using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button OptionBtn;
    public GameObject optionPanel;

    public static bool isPause;
    private void Start()
    {
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
}
