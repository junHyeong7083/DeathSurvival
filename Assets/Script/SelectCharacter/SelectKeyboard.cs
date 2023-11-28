using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using EasyTransition;

public class SelectKeyboard : MonoBehaviour
{
    #region Effect
    public GameObject showEffectPanel;
    public float effectTime;
    Vector3 originPos = new Vector3(870, 0, 0);
    #endregion

    public ScrollRect scrollRect;
    public static bool isClick;
    float changeTime = 2f;
    public static int currentIndex;
    public static int selectBtn;
    public static bool isMouseuse = false;
    public Outline[] buttonOutlines;
    public UnityEngine.UI.Image[] buttonSelects;

    Vector3 targetPosition;
    Vector3 prePosition;
    //  float movementSpeed = 2.0f; // 이동 속도 조절
    public GameObject[] showPaenl;

    public static bool canB = false;
    public static bool canC = false;
    float checkB = 0f;
    float checkC = 0f;

    public TransitionSettings transition;
    float loadDelay = 0f;

    void Start()
    {
        originPos = new Vector3(456, 0, 0);
        showEffectPanel.transform.localPosition = originPos;

        targetPosition = new Vector3(0, 0, 0);
        prePosition = targetPosition;
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

     void LoadScene(int _sceneName)
    {
        TransitionManager.Instance().Transition(_sceneName, transition, loadDelay);
    }


    void Update()
    {
        if(!isInput)
        {
            inputCoolTime += Time.deltaTime;
            if(inputCoolTime >= 0.22f)
            {
                inputCoolTime = 0f;
                isInput = true;
            }
        }

        if (!isMouseuse)
        {
            if(isInput)
            {
                #region 캐릭터 선택
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    isInput = false;
                    isOnes = false;
                    isCheck = true;
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
                    isInput = false;
                    isCheck = true;
                    isOnes = false;
                    if (currentIndex < 2)
                    {
                        currentIndex++;
                    }
                    else if (currentIndex == 2)
                    {
                        currentIndex = 0;
                    }

                }
                #endregion
            }
            switch (currentIndex)
            {
                case 0:
                    targetPosition = new Vector3(-177, 0, 0);
                    if (!isOnes && isCheck)
                    {
                        StartCoroutine(panelEffect(currentIndex));
                        isOnes = true;
                    }
                    scrollRect.content.localPosition = Vector3.Lerp(prePosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.White;
                    prePosition = scrollRect.content.localPosition;
                    break;

                case 1:
                    targetPosition = new Vector3(-670, 0, 0);
                    if (!isOnes && isCheck)
                    {
                        StartCoroutine(panelEffect(currentIndex));
                        isOnes = true;
                    }
                    //StartCoroutine(panelEffect());
                    scrollRect.content.localPosition = Vector3.Lerp(prePosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    //Debug.Log("X1" + scrollRect.content.localPosition.x);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.Blue;
                    prePosition = scrollRect.content.localPosition;
                    break;

                case 2:
                    targetPosition = new Vector3(-1330, 0, 0);
                    if (!isOnes && isCheck)
                    {
                        StartCoroutine(panelEffect(currentIndex));
                        isOnes = true;
                    }
                    // StartCoroutine(panelEffect());
                    scrollRect.content.localPosition = Vector3.Lerp(prePosition, targetPosition, (changeTime * 9) * Time.deltaTime);
                    // Debug.Log("X2" + scrollRect.content.localPosition.x);     
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    CharacterManager.Instance.currentCharacter = Character.Green;
                    prePosition = scrollRect.content.localPosition;
                    break;
            }
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
                    if (currentIndex == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Pixelate.toGame = true;
                         //   SceneManager.LoadScene(2);
                        }
                    }
                    else if (currentIndex == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (canB)
                            {
                                Pixelate.toGame = true;
                               // SceneManager.LoadScene(2);
                            }
                            else if (!canB)
                            {
                                //StartCoroutine(CanvasShaking(0.1f, 0.1f));
                            }
                        }

                    }
                    else if (currentIndex == 2)
                    {
                        //Debug.Log("canC : " + canC);

                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (canC)
                            {
                                Pixelate.toGame = true;
                               // SceneManager.LoadScene(2);
                            }
                            else if (!canC)
                            {
                                //StartCoroutine(CanvasShaking(0.1f, 0.1f));
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
                        // SceneManager.LoadScene(0);
                        LoadScene(0);
                    }
                    break;
            }

            #endregion

        }

    }
    bool isInput = true;
    float inputCoolTime = 0f;
    bool isOnes = false;
    bool isCheck = false;
    public IEnumerator panelEffect(int num)
    {
        // 캐릭터별로 색 변경하기
        //image.GetComponent<Image>().color = new Color32(255,255,225,100);
        UnityEngine.Color color = showEffectPanel.GetComponent<UnityEngine.UI.Image>().color;
        showEffectPanel.transform.localPosition = originPos;
        switch (num)
        {
            case 0:
                showEffectPanel.GetComponent<UnityEngine.UI.Image>().color = new Color32(113, 95, 154, 152);
                break;

            case 1:
                showEffectPanel.GetComponent<UnityEngine.UI.Image>().color = new Color32(154, 96, 95, 152);
                break;

            case 2:
                showEffectPanel.GetComponent<UnityEngine.UI.Image>().color = new Color32(87, 68, 48, 152);
                break;

        } //  색변경로직
        float startTime = Time.time;
        while(Time.time-  startTime < 0.1)
        {
            showEffectPanel.transform.localPosition +=new Vector3(6000 * effectTime * Time.deltaTime, 0, 0);
            
             yield return null;
        }
        
        startTime = Time.time;
        while (Time.time - startTime < 0.1)
        {
            showEffectPanel.transform.localPosition -= new Vector3(5000* effectTime * Time.deltaTime, 0, 0);
            yield return null;
        }
        showEffectPanel.transform.localPosition = originPos;
       // Debug.Log("CurrentPos : " + showEffectPanel.transform.localPosition.x);
    }
}
