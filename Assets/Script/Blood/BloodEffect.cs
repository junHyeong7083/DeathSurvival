using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject BloodObj;
    private List<GameObject> monsterBloodPool;

    Transform BloodParent;

    void Start()
    {
        monsterBloodPool = new List<GameObject>();

        GameObject parentBlood = new GameObject(BloodObj.name + "Parent");
        BloodParent = parentBlood.transform;

        for (int e = 0; e < 200; ++e)
        {
            GameObject blood = Instantiate(BloodObj, BloodParent);
            blood.SetActive(false);
            monsterBloodPool.Add(blood);
        }
    }

    public void SpawnMonsterBlood(float x, float y)
    {
        GameObject inactiveMonsterBlood;
        inactiveMonsterBlood = monsterBloodPool.Find(blood => !blood.activeSelf);

        if (inactiveMonsterBlood != null)
        {
            inactiveMonsterBlood.SetActive(true);
            inactiveMonsterBlood.transform.localScale = new Vector3(randomX * 0.2f, randomY * 0.2f, 0);
            inactiveMonsterBlood.transform.rotation = Quaternion.Euler(0, 0, randomZ);
            inactiveMonsterBlood.GetComponent<Animator>().SetTrigger("isBlood"); // Blood 애니메이터 접근후 실행
            inactiveMonsterBlood.transform.position = new Vector3(x, y, 0);
        }
    }
    float randomX;
    float randomY;
    float randomZ;
    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(4, 9);
        randomY = Random.Range(2, 5);
        randomZ = Random.Range(1, 360);
    }
}
