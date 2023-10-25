using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button OptionBtn;
    public GameObject optionPanel;


    #region Die
    public GameObject DiePanel;
    float delayDieTime;

    public Text[] PlayerADamage;

    #endregion
    // public Text levelTxt;
    public static bool isPause;
    bool isClick = false;
    private void Start()
    {
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

        #region DiePanel
        if(PlayerHpBar.isDie)
        {
            delayDieTime += Time.deltaTime;
            if(delayDieTime > 2f)
            {
                PlayerHpBar.isDie = false;
                DiePanel.gameObject.SetActive(true);

                #region Damage Text
                PlayerADamage[0].text = "1번스킬 : " + MonsterController.PlayerAOneDamage.ToString();
                PlayerADamage[1].text = "2번스킬 : " + MonsterController.PlayerATwoDamage.ToString();
                PlayerADamage[2].text = "3번스킬 : " + MonsterController.PlayerAThreeDamage.ToString();
                #endregion
                Time.timeScale = 0f;

                Animator[] allAnimators = FindObjectsOfType<Animator>();
                foreach (Animator animator in allAnimators)
                {
                    animator.speed = 0f; 
                }
            }
        }


        #endregion
    }
}
