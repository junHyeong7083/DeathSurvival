using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKeyboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    bool isClick;
    float delayClick;
    float changeTime = 2f;
    int currentIndex = 0;
    Vector3 targetPosition;
    //  float movementSpeed = 2.0f; // �̵� �ӵ� ����

    public GameObject[] showPaenl;

    void Start()
    {
        scrollRect.content.localPosition = new Vector3(0, 0, 0);
        delayClick = 0f;
        isClick = false;
        targetPosition = scrollRect.content.localPosition;
    }

    Vector3 prePos;

    void Update()
    {
        if (!isClick)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentIndex > 0)
                {
                    isClick = true;
                    currentIndex--;
                }
                else
                    isClick = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentIndex < 2)
                {
                    isClick = true;
                    currentIndex++;
                }
                else
                    isClick = false;
            }
        }

        if (isClick)
        {
            delayClick += Time.deltaTime;
            if (delayClick > 0.7f)
            {
                delayClick = 0f;
                isClick = false;
            }
        }

        // ���� ��ġ�� ��ǥ ��ġ ���̸� �ε巴�� �̵�
        scrollRect.content.localPosition = Vector3.Lerp(scrollRect.content.localPosition, targetPosition, (changeTime * 9) * Time.deltaTime);

        // �̵��� �Ϸ�Ǹ� ��ǥ ��ġ�� ����
        if (Vector3.Distance(scrollRect.content.localPosition, targetPosition) < 0.01f)
        {
            scrollRect.content.localPosition = targetPosition;
            prePos = targetPosition;

            // �� �ε����� ���� ��ǥ ��ġ ����
            switch (currentIndex)
            {
                case 0:
                    targetPosition = new Vector3(0, 0, 0);
                    
                    for(int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    break;

                case 1:
                    targetPosition = new Vector3(-653.24f, 0, 0);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    break;

                case 2:
                    targetPosition = new Vector3(-1291.608f, 0, 0);
                    for (int e = 0; e < showPaenl.Length; ++e)
                    {
                        if (e == currentIndex)
                            showPaenl[e].SetActive(true);
                        else
                            showPaenl[e].SetActive(false);
                    }
                    break;
            }
        }
    }
}
