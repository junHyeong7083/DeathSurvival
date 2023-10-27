using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectKeyboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    public static bool isClick;
    float changeTime = 2f;
    public static int currentIndex;
    Vector3 targetPosition = new Vector3(0,0,0);
    //  float movementSpeed = 2.0f; // 이동 속도 조절
    public GameObject[] showPaenl;

    void Start()
    {
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
                targetPosition =new Vector3(-653.24f, 0, 0);
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
    }
}
