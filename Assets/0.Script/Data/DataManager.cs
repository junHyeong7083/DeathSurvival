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
    public LevelData[] Level; // ��Ʈ�̸��� �����ؾ���
}
[System.Serializable]
public class LevelData
{
    public int Level; // ��Ʈ�� �������Ŷ� �Ȱ���
    public int Experience;
}