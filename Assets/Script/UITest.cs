using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button[] firstBtn;
    public Button[] secondBtn;


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
        while(Time.time - startTime < 1.0f)
        {
            for(int e = 0; e < firstBtn.Length; ++e)
            {
                firstColor[e].a = (Time.time - startTime) / 1f;

                firstImage[e].color = firstColor[e];
            }

            yield return null;
        }
    } // 게임시작할때 호출될 함수
    IEnumerator SecondFiledSkill()
    {
        float startTime = Time.time;
        while(Time.time - startTime < 1.0f)
        {
            for (int e = 0; e < secondBtn.Length; ++e)
            {
                secondColor[e].a = (Time.time - startTime) / 1f;

                secondImage[e].color = secondColor[e];
            }
            yield return null;
        }
    }

    public void PointOneSkill()
    {
        if(canFirst)
        {
            string ButtonName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(ButtonName);

            for (int i = 0; i < firstBtn.Length; i++)
            {
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
        if(canSecond)
        {
            string ButtonName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(ButtonName);

            for (int i = 0; i < secondBtn.Length; i++)
            {
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
