using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject[] BloodObj; // �پ��� �� ������Ʈ ������
    private List<List<GameObject>> monsterBloodPools = new List<List<GameObject>>(); // ���� ���� �� Ǯ
    private Transform BloodParent; // �θ� ������Ʈ

    void Start()
    {
        BloodParent = new GameObject("BloodParent").transform;

        // 4���� �� Ǯ �ʱ�ȭ
        for (int i = 0; i < BloodObj.Length; i++)
        {
            monsterBloodPools.Add(new List<GameObject>());
            InitBloodPool(monsterBloodPools[i], BloodObj[i]);
        }
    }

    /// <summary>
    /// �� ������Ʈ Ǯ �ʱ�ȭ
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
    /// ���� �� ����Ʈ ����
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
    /// �� ����Ʈ�� Ȱ��ȭ�ϴ� �Լ�
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
