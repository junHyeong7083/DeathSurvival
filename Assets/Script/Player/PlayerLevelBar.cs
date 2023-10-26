using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelBar : MonoBehaviour
{
    Text levelTxt;
    Image hpImage; // hpImage 컴포넌트 추가

    DataManager dataManager;

    public static int CheckingLevel; 
    int currentLevel;
    float currentExperience;
    float currentLevelMaxExperience; // 현재 레벨의 최대 경험치
    float someAmount; // 아이템을 먹을 때 얻는 경험치 양

    float minValue;
    float maxValue;

    void Start()
    {
        levelTxt = GameObject.Find("LevelText").GetComponent<Text>();
        hpImage = GameObject.Find("LevelhpImage").GetComponent<Image>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        // 초기 레벨 및 경험치 설정
        currentLevel = 1;
        CheckingLevel = currentLevel;
        currentExperience = 0;

        someAmount = 30 + 10 * (Timer / 30); // 임시로 30으로 설정후 30초마다 10씩 증가함

        // 현재 레벨의 최대 경험치 설정
        LevelData currentLevelData = GetLevelData(currentLevel + 1);
        if (currentLevelData != null)
        {
            currentLevelMaxExperience = currentLevelData.Experience;
            // 초기 minValue와 maxValue 설정
            minValue = 0;
            maxValue = currentLevelMaxExperience;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            currentExperience += someAmount;

            // 게이지 값 변경
            float fillAmount = (currentExperience / maxValue);
            hpImage.fillAmount = fillAmount;

            CheckLevelUp();
        }
    }

    void CheckLevelUp()
    {
        if (currentExperience >= currentLevelMaxExperience)
        {
            // 레벨 업 조건 충족
            currentLevel++;
            CheckingLevel = currentLevel;
            // 다음 레벨의 경험치 양으로 초기화
            LevelData nextLevelData = GetLevelData(currentLevel + 1);
            if (nextLevelData != null)
            {
                currentExperience = 0;
                currentLevelMaxExperience = nextLevelData.Experience;

                minValue = GetLevelData(currentLevel).Experience;
                maxValue = currentLevelMaxExperience;
            }

            // 레벨 업 이벤트 실행 또는 UI 업데이트 등을 수행할 수 있음
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
