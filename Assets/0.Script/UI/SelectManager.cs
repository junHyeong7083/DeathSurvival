using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [Header("TransitionSet")]
    public TransitionSettings transition;

    [Header("CharacterPanel")]
    public Image[] charBox;

    [Header("SelectEffect")]
    public Image[] showEffectImage;
    public Outline[] showButtonOutline;
    int currentUpDownValue = 1;
    int currentLeftRightValue = 0;

    [Header("SceneButton")]
    public Button[] buttons;
    public Outline[] outlines;

    [SerializeField]
    float changeSpeed = 6; // 패널 이동속도

    [Header("Key")]
    public GameObject[] Key;
    int firstValue;
    int secondValue;

    #region 패널 변경을 위한 Vector
    Vector3 targetPosPlayerA;
    Vector3 targetPosPlayerB;
    Vector3 targetPosPlayerC;

    Vector3 currentPosPlayerA;
    Vector3 currentPosPlayerB;
    Vector3 currentPosPlayerC;

    Vector2 originScale;
    Vector2 changeScale;
    #endregion

    float checkB = 0f;
    float checkC = 0f; 
    public static bool canB = false;
    public static bool canC = false;
    void Start()
    {
        firstValue = PlayerPrefs.GetInt("firstCheck");
        secondValue = PlayerPrefs.GetInt("secondCheck");
        Key[0].gameObject.SetActive(true);
        Key[1].gameObject.SetActive(true);

        if (firstValue >= 1)
            canB = true;
        else
            canB = false;

        if (secondValue >= 2)
            canC = true;
        else
            canC = false;

        if(firstValue ==1)
        {
            Key[0].gameObject.SetActive(false);
        }
        if(secondValue == 1)
        {
            Key[1].gameObject.SetActive(false);
        }

        #region Init
        originScale = new Vector2(600, 320);
        changeScale = new Vector2(470, 250);

        currentPosPlayerA = new Vector3(279, -15, 0);
        currentPosPlayerB = new Vector3(180, 34, 0);
        currentPosPlayerC = new Vector3(-180, 34, 0);


        #endregion
    }

    void LoadScene(int _sceneName)
    {
        TransitionManager.Instance().Transition(_sceneName, transition, 0f);
    }


    #region Keyboard
    void ShowCurrentBtnIndex(int currentIndex)
    {
        for(int e= 0; e < showEffectImage.Length; e++)
        {
            if(e == currentIndex)
            {
                showEffectImage[e].gameObject.SetActive(true);
                showButtonOutline[e].effectColor = Color.green;
            }
            else
            {
                showEffectImage[e].gameObject.SetActive(false);
                showButtonOutline[e].effectColor = Color.white;
            }
        }
    }
    void ChangePanelColor(int currentIndex)
    {
        for (int e = 0; e < charBox.Length; ++e)
        {
            if (e != currentIndex)
            {
                charBox[e].GetComponent<Image>().color = new Color32(89, 74, 74, 255);
            }
            else if (e == currentIndex)
            {
                charBox[e].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    } // 캐릭터 패널의 색변경 조절
    void ChangePanelPos_Size(int currentIndex)
    {
        switch(currentIndex)
        {
            case 0:
                targetPosPlayerA = new Vector3(-3, 0, 0);
                targetPosPlayerB = new Vector3(230, 50, 0);
                targetPosPlayerC = new Vector3(-230, 50, 0);

                charBox[0].rectTransform.sizeDelta = originScale;
                charBox[1].rectTransform.sizeDelta = changeScale;
                charBox[2].rectTransform.sizeDelta = changeScale;

                charBox[0].transform.localPosition = Vector3.Lerp(currentPosPlayerA, targetPosPlayerA, changeSpeed * Time.deltaTime);
                charBox[1].transform.localPosition = Vector3.Lerp(currentPosPlayerB, targetPosPlayerB, changeSpeed * Time.deltaTime);
                charBox[2].transform.localPosition = Vector3.Lerp(currentPosPlayerC, targetPosPlayerC, changeSpeed * Time.deltaTime);

                charBox[0].rectTransform.SetSiblingIndex(5);
                charBox[1].rectTransform.SetSiblingIndex(1);
                charBox[2].rectTransform.SetSiblingIndex(1);
                currentPosPlayerA = charBox[0].transform.localPosition;
                currentPosPlayerB = charBox[1].transform.localPosition;
                currentPosPlayerC = charBox[2].transform.localPosition;
                break;

            case 1:
                targetPosPlayerA = new Vector3(-230, 50, 0);
                targetPosPlayerB = new Vector3(-3, 0, 0);
                targetPosPlayerC = new Vector3(230, 50, 0);

                charBox[1].rectTransform.sizeDelta = originScale;
                charBox[0].rectTransform.sizeDelta = changeScale;
                charBox[2].rectTransform.sizeDelta = changeScale;

                charBox[0].transform.localPosition = Vector3.Lerp(currentPosPlayerA, targetPosPlayerA, changeSpeed * Time.deltaTime);
                charBox[1].transform.localPosition = Vector3.Lerp(currentPosPlayerB, targetPosPlayerB, changeSpeed * Time.deltaTime);
                charBox[2].transform.localPosition = Vector3.Lerp(currentPosPlayerC, targetPosPlayerC, changeSpeed * Time.deltaTime);

                charBox[0].rectTransform.SetSiblingIndex(1);
                charBox[1].rectTransform.SetSiblingIndex(5);
                charBox[2].rectTransform.SetSiblingIndex(1);
                currentPosPlayerA = charBox[0].transform.localPosition;
                currentPosPlayerB = charBox[1].transform.localPosition;
                currentPosPlayerC = charBox[2].transform.localPosition;
                break;

            case 2:
                targetPosPlayerA = new Vector3(230, 50, 0);
                targetPosPlayerB = new Vector3(-230, 50, 0);
                targetPosPlayerC = new Vector3(-3, 0, 0);

                charBox[2].rectTransform.sizeDelta = originScale;
                charBox[1].rectTransform.sizeDelta = changeScale;
                charBox[0].rectTransform.sizeDelta = changeScale;

                charBox[0].transform.localPosition = Vector3.Lerp(currentPosPlayerA, targetPosPlayerA, changeSpeed * Time.deltaTime);
                charBox[1].transform.localPosition = Vector3.Lerp(currentPosPlayerB, targetPosPlayerB, changeSpeed * Time.deltaTime);
                charBox[2].transform.localPosition = Vector3.Lerp(currentPosPlayerC, targetPosPlayerC, changeSpeed * Time.deltaTime);

                charBox[0].rectTransform.SetSiblingIndex(1);
                charBox[1].rectTransform.SetSiblingIndex(1);
                charBox[2].rectTransform.SetSiblingIndex(5);

                currentPosPlayerA = charBox[0].transform.localPosition;
                currentPosPlayerB = charBox[1].transform.localPosition;
                currentPosPlayerC = charBox[2].transform.localPosition;
                break;

        }
    } // 캐릭터 패널의 이동및 사이즈 조절
    #endregion

    #region Mouse
    public void OnStartButton()
    {
        outlines[0].effectColor = Color.green;
        outlines[1].effectColor = Color.white;
        currentUpDownValue = 1;
    }

    public void OutStartButton()
    {
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.white;
        currentUpDownValue = 1;

    }

    public void OnBackButton()
    {
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.green;
        currentUpDownValue = 0;
    }
    public void OutBackButton()
    {
        outlines[0].effectColor = Color.white;
        outlines[1].effectColor = Color.white;
        currentUpDownValue = 0;
    }


    public void OnClickStartButton()
    {

    }
    public void OnClickBackButton()
    {

    }



    #endregion
    public void StartGame(int currentIndex)
    {
        switch(currentIndex)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Pixelate.toGame = true;
                }
                break;

            case 1:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (canB)
                    {
                        Pixelate.toGame = true;
                        // SceneManager.LoadScene(2);
                    }
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (canC)
                    {
                        Pixelate.toGame = true;
                        // SceneManager.LoadScene(2);
                    }
                }
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        #region 게임시작, 돌아가기 키입력
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentUpDownValue == 1)
                currentUpDownValue = 1;
            else
                currentUpDownValue++;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentUpDownValue == 0)
                currentUpDownValue = 0;
            else
                currentUpDownValue--;
        }

        switch(currentUpDownValue)
        {
            case 1:
                ShowCurrentBtnIndex(1);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame(currentLeftRightValue);
                }
                
                break;
                
            case 0:
                ShowCurrentBtnIndex(0);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LoadScene(1);
                }
                break;
        }

        #endregion

        #region 캐릭터 선택
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLeftRightValue == 2)
                currentLeftRightValue = 0;
            else
                currentLeftRightValue++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLeftRightValue == 0)
                currentLeftRightValue = 2;
            else
                currentLeftRightValue--;
        }
        switch(currentLeftRightValue)
        {
            case 0:
                CharacterManager.Instance.currentCharacter = Character.White;
                ChangePanelPos_Size(0);
                ChangePanelColor(0);
                break;

            case 1:
                CharacterManager.Instance.currentCharacter = Character.Blue;
                ChangePanelPos_Size(1);
                ChangePanelColor(1); 
                break;

            case 2:
                CharacterManager.Instance.currentCharacter = Character.Green;
                ChangePanelPos_Size(2);
                ChangePanelColor(2);
                break;

        }
        #endregion
    }
}
