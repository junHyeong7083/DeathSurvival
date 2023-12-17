using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnEffect : MonoBehaviour
{
    public Text StartTxt;
    public Text OptionTxt;
    public Text ExitTxt;
    Outline StartBtnOutline;
    Outline OptionBtnOutline;
    Outline ExitBtnOutline;

    public GameObject[] selectObj;
    bool isSelect;
    bool isMouse;
    int currentIndex;

   // float masterSound;
   // float bgmSound;
   // float sfxSound;

    public GameObject OptionPanel;
    public GameObject[] optionSelectObj;
    int optionIndex;

    public Slider[] sliders;
    public Image[] handles;
    public Text[] valueTexts;
    public Button[] sounds;
    public Sprite[] soundIcons;
    bool xmasterSound;
    bool xbgmSound;
    bool xsfxSound;

    public static bool isOptionOn; // 옵션패널 계속 안열리도록 방지하는 코드
    public GameObject SceneManager;
    ChangeScene changeScene;
    private void Awake()
    {
        isOptionSet = PlayerPrefs.GetInt("isOptionSet");
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("isOptionSet")==1)
        {
            sliders[0].value = PlayerPrefs.GetFloat("masterSound");
            sliders[1].value = PlayerPrefs.GetFloat("bgmSound");
            sliders[2].value = PlayerPrefs.GetFloat("sfxSound");
        }
        else
        {
            sliders[0].value = 0.5f; sliders[1].value = 0.5f; sliders[2].value = 0.5f;
        }

        sounds[0].image.sprite = soundIcons[1];
        sounds[1].image.sprite = soundIcons[1];
        sounds[2].image.sprite = soundIcons[1];
        xmasterSound = false;
        xbgmSound = false;
        xsfxSound = false;
        optionIndex = 2; // 시작값 2;
        isOptionOn = false;
        OptionPanel.gameObject.SetActive(false);
        isMouse = false;
        isSelect = false;
        changeScene = SceneManager.GetComponent<ChangeScene>();
        currentIndex = 2; // 시작시 게임시작 위치
        StartBtnOutline = StartTxt.GetComponent<Outline>();
        OptionBtnOutline = OptionTxt.GetComponent<Outline>();
        ExitBtnOutline = ExitTxt.GetComponent<Outline>();
    }
    int isOptionSet = 0;
    int mouseIndex;
    #region 옵션창
    public void OnOptionPanel()
    {
        OptionPanel.gameObject.SetActive(true);
        isOptionOn = true;
    }
    public void OutOptionPanel()
    {
        OptionPanel.gameObject.SetActive(false);
        isOptionOn = false;
    }
    #endregion
    #region 마우스 음소거 버튼 클릭효과
    public void masterSoundBtn()
    {
        if (!xmasterSound)
        {
            sounds[0].image.sprite = soundIcons[0];
            xmasterSound = true;
        }
        else if (xmasterSound)
        {
            sounds[0].image.sprite = soundIcons[1];
            xmasterSound = false;
        }

    }
    public void bgmSoundBtn()
    {
        if (!xbgmSound)
        {
            sounds[1].image.sprite = soundIcons[0];
            xbgmSound = true;
        }
        else if (xbgmSound)
        {
            sounds[1].image.sprite = soundIcons[1];
            xbgmSound = false;
        }

    }
    public void sfxSoundBtn()
    {
        if (!xsfxSound)
        {
            sounds[2].image.sprite = soundIcons[0];
            xsfxSound = true;
        }
        else if (xsfxSound)
        {
            sounds[2].image.sprite = soundIcons[1];
            xsfxSound = false;
        }

    }
    #endregion


    #region 마우스 온오프 효과
    public void OnMouseStartBtn()
    {
        mouseIndex = 2;
        isMouse = true;
        selectObj[2].gameObject.SetActive(true);
        selectObj[0].gameObject.SetActive(false);
        selectObj[1].gameObject.SetActive(false);

        StartBtnOutline.effectColor = Color.red;
        OptionBtnOutline.effectColor = Color.white;
        ExitBtnOutline.effectColor = Color.white;
    }
    public void OutMouseStartBtn()
    {
        currentIndex = mouseIndex;
        isMouse = false;
        selectObj[2].gameObject.SetActive(false);
        StartBtnOutline.effectColor = Color.white;
    }
    public void OnMouseOptionBtn()
    {
        mouseIndex = 1;
        isMouse = true;
        selectObj[1].gameObject.SetActive(true);
        selectObj[0].gameObject.SetActive(false);
        selectObj[2].gameObject.SetActive(false);

        OptionBtnOutline.effectColor = Color.green;
        StartBtnOutline.effectColor = Color.white;
        ExitBtnOutline.effectColor = Color.white;
    }
    public void OutMouseOptionBtn()
    {
        currentIndex = mouseIndex;
        isMouse = false;
        selectObj[1].gameObject.SetActive(false);
        OptionBtnOutline.effectColor = Color.white;
    }
    public void OnMouseExitBtn()
    {
        mouseIndex = 0;
        isMouse = true;
        selectObj[0].gameObject.SetActive(true);
        selectObj[1].gameObject.SetActive(false);
        selectObj[2].gameObject.SetActive(false);

        ExitBtnOutline.effectColor = Color.black;
        StartBtnOutline.effectColor = Color.white;
        OptionBtnOutline.effectColor = Color.white;
    }
    public void OutMouseExitBtn()
    {
        currentIndex = mouseIndex;
        isMouse = false;
        selectObj[0].gameObject.SetActive(false);
        ExitBtnOutline.effectColor = Color.white;
    }

    public void OnMaster()
    {
        optionIndex = 2;
    }
    public void OnBGM()
    {
        optionIndex = 1;
    }
  
    public void OnSFX()
    {
        optionIndex = 0;
    }
    #endregion

    private void Update()
    {
        valueTexts[0].text = (sliders[0].value * 100).ToString("F0") + "%'";
        valueTexts[1].text = (sliders[1].value * 100).ToString("F0") + "%'";
        valueTexts[2].text = (sliders[2].value * 100).ToString("F0") + "%'";

        if (!isMouse && !isOptionOn)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow)) // 아래
            {
                if (currentIndex == 0)
                    currentIndex = 0;
                else
                    currentIndex--;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow)) // 위
            {
                if (currentIndex == 2)
                    currentIndex = 2;
                else
                    currentIndex++;
            }
            else if(Input.GetKeyDown(KeyCode.Space)) // 입력
            {
                isSelect = true;
            }
            switch (currentIndex)
            {
                case 0:
                    for (int e = 0; e < selectObj.Length; ++e)
                    {
                        if (e == currentIndex)
                        {
                            ExitBtnOutline.effectColor = Color.black;
                            selectObj[e].gameObject.SetActive(true);
                        }
                        else
                        {
                            StartBtnOutline.effectColor = Color.white;
                            OptionBtnOutline.effectColor = Color.white;
                            selectObj[e].gameObject.SetActive(false);
                        }
                    }

                    if (isSelect)
                    {
                        isSelect = false;
                        changeScene.ExitGame();
                    }
                    break;

                case 1:
                    for (int e = 0; e < selectObj.Length; ++e)
                    {
                        if (e == currentIndex)
                        {
                            OptionBtnOutline.effectColor = Color.green;
                            selectObj[e].gameObject.SetActive(true);
                        }
                        else
                        {
                            StartBtnOutline.effectColor = Color.white;
                            ExitBtnOutline.effectColor = Color.white;
                            selectObj[e].gameObject.SetActive(false);
                        }
                    }
                    if (isSelect)
                    {
                        OptionPanel.gameObject.SetActive(true);
                        isOptionOn = true;
                        isSelect = false;
                    }
                    break;

                case 2:
                    for (int e = 0; e < selectObj.Length; ++e)
                    {
                        if (e == currentIndex)
                        {
                            StartBtnOutline.effectColor = Color.red;
                            selectObj[e].gameObject.SetActive(true);
                        }

                        else
                        {
                            OptionBtnOutline.effectColor = Color.white;
                            ExitBtnOutline.effectColor = Color.white;
                            selectObj[e].gameObject.SetActive(false);
                        }
                    }

                    if (isSelect)
                    {
                        isSelect = false;
                        changeScene.GoSelectScene();
                    }
                    break;
            }
        }
        if (isOptionOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OptionPanel.gameObject.SetActive(false);
                isOptionOn = false;
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (optionIndex == 0)
                    optionIndex = 0;
                else
                {
                    optionIndex--;
                }
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(optionIndex == 2)
                    optionIndex = 2; 
                else
                {
                    optionIndex++;
                }

            }

            switch (optionIndex)
            {
                case 2:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliders[0].value += 0.1f;
                        //Debug.Log("master:  " +sliders[0].value);
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliders[0].value -= 0.1f;
                        Debug.Log("master:  " + sliders[0].value);
                    }
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        masterSoundBtn();
                    }



                    for (int e = 0; e < optionSelectObj.Length; ++e)
                    {
                        if (e == optionIndex)
                            optionSelectObj[e].gameObject.SetActive(true);
                        else
                            optionSelectObj[e].gameObject.SetActive(false);
                    }
                    PlayerPrefs.SetInt("isOptionSet", 1);
                    PlayerPrefs.SetFloat("masterSound", sliders[0].value);
                    break;

                case 1:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliders[1].value += 0.1f;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        sliders[1].value -= 0.1f;
                    }
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {

                        bgmSoundBtn();
                    }


                    for (int e = 0; e < optionSelectObj.Length; ++e)
                    {
                        if (e == optionIndex)
                            optionSelectObj[e].gameObject.SetActive(true);
                        else
                            optionSelectObj[e].gameObject.SetActive(false);
                    }
                    PlayerPrefs.SetInt("isOptionSet", 1);
                    PlayerPrefs.SetFloat("bgmSound", sliders[1].value);
                    break;

                case 0:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {

                        sliders[2].value += 0.1f;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {


                        sliders[2].value -= 0.1f;
                    }
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {

                        sfxSoundBtn();
                    }




                    for (int e = 0; e < optionSelectObj.Length; ++e)
                    {
                        if (e == optionIndex)
                            optionSelectObj[e].gameObject.SetActive(true);
                        else
                            optionSelectObj[e].gameObject.SetActive(false);
                    }
                    PlayerPrefs.SetInt("isOptionSet", 1);
                    PlayerPrefs.SetFloat("sfxSound", sliders[2].value);
                    break;

            }
        }
    }
}
