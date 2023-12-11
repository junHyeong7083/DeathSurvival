using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 몬스터 프리팹 배열
    public int[] maxMonsters; // 최대 몬스터 수
    private List<GameObject>[] monsterPools; // 몬스터 풀 배열

    public GameObject monsterItem;
    private List<GameObject> monsterItemsPool;
    private int currentMonsterNumber = 1; // 현재 몬스터 번호

    private Coroutine currentSpawnCoroutine; // 현재 실행 중인 코루틴

    #region SpawnTime
    public float spawndelayTime;
    [SerializeField]
    float currentTime;
    public float standardTime;
    #endregion

    #region SpawnPos
    public float spawnPosX1, spawnPosX2, spawnPosY1, spawnPosY2;
    #endregion

    private Transform monsterParent;
    private Transform monsterItemParent;
    private void Start()
    {
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        monsterItemsPool = new List<GameObject>();
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();

            // 몬스터를 담을 부모 오브젝트 생성
            GameObject parentObject = new GameObject(monsterPrefabs[i].name + " Parent");
            monsterParent = parentObject.transform;


            for (int j = 0; j < maxMonsters[i]; j++)
            {
                GameObject monster = Instantiate(monsterPrefabs[i], monsterParent);
                monster.SetActive(false);
                monsterPools[i].Add(monster);
            }
        }
        GameObject parentItemObject = new GameObject(monsterItem.name + " Parent");
        for (int e = 0; e < 200; ++e)
        {
            monsterItemParent = parentItemObject.transform;
            GameObject Item = Instantiate(monsterItem, monsterItemParent);
            Item.SetActive(false);
            monsterItemsPool.Add(Item);
        }

        currentSpawnCoroutine = StartCoroutine(SpawnMonster(spawndelayTime, currentMonsterNumber, currentMonsterNumber + 1));
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime / standardTime < monsterPrefabs.Length) // 정해진 몬스터 숫자내에서만 연산이되도록
        {
            if (currentTime / standardTime >= currentMonsterNumber)
            {
                // 이전 코루틴 중지
                if (currentSpawnCoroutine != null)
                {
                    StopCoroutine(currentSpawnCoroutine);
                }

                currentMonsterNumber++;
                currentSpawnCoroutine = StartCoroutine(SpawnMonster(spawndelayTime, currentMonsterNumber, currentMonsterNumber + 1));
            }
        }



    }


    private IEnumerator SpawnMonster(float delay, int monsterNumber, int nextmonterNumber)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            GameObject inactiveMonster;
            GameObject inactiveNextMonster;
            inactiveMonster = monsterPools[monsterNumber - 1].Find(monster => !monster.activeSelf);
            if (inactiveMonster != null)
            {
                inactiveMonster.SetActive(true);
                inactiveMonster.transform.position = GetRandomSpawnPosition();
            }

            if (nextmonterNumber <= monsterPrefabs.Length - 1)
            {
                inactiveNextMonster = monsterPools[nextmonterNumber].Find(monster => !monster.activeSelf);
                if (inactiveNextMonster != null)
                {
                    inactiveNextMonster.SetActive(true);
                    inactiveNextMonster.transform.position = GetRandomSpawnPosition();
                }
            }
         

        }

    }
    public void SpawnMonsterItem(float x, float y)
    {
        GameObject inactiveMonsterItem;
        inactiveMonsterItem = monsterItemsPool.Find(monsterItem => !monsterItem.activeSelf);

        if (inactiveMonsterItem != null)
        {
            inactiveMonsterItem.SetActive(true);
            inactiveMonsterItem.transform.position = new Vector3(x, y, 0);
        }
    }


    private Vector3 GetRandomSpawnPosition()
    {
        float x1 = Random.Range(PlayerController.PlayerPos.x - spawnPosX1, PlayerController.PlayerPos.x - spawnPosX2);
        float x2 = Random.Range(PlayerController.PlayerPos.x + spawnPosX1, PlayerController.PlayerPos.x + spawnPosX2);

        float y1 = Random.Range(PlayerController.PlayerPos.y - spawnPosY1, PlayerController.PlayerPos.x - spawnPosY2);
        float y2 = Random.Range(PlayerController.PlayerPos.y + spawnPosY1, PlayerController.PlayerPos.x + spawnPosY2);

        float X, Y;

        #region Respone Pos Set
        if (Random.value < 0.5f)
        {
            X = x1;
        }
        else
        {
            X = x2;
        }

        if (Random.value < 0.5f)
        {
            Y = y1;
        }
        else
        {
            Y = y2;
        }
        #endregion
        return new Vector3(X, Y, 0f);
    }
}
