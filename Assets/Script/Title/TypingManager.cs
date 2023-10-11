using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    public Text titleText; // �ν����Ϳ��� �ؽ�Ʈ ������Ʈ�� �Ҵ�
    public float typingSpeed = 0.1f; // �� ���ھ� ��Ÿ���� �ӵ�

    private string fullText;
    private bool isTyping = false;

    private void Start()
    {
        if (titleText != null)
        {
            fullText = titleText.text;
            titleText.text = ""; // �ʱ⿡�� �ؽ�Ʈ�� ����Ӵϴ�.
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

    // ���� Ÿ���� �߿� ��ŵ�ϰ� �ʹٸ� �Ʒ��� ���� ��ŵ �Լ��� �߰��� �� �ֽ��ϴ�.
    public void SkipTyping()
    {
        if (isTyping)
        {
            StopCoroutine(TypeText());
            titleText.text = fullText; // �ؽ�Ʈ�� ��� �ϼ��ǵ��� ����
            isTyping = false;
        }
    }
}

