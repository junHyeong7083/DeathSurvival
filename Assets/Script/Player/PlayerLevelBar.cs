using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelBar : MonoBehaviour
{
    Text levelTxt;
    Image hpImage; // hpImage ������Ʈ �߰�

    DataManager dataManager;

    public static int CheckingLevel; 
    int currentLevel;
    float currentExperience;
    float currentLevelMaxExperience; // ���� ������ �ִ� ����ġ
    float someAmount; // �������� ���� �� ��� ����ġ ��

    float minValue;
    float maxValue;

    void Start()
    {
        levelTxt = GameObject.Find("LevelText").GetComponent<Text>();
        hpImage = GameObject.Find("LevelhpImage").GetComponent<Image>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        // �ʱ� ���� �� ����ġ ����
        currentLevel = 1;
        CheckingLevel = currentLevel;
        currentExperience = 0;

        someAmount = 30 + 10 * (Timer / 30); // �ӽ÷� 30���� ������ 30�ʸ��� 10�� ������

        // ���� ������ �ִ� ����ġ ����
        LevelData currentLevelData = GetLevelData(currentLevel + 1);
        if (currentLevelData != null)
        {
            currentLevelMaxExperience = currentLevelData.Experience;
            // �ʱ� minValue�� maxValue ����
            minValue = 0;
            maxValue = currentLevelMaxExperience;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            currentExperience += someAmount;

            // ������ �� ����
            float fillAmount = (currentExperience / maxValue);
            hpImage.fillAmount = fillAmount;

            CheckLevelUp();
        }
    }

    void CheckLevelUp()
    {
        if (currentExperience >= currentLevelMaxExperience)
        {
            // ���� �� ���� ����
            currentLevel++;
            CheckingLevel = currentLevel;
            // ���� ������ ����ġ ������ �ʱ�ȭ
            LevelData nextLevelData = GetLevelData(currentLevel + 1);
            if (nextLevelData != null)
            {
                currentExperience = 0;
                currentLevelMaxExperience = nextLevelData.Experience;

                minValue = GetLevelData(currentLevel).Experience;
                maxValue = currentLevelMaxExperience;
            }

            // ���� �� �̺�Ʈ ���� �Ǵ� UI ������Ʈ ���� ������ �� ����
        }
    }

    LevelData GetLevelData(int level)
    {
        foreach (LevelData levelData in dataManager.levels.Level)
        {
            if (levelData.Level == level)
            {
                return levelData;
            }
        }
        return null;
    }

    float Timer = 0f;
    private void Update()
    {
        levelTxt.text = "Level : " + currentLevel.ToString();

        Timer += Time.deltaTime;
    }
}
