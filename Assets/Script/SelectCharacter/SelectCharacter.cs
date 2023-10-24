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

        if (CharacterManager.Instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        CharacterManager.Instance.currentCharacter = character;
        OnSelect();

        for(int e = 0; e<Chars.Length; ++e)
        {
            if (Chars[e] != this)
                Chars[e].OnDeSelect();

            if (Chars[e] == this)
                currentIndex = e;
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
