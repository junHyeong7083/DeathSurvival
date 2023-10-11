using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    public Text titleText; // 인스펙터에서 텍스트 오브젝트를 할당
    public float typingSpeed = 0.1f; // 한 글자씩 나타나는 속도

    private string fullText;
    private bool isTyping = false;

    private void Start()
    {
        if (titleText != null)
        {
            fullText = titleText.text;
            titleText.text = ""; // 초기에는 텍스트를 비워둡니다.
            StartCoroutine(TypeText());
        }
    }

    private IEnumerator TypeText()
    {
        isTyping = true;
        foreach (char c in fullText)
        {
            titleText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    // 만약 타이핑 중에 스킵하고 싶다면 아래와 같이 스킵 함수를 추가할 수 있습니다.
    public void SkipTyping()
    {
        if (isTyping)
        {
            StopCoroutine(TypeText());
            titleText.text = fullText; // 텍스트를 즉시 완성되도록 설정
            isTyping = false;
        }
    }
}

