using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ���� ������ �迭

    public int maxMonsters = 10; // �ִ� ���� ��

    private List<GameObject>[] monsterPools; // ���� Ǯ �迭

    private int currentMonsterNumber = 1; // ���� ���� ��ȣ

    private Coroutine currentSpawnCoroutine; // ���� ���� ���� �ڷ�ƾ

    #region SpawnTime
    public float spawndelayTime;
    [SerializeField]
    float currentTime;
    public float standardTime;
    #endregion

    #region SpawnPos
    public float spawnPosX1, spawnPosX2, spawnPosY1, spawnPosY2;
    #endregion
    private void Start()
    {
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();

            for (int j = 0; j < maxMonsters; j++)
            {
                GameObject monster = Instantiate(monsterPrefabs[i]);
                monster.SetActive(false); // ��Ȱ��ȭ 
                monsterPools[i].Add(monster);
            }
        }
        currentSpawnCoroutine = StartCoroutine(SpawnMonster(spawndelayTime, currentMonsterNumber));
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime/ standardTime < monsterPrefabs.Length) // ������ ���� ���ڳ������� �����̵ǵ���
        {
            if (currentTime / standardTime >= currentMonsterNumber)
            {
                // ���� �ڷ�ƾ ����
                if (currentSpawnCoroutine != null)
                {
                    StopCoroutine(currentSpawnCoroutine);
                }

                currentMonsterNumber++;
                currentSpawnCoroutine = StartCoroutine(SpawnMonster(spawndelayTime, currentMonsterNumber));
            }
        }
    }

    private IEnumerator SpawnMonster(float delay, int monsterNumber)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            GameObject inactiveMonster = monsterPools[monsterNumber - 1].Find(monster => !monster.activeSelf);
            float hp = inactiveMonster.GetComponent<MonsterController>().Hp;
            if (inactiveMonster != null)
            {
                hp = 100f;
                inactiveMonster.SetActive(true);
                inactiveMonster.transform.position = GetRandomSpawnPosition();
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x1 = Random.Range(PlayerController.PlayerPos.x - spawnPosX1, PlayerController.PlayerPos.x - spawnPosX2);
        float x2 = Random.Range(PlayerController.PlayerPos.x + spawnPosX1, PlayerController.PlayerPos.x + spawnPosX2);

        float y1 = Random.Range(PlayerController.PlayerPos.y - spawnPosY1, PlayerController.PlayerPos.x - spawnPosY2);
        float y2 = Random.Range(PlayerController.PlayerPos.y + spawnPosY1, PlayerController.PlayerPos.x + spawnPosY2);

        float X,Y;
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
            Y = x1;
        }
        else
        {
            Y = x2;
        }

        return new Vector3(X, Y, 0f);
    }
}
