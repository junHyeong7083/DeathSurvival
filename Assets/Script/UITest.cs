using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button[] firstBtn;
    public Image PlayerIcon;

    Image[] fristImage;
    Color[] fristColor;

    LineRenderer line;

    private void Awake()
    {
        fristImage = new Image[firstBtn.Length];
        fristColor = new Color[firstBtn.Length];

        for (int e = 0; e < firstBtn.Length; e++)
        {
            fristImage[e] = firstBtn[e].GetComponent<Image>();
            fristColor[e] = fristImage[e].color;
        }

        line = PlayerIcon.GetComponent<LineRenderer>();
        line.positionCount = firstBtn.Length; // 버튼 개수만큼 라인 렌더러의 점 개수를 설정합니다.
    }

    public void Test()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(ButtonName);

        for (int i = 0; i < firstBtn.Length; i++)
        {
            if (ButtonName != (i + 1).ToString())
            {
                Color newColor = fristColor[i];
                newColor.a = 0.3f;
                fristImage[i].color = newColor;
            }
        }
    }

    // RectTransform의 중점 좌표를 구하는 함수
    private Vector3 GetCenterPosition(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Vector3 center = (corners[0] + corners[2]) * 0.5f;
        return center;
    }
}
