using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject[] BloodObj; // 다양한 피 오브젝트 프리팹
    private List<List<GameObject>> monsterBloodPools = new List<List<GameObject>>(); // 여러 개의 피 풀
    private Transform BloodParent; // 부모 오브젝트

    void Start()
    {
        BloodParent = new GameObject("BloodParent").transform;

        // 4개의 피 풀 초기화
        for (int i = 0; i < BloodObj.Length; i++)
        {
            monsterBloodPools.Add(new List<GameObject>());
            InitBloodPool(monsterBloodPools[i], BloodObj[i]);
        }
    }

    /// <summary>
    /// 피 오브젝트 풀 초기화
    /// </summary>
    void InitBloodPool(List<GameObject> bloodPool, GameObject bloodPrefab)
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject blood = Instantiate(bloodPrefab, BloodParent);
            blood.SetActive(false);
            bloodPool.Add(blood);
        }
    }

    /// <summary>
    /// 몬스터 피 이펙트 스폰
    /// </summary>
    public void SpawnMonsterBlood(float x, float y)
    {
        int randomIndex = Random.Range(0, monsterBloodPools.Count);
        GameObject inactiveBlood = monsterBloodPools[randomIndex].Find(blood => !blood.activeSelf);

        if (inactiveBlood != null)
        {
            ActivateBloodEffect(inactiveBlood, x, y);
        }
    }

    /// <summary>
    /// 피 이펙트를 활성화하는 함수
    /// </summary>
    private void ActivateBloodEffect(GameObject blood, float x, float y)
    {
        blood.SetActive(true);
        blood.transform.position = new Vector3(x, y, 0);
        blood.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 361));

        Animator anim = blood.GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("isBlood");
        }
    }
}
