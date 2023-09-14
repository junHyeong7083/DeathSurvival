using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 1~6�� ���� ������ �迭
    public int maxMonsters = 10; // �ִ� ���� ��
    private List<GameObject>[] monsterPools; // ���� Ǯ �迭
    private int currentMonsterNumber = 1; // ���� ���� ��ȣ

    private Coroutine currentSpawnCoroutine; // ���� ���� ���� �ڷ�ƾ�� �����ϱ� ���� ����

    private void Start()
    {
        // ���� Ǯ �迭 �ʱ�ȭ
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();

            // ���� ������ ���� �ʱ�ȭ
            for (int j = 0; j < maxMonsters; j++)
            {
                GameObject monster = Instantiate(monsterPrefabs[i]);
                monster.SetActive(false); // ��Ȱ��ȭ ���·� ����
                monsterPools[i].Add(monster);
            }
        }

        // ������ �� ù ��° ���� Ȱ��ȭ
        currentSpawnCoroutine = StartCoroutine(SpawnMonster(1f, currentMonsterNumber));
    }

    float currentTime;
    public float standardTime;
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
                currentSpawnCoroutine = StartCoroutine(SpawnMonster(1f, currentMonsterNumber));
            }
        }
    }

    private IEnumerator SpawnMonster(float delay, int monsterNumber)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            // ��Ȱ��ȭ�� ���� ã��
            GameObject inactiveMonster = monsterPools[monsterNumber - 1].Find(monster => !monster.activeSelf);

            if (inactiveMonster != null)
            {
                // Ȱ��ȭ �� ��ġ ����
                inactiveMonster.SetActive(true);
                inactiveMonster.transform.position = GetRandomSpawnPosition();
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // ������ ���� ��ġ ��ȯ (���� ȭ�� ���� ������ ��ġ�� �����ؾ� ��)
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector3(x, y, 0f);
    }
}
