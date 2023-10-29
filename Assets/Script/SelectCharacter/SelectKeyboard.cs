using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using NBitcoin;

public class SelectKeyboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    public static bool isClick;
    float changeTime = 2f;
    public static int currentIndex;
    public static int selectBtn;
    public static bool isMouseuse = false;
    public Outline[] buttonOutlines;
    public UnityEngine.UI.Image[] buttonSelects;

    Vector3 targetPosition = new Vector3(0,0,0);
    //  float movementSpeed = 2.0f; // 이동 속도 조절
    public GameObject[] showPaenl;

    public static bool canB = false;
    public static bool canC = false;
    float checkB = 0f;
    float checkC = 0f;

    void Start()
    {
        checkB = PlayerPrefs.GetFloat("CharacterB");
        checkC = PlayerPrefs.GetFloat("CharacterC");

        if (checkB >= 1)
            canB = true;
        else
            canB = false;

        if (checkC >= 2)
            canC = true;
        else
            canC = false;

        isMouseuse = false;
        selectBtn = 1;
        CharacterManager.Instance.currentCharacter = Character.White;
        currentIndex = 0;
        scrollRect.content.localPosition = new Vector3(0, 0, 0);
        isClick = false;
        for (int e = 0; e < showPaenl.Length; ++e)
        {
            showPaenl[e].gameObject.SetActive(false);
        }
    }

    void Update()
    {


        if(!isMouseuse)
        {
            #region 캐릭터 선택
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (currentIndex > 0)
                {

                    currentIndex--;
                }
                else if (currentIndex == 0)
                {

                    currentIndex = 2;
                }
                //   isClick = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (currentIndex < 2)
                {
                    currentIndex++;
                }
                else if (currentIndex == 2)
                {
                    currentIndex = 0;
                }

            }
            switch (currentIndex)
            {
                case 0:
                    targetPosition = new Vector3(0, 0, 0);
                    scrollRect.content.localPosition = targetPosition;
                    //scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    //Debug.Log("X0" + scrollRect.content.localPosition.x);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.White;
                    break;

                case 1:
                    targetPosition = new Vector3(-653.24f, 0, 0);
                    scrollRect.content.localPosition = targetPosition;
                    //scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    //Debug.Log("X1" + scrollRect.content.localPosition.x);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.Blue;
                    break;

                case 2:
                    targetPosition = new Vector3(-1291.608f, 0, 0);
                    scrollRect.content.localPosition = targetPosition;

                    // scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    // Debug.Log("X2" + scrollRect.content.localPosition.x);     
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.Green;
                    break;
            }
            #endregion
            #region 버튼 선택
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (selectBtn == 1)
                    selectBtn = 1;
                else
                    selectBtn++;

                Debug.Log(selectBtn);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (selectBtn == 0)
                    selectBtn = 0;
                else
                    selectBtn--;

                Debug.Log(selectBtn);
            }
            switch (selectBtn)
            {
                case 1: // 게임시작
                    buttonOutlines[0].effectColor = Color.green;
                    buttonOutlines[1].effectColor = Color.white;

                    buttonSelects[0].gameObject.SetActive(true);
                    buttonSelects[1].gameObject.SetActive(false);
                    if(currentIndex == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            SceneManager.LoadScene(2);
                        }
                    }
                    else if(currentIndex == 1)
                    {
                        if(canB)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                SceneManager.LoadScene(2);
                            }
                        }
                    }
                    else if (currentIndex == 2)
                    {
                        if (canC)
                        {
                            Debug.Log("canC : " + canC);

                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                SceneManager.LoadScene(2);
                            }
                        }
                    }
                    break;

                case 0: // 타이틀로돌아가기
                    buttonOutlines[0].effectColor = Color.white;
                    buttonOutlines[1].effectColor = Color.green;

                    buttonSelects[0].gameObject.SetActive(false);
                    buttonSelects[1].gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene(0);
                    }
                    break;
            }

            #endregion

        }

    }
}
