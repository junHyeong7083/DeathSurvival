using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button OptionBtn;
    public GameObject optionPanel;
    public Image[] optionSelect;
    int optionIndex;

    #region Die
    public GameObject DiePanel;
    float delayDieTime;

    public Text[] PlayerADamage;

    #endregion
    // public Text levelTxt;
    public static bool isPause;
    bool isClick = false;

    float PlayerAskillTime = 0f;
    private void Start()
    {
        for (int e = 0; e < optionSelect.Length; ++e)
            optionSelect[e].gameObject.SetActive(false);

        optionIndex = 1;
        isOnes = false;
        Time.timeScale = 1f;
        delayDieTime = 0f;
        DiePanel.gameObject.SetActive(false);

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
        #region ESC Click
        if (!isClick)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = true; 
                optionPanel.SetActive(true);
                isClick = true;
/*
                #region 옵션 선택창 입력
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log(optionIndex);
                    if (optionIndex == 0)
                        optionIndex = 0;
                    else
                        optionIndex--;
                }

                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log(optionIndex);
                    if (optionIndex == 1)
                        optionIndex = 1;
                    else
                        optionIndex++;
                }
                #endregion
                switch(optionIndex)
                {
                    case 1:
                        optionSelect[0].gameObject.SetActive(true);
                        optionSelect[1].gameObject.SetActive(false);

                        if(Input.GetKeyDown(KeyCode.Space))
                        {
                            SceneManager.LoadScene(1);
                        }
                        break;

                    case 2:
                        optionSelect[1].gameObject.SetActive(true);
                        optionSelect[0].gameObject.SetActive(false);

                        if(Input.GetKeyDown(KeyCode.Space))
                        {
                            Application.Quit();
                        }
                        break;
                }*/
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

        if (WeaponDataManager.playerAFourbool)
            PlayerAskillTime += Time.deltaTime;


        #region DiePanel
        if (PlayerHpBar.isDie)
        {
           // Pixelate.showHpBar = false;
            delayDieTime += Time.deltaTime;

            if (delayDieTime > 1.3f)
                Pixelate.showHpBar = false;

            if (delayDieTime > 1.5f)
            {
                if (!isOnes)
                {
                    Pixelate.showDieEffect = true;
                    isOnes = true;
                }

                if (Pixelate.showDiePanel)
                {
                    Time.timeScale = 0f;
                    DiePanel.gameObject.SetActive(true);
                }
                PlayerHpBar.isDie = false;

                #region Damage Text_DataPanel
                PlayerADamage[0].text = "1번스킬 : " + MonsterController.PlayerAOneDamage.ToString();
                PlayerADamage[1].text = "2번스킬 : " + MonsterController.PlayerATwoDamage.ToString();
                PlayerADamage[2].text = "3번스킬 : " + MonsterController.PlayerAThreeDamage.ToString();
                PlayerADamage[3].text = "4번스킬 : " + PlayerAskillTime.ToString("F2") + "초";
                #endregion

                #region Damage_GraphPanel

                #endregion

                Animator[] allAnimators = FindObjectsOfType<Animator>();
                foreach (Animator animator in allAnimators)
                {
                    animator.speed = 0f; 
                }
            }
        }


        #endregion
    }
    bool isOnes;
}
