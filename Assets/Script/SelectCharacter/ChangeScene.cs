using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
   public void GoGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoSelectScene()
    {
        SceneManager.LoadScene(0);
    }
}