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
        } // 1단계 set
        for (int e = 0; e < secondBtn.Length; e++)
        {
            secondImage[e] = secondBtn[e].GetComponent<Image>();
            secondColor[e] = secondImage[e].color;
        } // 2단계 set

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
    } // 게임시작할때 호출될 함수
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
    } // 두번째 필드 투명도 조절

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
                    playerLine.positionCount = 2; // 선은 두 개의 점1으로 이루어집니다.
                    playerLine.startWidth = 0.2f; // 선의 시작 너비
                    playerLine.endWidth = 0.2f; // 선의 끝 너비
                  //  playerLine.startColor = Color.white; // 선의 시작 색상
                  //  playerLine.endColor = Color.white; // 선의 끝 색상

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
                    firstBtnLine.positionCount = 2; // 선은 두 개의 점으로 이루어집니다.
                    firstBtnLine.startWidth = 0.2f; // 선의 시작 너비
                    firstBtnLine.endWidth = 0.2f; // 선의 끝 너비
                 //   firstBtnLine.startColor = Color.white; // 선의 시작 색상
                 //   firstBtnLine.endColor = Color.white; // 선의 끝 색상
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
