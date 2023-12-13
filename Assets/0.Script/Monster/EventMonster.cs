using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventMonster : MonoBehaviour
{
    [Header("이벤트 몬스터")]
    public GameObject eventMonster;
    [SerializeField]
    int monsterCount;
    List<GameObject> monstersPool;

    [SerializeField]
    int starndardPantternNum;
    int checkPatternStart = 1;

    void Start()
    {
        monstersPool = new List<GameObject>();
        GameObject parentObj = new GameObject(eventMonster.name + "Parent");
        for(int e = 0; e < monsterCount; ++ e )
        {
            GameObject monster = Instantiate(eventMonster, parentObj.transform);
            monster.SetActive(false);
            monstersPool.Add(monster);
        }
    }

   
    

    void EventPattern(int _patternIndex) // 몬스터 패턴 실행함수
    {
        switch(_patternIndex)
        {
            case 0: // 위쪽에서 등장
                EventMonsterPositionSet(2, 0);
                break;

            case 1: // 왼쪽에서 등장
                EventMonsterPositionSet(2, 1);
                break;

            case 2: // 아래에서 등장
                EventMonsterPositionSet(2, 2);
                break;

            case 3: // 오른쪽에서 등장
                EventMonsterPositionSet(2, 3);
                break;
                
        }
    }


    void EventMonsterPositionSet(int posNum, int patternIndex)
    {
        switch(patternIndex)
        {
            case 0: // 위
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x - 7 + posNum, PlayerController.PlayerPos.y + 10f, 0); // 위
                    posNum += 2;

                }
                break;

            case 1: // 왼
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x -15 , PlayerController.PlayerPos.y + 10f - posNum, 0); // 위
                    posNum += 2;

                }
                break;

            case 2: // 아
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x - 7 + posNum, PlayerController.PlayerPos.y - 10f, 0); // 위
                    posNum += 2;

                }
                break; 

            case 3: // 오
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x + 10, PlayerController.PlayerPos.y + 15f - posNum, 0); // 위
                    posNum += 2;

                }
                break;

        }
      
    } // 몬스터 포지션 세팅
    public static int patternRandom;
    void Update()
    {
        if ((float)MonsterManager.huntMonsterCnt / starndardPantternNum == checkPatternStart)
        {
            Debug.Log("checkPatternStart : " +checkPatternStart);
            checkPatternStart++;

            patternRandom = Random.Range(0, 4);

            EventPattern(patternRandom);
        }


    }
}
