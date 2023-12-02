using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrebs;
    public int[] maxMonsters;
    List<GameObject>[] monsterPools;

    Transform monsterParent;

    
    private void Start()
    {
        monsterPools = new List<GameObject>[monsterPrebs.Length];

        for(int e =0; e< monsterPrebs.Length; e++)
        {
            monsterPools[e] = new List<GameObject> ();

            GameObject parentObj = new GameObject(monsterPrebs[e].name + "Parent");
            monsterParent = parentObj.transform;

            for (int j = 0; j < maxMonsters[e]; j++)
            {
                GameObject monster = Instantiate(monsterPrebs[e], monsterParent);
                monster.SetActive(false);
                monsterPools[e].Add(monster);
            }
        }
    }



}
