using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
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
}
