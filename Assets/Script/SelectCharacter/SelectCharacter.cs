using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public Character character;

    public static int selectNum = 0;

    public SelectCharacter[] Chars;
    public GameObject[] Panels;

    SpriteRenderer spriteRenderer;
    int currentIndex;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (DataManager.Instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.Instance.currentCharacter = character;
        OnSelect();

        for(int e = 0; e<Chars.Length; ++e)
        {
            if (Chars[e] != this)
                Chars[e].OnDeSelect();

            if (Chars[e] == this)
                currentIndex = e;
        }

        switch (currentIndex)
        {
            case 0:
                selectNum = 1;
                Panels[0].gameObject.SetActive(true);
                Panels[1].gameObject.SetActive(false);
                Panels[2].gameObject.SetActive(false);
                break;

            case 1:
                selectNum = 2;
                Panels[0].gameObject.SetActive(false);
                Panels[1].gameObject.SetActive(true);
                Panels[2].gameObject.SetActive(false);
                break;

            case 2:
                selectNum = 3;
                Panels[0].gameObject.SetActive(false);
                Panels[1].gameObject.SetActive(false);
                Panels[2].gameObject.SetActive(true);
                break;

        }
    }
    void OnSelect()
    {
        spriteRenderer.color = new Color(1f,1f,1f);
    }
    void OnDeSelect()
    {
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
