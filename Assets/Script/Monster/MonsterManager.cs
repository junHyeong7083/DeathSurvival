using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 1~6번 몬스터 프리팹 배열
    public int maxMonsters = 10; // 최대 몬스터 수
    private List<GameObject>[] monsterPools; // 몬스터 풀 배열
    private int currentMonsterNumber = 1; // 현재 몬스터 번호

    private Coroutine currentSpawnCoroutine; // 현재 실행 중인 코루틴을 추적하기 위한 변수

    private void Start()
    {
        // 몬스터 풀 배열 초기화
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();

            // 몬스터 프리팹 별로 초기화
            for (int j = 0; j < maxMonsters; j++)
            {
                GameObject monster = Instantiate(monsterPrefabs[i]);
                monster.SetActive(false); // 비활성화 상태로 시작
                monsterPools[i].Add(monster);
            }
        }

        // 시작할 때 첫 번째 몬스터 활성화
        currentSpawnCoroutine = StartCoroutine(SpawnMonster(1f, currentMonsterNumber));
    }

    float currentTime;
    public float standardTime;
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime/ standardTime < monsterPrefabs.Length) // 정해진 몬스터 숫자내에서만 연산이되도록
        {
            if (currentTime / standardTime >= currentMonsterNumber)
            {
                // 이전 코루틴 중지
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

            // 비활성화된 몬스터 찾기
            GameObject inactiveMonster = monsterPools[monsterNumber - 1].Find(monster => !monster.activeSelf);

            if (inactiveMonster != null)
            {
                // 활성화 및 위치 설정
                inactiveMonster.SetActive(true);
                inactiveMonster.transform.position = GetRandomSpawnPosition();
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // 랜덤한 스폰 위치 반환 (게임 화면 내의 적절한 위치로 설정해야 함)
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector3(x, y, 0f);
    }
}
