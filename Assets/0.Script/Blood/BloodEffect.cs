using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject[] BloodObj;
    private List<GameObject> monsterBloodPool1;
    private List<GameObject> monsterBloodPool2;
    private List<GameObject> monsterBloodPool3;
    private List<GameObject> monsterBloodPool4;

    Transform BloodParent;

    void Start()
    {
        monsterBloodPool1 = new List<GameObject>();
        monsterBloodPool2 = new List<GameObject>();
        monsterBloodPool3 = new List<GameObject>();
        monsterBloodPool4 = new List<GameObject>();

        GameObject parentBlood = new GameObject( "BloodParent");
        BloodParent = parentBlood.transform;

        for (int e = 0; e < 50; ++e)
        {
            GameObject blood1 = Instantiate(BloodObj[0], BloodParent);
            blood1.SetActive(false);
            monsterBloodPool1.Add(blood1);
        }
        for (int e = 0; e < 50; ++e)
        {
            GameObject blood2 = Instantiate(BloodObj[1], BloodParent);
            blood2.SetActive(false);
            monsterBloodPool2.Add(blood2);
        }
        for (int e = 0; e < 50; ++e)
        {
            GameObject blood3 = Instantiate(BloodObj[2], BloodParent);
            blood3.SetActive(false);
            monsterBloodPool3.Add(blood3);
        }
        for (int e = 0; e < 50; ++e)
        {
            GameObject blood4 = Instantiate(BloodObj[3], BloodParent);
            blood4.SetActive(false);
            monsterBloodPool4.Add(blood4);
        }

    }

    public void SpawnMonsterBlood(float x, float y)
    {
        int randomBlood = Random.Range(0, 4);  // 0 1 2 3 4 
        GameObject inactiveMonsterBlood;
        switch (randomBlood)
        {
            case 0:
                inactiveMonsterBlood = monsterBloodPool1.Find(blood1 => !blood1.activeSelf);
                if (inactiveMonsterBlood != null)
                {
                    inactiveMonsterBlood.SetActive(true);
                    inactiveMonsterBlood.GetComponent<Animator>().SetTrigger("isBlood"); // Blood 애니메이터 접근후 실행
                    inactiveMonsterBlood.transform.position = new Vector3(x, y, 0);
                }
                break;

             case 1:
                inactiveMonsterBlood = monsterBloodPool2.Find(blood2 => !blood2.activeSelf);
                if (inactiveMonsterBlood != null)
                {
                    inactiveMonsterBlood.SetActive(true);
                    inactiveMonsterBlood.GetComponent<Animator>().SetTrigger("isBlood"); // Blood 애니메이터 접근후 실행
                    inactiveMonsterBlood.transform.position = new Vector3(x, y, 0);
                }
                break;

            case 2:
                inactiveMonsterBlood = monsterBloodPool3.Find(blood3 => !blood3.activeSelf);
                if (inactiveMonsterBlood != null)
                {
                    inactiveMonsterBlood.SetActive(true);
                    inactiveMonsterBlood.GetComponent<Animator>().SetTrigger("isBlood"); // Blood 애니메이터 접근후 실행
                    inactiveMonsterBlood.transform.position = new Vector3(x, y, 0);
                }
                break;

            case 3:
                inactiveMonsterBlood = monsterBloodPool4.Find(blood4 => !blood4.activeSelf);
                if (inactiveMonsterBlood != null)
                {
                    inactiveMonsterBlood.SetActive(true);
                    inactiveMonsterBlood.GetComponent<Animator>().SetTrigger("isBlood"); // Blood 애니메이터 접근후 실행
                    inactiveMonsterBlood.transform.position = new Vector3(x, y, 0);
                }
                break;
        }
    }
}
