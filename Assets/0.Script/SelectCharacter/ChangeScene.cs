using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public TransitionSettings transition;
    public float loadDelay;
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

    public void LoadScene(int _sceneName)
    {
        TransitionManager.Instance().Transition(_sceneName, transition, loadDelay);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void GoSelectScene()
    {
        // SceneManager.LoadScene(1);
        //SelectCharacter
        LoadScene(2);

    }

    public void GoTitleScene()
    {
        //SceneManager.LoadScene(0);
        LoadScene(1);
    }

    public void SelectSceneStart()
    {
        switch (SelectKeyboard.currentIndex)
        {
            case 0:
                Pixelate.toGame = true;
                //SceneManager.LoadScene(2);
                break;

            case 1:
                if (SelectKeyboard.canB)
                {
                    Pixelate.toGame = true;
                    // SceneManager.LoadScene(2);
                }
                break;

            case 2:
                if (SelectKeyboard.canC)
                {
                    Pixelate.toGame = true;
                  //  SceneManager.LoadScene(2);
                }
                break;

        }
    }

}
