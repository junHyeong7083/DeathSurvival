using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private void Start()
    {
        UIManager.isPause = false;
        Time.timeScale = 1f;
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoSelectScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoTitleScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SelectSceneStart()
    {
        switch (SelectKeyboard.currentIndex)
        {
            case 0:
                SceneManager.LoadScene(2);
                break;

            case 1:
                if(SelectKeyboard.canB)
                    SceneManager.LoadScene(2);
                break;

            case 2:
                if (SelectKeyboard.canC)
                    SceneManager.LoadScene(2);
                break;

        }
    }

}
