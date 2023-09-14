using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 1~6번 몬스터 프리팹 배열
    public int maxMonsters = 10; // 최대 몬스터 수
    private List<GameObject>[] monsterPools; // 몬스터 풀 배열
    private int currentMonsterNumber = 1; // 현재 몬스터 번호

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
        StartCoroutine(SpawnMonster(1f, currentMonsterNumber));
    }

    private void Update()
    {
        // 게임 진행 중일 때 여기서 게임 로직을 추가할 수 있습니다.
    }

    private IEnumerator SpawnMonster(float delay, int monsterNumber)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);

            // 비활성화된 몬스터 찾기
            GameObject inactiveMonster = monsterPools[monsterNumber - 1].Find(monster => !monster.activeSelf);

            if (inactiveMonster != null)
            {
                Debug.Log("생성");
                // 활성화 및 위치 설정
                inactiveMonster.SetActive(true);
                inactiveMonster.transform.position = GetRandomSpawnPosition();
            }
            Debug.Log("가득");

            // 다음 몬스터 스폰
            int nextMonsterNumber = (monsterNumber % monsterPrefabs.Length) + 1;
            StartCoroutine(SpawnMonster(60f, nextMonsterNumber)); // 60초 후에 다음 몬스터 스폰
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
