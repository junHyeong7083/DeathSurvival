using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBtn : MonoBehaviour
{
    SelectKeyboard selectKeyboard;
    public GameObject showEffectPanel;
    public float effectTime;
    Vector3 originPos = new Vector3(870, 0, 0);
    IEnumerator panelEffect(int num)
    {
        // 캐릭터별로 색 변경하기
        //image.GetComponent<Image>().color = new Color32(255,255,225,100);
       // UnityEngine.Color color = showEffectPanel.GetComponent<UnityEngine.UI.Image>().color;
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
        while (Time.time - startTime < 0.1)
        {
            showEffectPanel.transform.localPosition += new Vector3(6000 * effectTime * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.1)
        {
            showEffectPanel.transform.localPosition -= new Vector3(5000 * effectTime * Time.deltaTime, 0, 0);
            yield return null;
        }
        showEffectPanel.transform.localPosition = originPos;
    }
    private void Start()
    {
        selectKeyboard = GetComponent<SelectKeyboard>();
    }

    public void rightBtn()
    {
        SelectKeyboard.currentIndex++;
        if (SelectKeyboard.currentIndex > 2)
        {
            SelectKeyboard.currentIndex = 0;
            SelectKeyboard.isClick = true;
        }
        else
        {
            SelectKeyboard.isClick = true;
        }
        StartCoroutine(panelEffect(SelectKeyboard.currentIndex));
    }

    public void leftBtn()
    {

        SelectKeyboard.currentIndex--;
        if (SelectKeyboard.currentIndex < 0)
        {
            SelectKeyboard.currentIndex = 2;
            SelectKeyboard.isClick = true;
        }
        else
        {
            SelectKeyboard.isClick = true;
        }
        StartCoroutine(panelEffect(SelectKeyboard.currentIndex));
    }

    public void onupBtn()
    {
      //  SelectKeyboard.isMouseuse = true;
        SelectKeyboard.selectBtn = 1;
        selectKeyboard.buttonOutlines[0].effectColor = Color.green;
        selectKeyboard.buttonOutlines[1].effectColor = Color.white;

        selectKeyboard.buttonSelects[0].gameObject.SetActive(true);
        selectKeyboard.buttonSelects[1].gameObject.SetActive(false);
    }
    public void outupBtn()
    {
        SelectKeyboard.isMouseuse = false;
    }
    public void ondownBtn()
    {
      //  SelectKeyboard.isMouseuse = true;
        SelectKeyboard.selectBtn = 0;
        selectKeyboard.buttonOutlines[0].effectColor = Color.white;
        selectKeyboard.buttonOutlines[1].effectColor = Color.green;


        selectKeyboard.buttonSelects[0].gameObject.SetActive(false);
        selectKeyboard.buttonSelects[1].gameObject.SetActive(true);
    }
    public void outdownBtn()
    {
        SelectKeyboard.isMouseuse = false;
    }
}
