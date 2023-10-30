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

    float PlayerAskillTime = 0f;
    private void Start()
    {
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
            if (delayDieTime > 1.0f)
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

                #region Damage Text
                PlayerADamage[0].text = "1번스킬 : " + MonsterController.PlayerAOneDamage.ToString();
                PlayerADamage[1].text = "2번스킬 : " + MonsterController.PlayerATwoDamage.ToString();
                PlayerADamage[2].text = "3번스킬 : " + MonsterController.PlayerAThreeDamage.ToString();
                PlayerADamage[3].text = "4번스킬 : " + PlayerAskillTime.ToString("F2") + "초";
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
