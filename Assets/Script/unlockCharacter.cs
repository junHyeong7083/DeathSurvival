using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockCharacter : MonoBehaviour
{
    public void CharBeventFuc()
    {
        PlayerPrefs.SetFloat("CharacterB", 1.5f);
        Debug.Log("1.5");
    }

    public void CharCeventFuc()
    {
        PlayerPrefs.SetFloat("CharacterC", 2.5f);
        Debug.Log("2.5");
    }

    public void unlockCharB()
    {
        PlayerPrefs.SetFloat("CharacterB", 1.5f);
    }

    public void unlockCharC()
    {
        PlayerPrefs.SetFloat("CharacterC", 2.5f);
    }

    public void allKeyInit()
    {
        PlayerPrefs.DeleteAll();
    }
}
