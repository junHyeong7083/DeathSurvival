using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePanel : MonoBehaviour
{
    public GameObject[] ButtonEffect;

    public GameObject UIManager;
    ChangeScene changeScene;
    int currentIndex = 1;
    void Start()
    {
        changeScene = UIManager.GetComponent<ChangeScene>();
        currentIndex = 1;
    }

   
    public void OnRegameBtn()
    {
        currentIndex = 1;
        ButtonEffect[0].gameObject.SetActive(true);
        ButtonEffect[1].gameObject.SetActive(false);
    }

    public void OnExitBtn()
    {
        currentIndex = 0;
        ButtonEffect[1].gameObject.SetActive(true);
        ButtonEffect[0].gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentIndex == 0)
            {
                currentIndex = 1;
            }
            else
                currentIndex--;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentIndex == 1)
            {
                currentIndex = 0;
            }
            else
                currentIndex++;
        }

        switch(currentIndex)
        {
            case 1:
                ButtonEffect[0].gameObject.SetActive(true);
                ButtonEffect[1].gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    changeScene.GoTitleScene();
                }
                break;

            case 0:
                ButtonEffect[1].gameObject.SetActive(true);
                ButtonEffect[0].gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    changeScene.Quit();
                }
                break;
        }
    }
}
