using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    bool isInput;
    bool isSelect;
    bool isMouse;
    float isdelayInputTime;
    int currentIndex;

    public GameObject OptionPanel;
    bool isOptionOn;
    public GameObject SceneManager;
    ChangeScene changeScene;
    private void Start()
    {
        isOptionOn = false;
        OptionPanel.gameObject.SetActive(false);
        isMouse = false;
        isSelect = false;
        changeScene = SceneManager.GetComponent<ChangeScene>();
        isdelayInputTime = 0f;
        currentIndex = 2; // 시작시 게임시작 위치
        isInput = false;
        StartBtnOutline = StartTxt.GetComponent<Outline>();
        OptionBtnOutline = OptionTxt.GetComponent<Outline>();
        ExitBtnOutline = ExitTxt.GetComponent<Outline>();
    }

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
    #endregion

    private void Update()
    {
        if(!isInput && !isMouse)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow)) // 아래
            {
                isInput = true;
                if (currentIndex == 0)
                    currentIndex = 0;
                else
                    currentIndex--;

                Debug.Log(currentIndex);
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow)) // 위
            {
                isInput = true;
                if (currentIndex == 2)
                    currentIndex = 2;
                else
                    currentIndex++;
                Debug.Log(currentIndex);
            }
            else if(Input.GetKeyDown(KeyCode.Space)) // 입력
            {
                isSelect = true;
            }
            
        }
        if(isInput)
        {
            isdelayInputTime += Time.deltaTime;
            if(isdelayInputTime > 0.15f)
            {
                isdelayInputTime = 0;
                isInput = false;
            }
        }
        if(!isMouse )
        {
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
                Debug.Log("??");
                OptionPanel.gameObject.SetActive(false);
                isOptionOn = false;
            }
        }

    }
}
