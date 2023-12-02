using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button[] firstBtn;
    public Button[] secondBtn;

    RectTransform lastClickBtn;
    int lastClickIndex;

    public Image PlayerIcon;

    Image[] firstImage;
    Color[] firstColor;

    Image[] secondImage;
    Color[] secondColor;

    public int skillPoint;
    public Text skillPointTxt;

    bool canFirst = true;
    bool canSecond= true;
    private void Start()
    {
        StartCoroutine(SkillStartSet());


    }


    IEnumerator SkillStartSet()
    {
        firstImage = new Image[firstBtn.Length];
        firstColor = new Color[firstBtn.Length];

        secondImage = new Image[secondBtn.Length];
        secondColor = new Color[secondBtn.Length];


        for (int e = 0; e < firstBtn.Length; e++)
        {
            firstImage[e] = firstBtn[e].GetComponent<Image>();
            firstColor[e] = firstImage[e].color;
        } // 1�ܰ� set
        for (int e = 0; e < secondBtn.Length; e++)
        {
            secondImage[e] = secondBtn[e].GetComponent<Image>();
            secondColor[e] = secondImage[e].color;
        } // 2�ܰ� set

        float startTime = Time.time;
        while(Time.time - startTime < 0.5f)
        {
            for(int e = 0; e < firstBtn.Length; ++e)
            {
                firstColor[e].a = (Time.time - startTime) / 0.5f;

                firstImage[e].color = firstColor[e];
            }

            yield return null;
        }
    } // ���ӽ����Ҷ� ȣ��� �Լ�
    IEnumerator SecondFiledSkill()
    {
        float startTime = Time.time;
        while(Time.time - startTime < 0.5f)
        {
            for (int e = 0; e < secondBtn.Length; ++e)
            {
                secondColor[e].a = (Time.time - startTime) / 0.5f;

                secondImage[e].color = secondColor[e];
            }
            yield return null;
        }
    } // �ι�° �ʵ� ���� ����

    public void PointOneSkill()
    {
        if(canFirst)
        {
            string ButtonName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(ButtonName);

            for (int i = 0; i < firstBtn.Length; i++)
            {
                if(ButtonName == (i+1).ToString())
                {  
                    LineRenderer playerLine = PlayerIcon.GetComponent<LineRenderer>();
                    playerLine.positionCount = 2; // ���� �� ���� ��1���� �̷�����ϴ�.
                    playerLine.startWidth = 0.2f; // ���� ���� �ʺ�
                    playerLine.endWidth = 0.2f; // ���� �� �ʺ�
                  //  playerLine.startColor = Color.white; // ���� ���� ����
                  //  playerLine.endColor = Color.white; // ���� �� ����

                    /*     Vector3 firstPos = PlayerIcon.rectTransform.position;
                         Vector3 secondPos = firstBtn[i].rectTransform.position; */
                    Vector3 firstPos =( PlayerIcon.rectTransform.position);

                    RectTransform rect = firstBtn[i].GetComponent<RectTransform>();
                    Vector3 secondPos = ( rect.position);
                  //  RectTransformUtility.WorldToScreenPoint(null, secondPos);

                    playerLine.SetPosition(0, firstPos);
                    playerLine.SetPosition(1, secondPos);
                    lastClickIndex = i;
                    Debug.Log("index : " + lastClickIndex);
                }

                if (ButtonName != (i + 1).ToString())
                {
                    Color newColor = firstColor[i];
                    newColor.a = 0.2f;
                    firstImage[i].color = newColor;
                }
            }

            StartCoroutine(SecondFiledSkill());
            canFirst = false;
            skillPoint -= 1;
        }
    }

    public void PointTwoSkill()
    {
        if(canSecond && !canFirst)
        {
            string ButtonName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(ButtonName);

            for (int i = 0; i < secondBtn.Length; i++)
            {
                if(ButtonName == (i+1).ToString())
                {
                    LineRenderer firstBtnLine = firstBtn[lastClickIndex].GetComponent<LineRenderer>();
                    firstBtnLine.positionCount = 2; // ���� �� ���� ������ �̷�����ϴ�.
                    firstBtnLine.startWidth = 0.2f; // ���� ���� �ʺ�
                    firstBtnLine.endWidth = 0.2f; // ���� �� �ʺ�
                 //   firstBtnLine.startColor = Color.white; // ���� ���� ����
                 //   firstBtnLine.endColor = Color.white; // ���� �� ����
                                                       //    Vector3 firstPos =( PlayerIcon.rectTransform.position);

                    //  Vector3 firstPos = (PlayerIcon.rectTransform.position);
                    //  RectTransform rect = firstBtn[i].GetComponent<RectTransform>();
                    //
                    //  Vector3 secondPos = (rect.position);



                    RectTransform rectfirst = firstBtn[lastClickIndex].GetComponent<RectTransform>();
                    Vector3 firstPos = rectfirst.position;

                    RectTransform rect = secondBtn[i].GetComponent<RectTransform>();
                    Vector3 secondPos =rect.position;

                    firstBtnLine.SetPosition(0, firstPos);
                    firstBtnLine.SetPosition(1, secondPos);

                    lastClickIndex = i;
                }

                if (ButtonName != (i + 1).ToString())
                {
                    Color newColor = secondColor[i];
                    newColor.a = 0.2f;
                    secondImage[i].color = newColor;
                }
            }

            canSecond = false;
            skillPoint -= 2;
        }
        

    }

    private void Update()
    {
        skillPointTxt.text = "Point : " + skillPoint.ToString();


    }


}
