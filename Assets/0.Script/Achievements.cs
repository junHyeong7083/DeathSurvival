using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public GameObject AchievementsPanel;
    public Text[] clearText;
    public Image[] awardImage;

    int firstCheck;
    int secondCheck;
    int thirdCheck;

    bool isOpen = false;
    private void Awake()
    {
        AchievementsPanel.gameObject.SetActive(false);
    }

    void Start()
    {
        firstCheck = PlayerPrefs.GetInt("firstCheck");
        Debug.Log(firstCheck);
        secondCheck = PlayerPrefs.GetInt("secondCheck");
        thirdCheck = PlayerPrefs.GetInt("thirdCheck");

        for(int e = 0; e < clearText.Length; e++)
        {
            clearText[e].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstCheck >= 1)
        {
            clearText[0].gameObject.SetActive(true);
            awardImage[0].color = Color.white;
        }
        else
        {
            clearText[0].gameObject.SetActive(false);
            awardImage[0].color = Color.black;
        }

        if (secondCheck >= 1)
        {
            clearText[1].gameObject.SetActive(true);
            awardImage[1].color = Color.white;
        }
        else
        {
            clearText[1].gameObject.SetActive(false);
            awardImage[1].color = Color.black;
        }
        
        if (thirdCheck >= 1)
        {
            clearText[2].gameObject.SetActive(true);
            awardImage[2].color = Color.white;
        }
        else
        {
            clearText[2].gameObject.SetActive(false);
            awardImage[2].color = Color.black;
        }


        if(!BtnEffect.isOptionOn)
        {
            if (!isOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    AchievementsPanel.gameObject.SetActive(true);
                    isOpen = true;
                }
            }
            else if (isOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    AchievementsPanel.gameObject.SetActive(false);
                    isOpen = false;
                }
            }
        }

    
    }
}
