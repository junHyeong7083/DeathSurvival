using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject monsterPrefab1; // 1번 몬스터 프리팹
    public GameObject monsterPrefab2; // 2번 몬스터 프리팹

    private List<GameObject> monsterPool1 = new List<GameObject>();
    private List<GameObject> monsterPool2 = new List<GameObject>();

    public int poolSize;
    private bool isAfterOneMinute = false;

    private void Start()
    {
        InitializePool(monsterPrefab1, monsterPool1);
    }

    private void Update()
    {
        if (!isAfterOneMinute && Time.time >= 60f)
        {
            isAfterOneMinute = true;
            InitializePool(monsterPrefab2, monsterPool2);
        }
    }

    private void InitializePool(GameObject prefab, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject monster = Instantiate(prefab);
            monster.SetActive(false);
            pool.Add(monster);
        }
    }

    public void SpawnMonster(Vector3 position, int monsterType)
    {
        List<GameObject> pool = monsterType == 1 ? monsterPool1 : monsterPool2;
        GameObject monster = GetNextMonster(pool);

        if (monster != null)
        {
            monster.transform.position = position;
            monster.SetActive(true);
        }
    }

    private GameObject GetNextMonster(List<GameObject> pool)
    {
        foreach (var monster in pool)
        {
            if (!monster.activeInHierarchy)
            {
                return monster;
            }
        }
        return null;
    }
}
