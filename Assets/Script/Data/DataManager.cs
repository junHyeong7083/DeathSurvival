using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public TextAsset data;
    public AllLevel levels;

    public static int currentLevel;
    private void Awake()
    {
         levels =  JsonUtility.FromJson<AllLevel>(data.text);
        currentLevel = 1;
    }
}
[System.Serializable]
public class AllLevel
{
    public LevelData[] Level; // 시트이름과 동일해야함
}
[System.Serializable]
public class LevelData
{
    public int Level; // 시트에 적었던거랑 똑같이
    public int Experience;
}