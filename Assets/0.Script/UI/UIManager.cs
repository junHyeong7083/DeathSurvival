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

    public Text huntText;
    #region Die
    public GameObject DiePanel;
    float delayDieTime;
    #endregion

    public GameObject ClearPanel;
    public GameObject[] clearEffects;
    public Outline[] clearoutlnes;
    int clearIndex = 1;
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
        ClearPanel.gameObject.SetActive(false);
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

    public void OnClearTitle()
    {
        clearIndex = 1;
    }
    public void OnClearQuit()
    {
        clearIndex = 0;
    }

    private void Update()
    {
        huntText.text = "x " + MonsterManager.huntMonsterCnt.ToString();


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

        Debug.Log("timebool : " + TimerManager.isClear);
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
                    Pixelate.showHpBar = false; 
                    Time.timeScale = 0f;
                    ClearPanel.gameObject.SetActive(true);
                    SoundManager.Instance.PlaySFXSound("GameOver", 0.05f);
                    if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                    {
                        if (clearIndex == 0)
                            clearIndex = 1;
                        else
                            clearIndex--;
                    }

                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                    {
                        if (clearIndex == 1)
                            clearIndex = 0;
                        else
                            clearIndex++;
                    }

                    switch(clearIndex)
                    {
                        case 1:
                            clearoutlnes[0].effectColor = Color.red;
                            clearoutlnes[1].effectColor = Color.black;

                            clearEffects[0].gameObject.SetActive(true);
                            clearEffects[1].gameObject.SetActive(false);
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                GetComponent<ChangeScene>().GoTitleScene();
                            }
                            break;

                        case 0:
                            clearoutlnes[1].effectColor = Color.red;
                            clearoutlnes[0].effectColor = Color.black;

                            clearEffects[1].gameObject.SetActive(true);
                            clearEffects[0].gameObject.SetActive(false);
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                GetComponent<ChangeScene>().Quit();
                            }
                            break;
                    }
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

        #region 치트키
        if(Input.GetKeyDown(KeyCode.F1))
        {
            TimerManager.isClear = true;
            switch (CharacterManager.Instance.currentCharacter)
            {
                case Character.White:
                    PlayerPrefs.SetInt("firstCheck", 1);
                    break;

                case Character.Blue:
                    PlayerPrefs.SetInt("secondCheck", 1);
                    break;

                case Character.Green:
                    PlayerPrefs.SetInt("thirdCheck", 1);
                    break;
            }
        } // 강제 클리어

        if (Input.GetKeyDown(KeyCode.F5))
        {
            PlayerPrefs.SetInt("firstCheck", 1);
        } // 토구 해금

        if (Input.GetKeyDown(KeyCode.F6))
        {
            PlayerPrefs.SetInt("secondCheck", 1);
        } // 톱구 해금

        if (Input.GetKeyDown(KeyCode.F7))
        {
            PlayerPrefs.SetInt("thirdCheck", 1);
        } // 히든 해금


        if (Input.GetKeyDown(KeyCode.F8))
        {
            PlayerPrefs.SetInt("firstCheck", 0);
            PlayerPrefs.SetInt("secondCheck", 0);
            PlayerPrefs.SetInt("thirdCheck", 0);
        } // 초기화
        #endregion
    }
    bool isOnes;
}
