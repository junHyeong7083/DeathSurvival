using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TransitionSettings transition;

    public Button OptionBtn;
    public GameObject optionPanel;
    public GameObject hpBars;
    public Image[] optionSelect;
    int optionIndex;
    bool isoption = false;
    #region Die
    public GameObject DiePanel;
    float delayDieTime;
    #endregion

    public GameObject ClearPanel;
    float delayClearTime;
    // public Text levelTxt;
    public static bool isPause;
    bool isClick = false;

    float PlayerAskillTime = 0f;
    private void Start()
    {
        isoption = false;
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
        hpBars.gameObject.SetActive(false);
        isPause = true;
        optionPanel.SetActive(true);
    }
    public void OutOption()
    {
        hpBars.gameObject.SetActive(true);
        isPause = false;
        optionPanel.SetActive(false);
    }
    public void StopGame()
    {
        isPause = true;
    }
    public void ReStartGame()
    {
        isPause = false;
    }


    private void Update()
    {
        #region ESC Click
        if (!isClick)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                //  isPause = true; 
                //  optionPanel.SetActive(true);
                OnOption();
                isClick = true;
                isoption = true;
                Debug.Log("oPTION");  

            }

        }
        else if(isClick)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // isPause = false;
                // optionPanel.SetActive(false);
                OutOption();
                 isClick = false;
                isoption = false;
            }
        }

        if(isPause) { Time.timeScale = 0f; }
        else if(!isPause){ Time.timeScale = 1f; }
        #endregion

        #region Option Controller
        if (isoption)
        {
            #region 옵션 선택창 입력
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log(optionIndex);
                if (optionIndex == 0)
                    optionIndex = 0;
                else
                    optionIndex--;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log(optionIndex);
                if (optionIndex == 1)
                    optionIndex = 1;
                else
                    optionIndex++;
            }
            #endregion
            switch (optionIndex)
            {
                case 1:
                    optionSelect[0].gameObject.SetActive(true);
                    optionSelect[1].gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        TransitionManager.Instance().Transition(1, transition, 0);
                    }
                    break;

                case 0:
                    optionSelect[1].gameObject.SetActive(true);
                    optionSelect[0].gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Application.Quit();
                    }
                    break;
            }
        }
        #endregion

        #region PlayerA Skill4 TimeSave
        if (WeaponDataManager.playerAFourbool)
            PlayerAskillTime += Time.deltaTime;
        #endregion

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

                Animator[] allAnimators = FindObjectsOfType<Animator>();
                foreach (Animator animator in allAnimators)
                {
                    animator.speed = 0f; 
                }
            }
        }


        #endregion

        #region ClearPanel
        if (TimerManager.isClear)
        {
            // Pixelate.showHpBar = false;
            delayClearTime += Time.deltaTime;

            if (delayClearTime > 1.3f)
                Pixelate.showHpBar = false;

            if (delayClearTime > 1.5f)
            {
                if (!isOnes)
                {
                    Pixelate.showClearEffect = true;
                    isOnes = true;
                }

                if (Pixelate.showClearPanel)
                {
                    Time.timeScale = 0f;
                    ClearPanel.gameObject.SetActive(true);
                }
                PlayerHpBar.isDie = false;

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
