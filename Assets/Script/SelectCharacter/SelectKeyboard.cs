using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SelectKeyboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    public static bool isClick;
    float delayClick;
    float changeTime = 2f;
    public static int currentIndex;
    Vector3 targetPosition;
    //  float movementSpeed = 2.0f; // �̵� �ӵ� ����
    public GameObject[] showPaenl;

    void Start()
    {
        CharacterManager.Instance.currentCharacter = default;
        currentIndex = 0;
        scrollRect.content.localPosition = new Vector3(0, 0, 0);
        delayClick = 0f;
        isClick = false;
        targetPosition = scrollRect.content.localPosition;
        prePos = new Vector3(0, 0, 0);
        for (int e = 0; e < showPaenl.Length; ++e)
        {
            showPaenl[e].gameObject.SetActive(false);
        }
    }

    Vector3 prePos;

    void Update()
    {
        //Debug.Log("current : " + currentIndex);

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




        // ���� ��ġ�� ��ǥ ��ġ ���̸� �ε巴�� �̵�
     //   scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
     //   scrollRect.content.localPosition = targetPosition;
        // �� �ε����� ���� ��ǥ ��ġ ����
        switch (currentIndex)
        {
            case 0:
                targetPosition = new Vector3(0, 0, 0);
           
              //  prePos = scrollRect.content.localPosition;
                Debug.Log("targ0 : " + targetPosition.x);
                Debug.Log("pre0 : " + prePos.x);
                scrollRect.content.localPosition = Vector3.Lerp(prePos, targetPosition, (changeTime * 9) * Time.deltaTime);
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
             //   prePos = scrollRect.content.localPosition;
                Debug.Log("targ1 : " + targetPosition.x);
                Debug.Log("pre1 : " + prePos.x);
                scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
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
                Debug.Log("targ2 : " + targetPosition.x);
                Debug.Log("pre2 : " + prePos.x);
                scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);
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
