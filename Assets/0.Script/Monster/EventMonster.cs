using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventMonster : MonoBehaviour
{
    [Header("�̺�Ʈ ����")]
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

   
    

    void EventPattern(int _patternIndex) // ���� ���� �����Լ�
    {
        switch(_patternIndex)
        {
            case 0: // ���ʿ��� ����
                EventMonsterPositionSet(2, 0);
                break;

            case 1: // ���ʿ��� ����
                EventMonsterPositionSet(2, 1);
                break;

            case 2: // �Ʒ����� ����
                EventMonsterPositionSet(2, 2);
                break;

            case 3: // �����ʿ��� ����
                EventMonsterPositionSet(2, 3);
                break;
                
        }
    }


    void EventMonsterPositionSet(int posNum, int patternIndex)
    {
        switch(patternIndex)
        {
            case 0: // ��
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x - 7 + posNum, PlayerController.PlayerPos.y + 10f, 0); // ��
                    posNum += 2;

                }
                break;

            case 1: // ��
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x -15 , PlayerController.PlayerPos.y + 10f - posNum, 0); // ��
                    posNum += 2;

                }
                break;

            case 2: // ��
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x - 7 + posNum, PlayerController.PlayerPos.y - 10f, 0); // ��
                    posNum += 2;

                }
                break; 

            case 3: // ��
                for (int e = 0; e < monsterCount; ++e)
                {
                    monstersPool[e].gameObject.SetActive(true);
                    monstersPool[e].transform.position = new Vector3(PlayerController.PlayerPos.x + 10, PlayerController.PlayerPos.y + 15f - posNum, 0); // ��
                    posNum += 2;

                }
                break;

        }
      
    } // ���� ������ ����
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
