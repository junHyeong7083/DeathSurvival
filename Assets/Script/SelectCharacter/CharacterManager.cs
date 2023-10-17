using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Character
{
    White, Blue, Green,Default
}

public class CharacterManager : MonoBehaviour
{
   public static CharacterManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null) return;
        DontDestroyOnLoad(gameObject);

    }

    public Character currentCharacter;
}
