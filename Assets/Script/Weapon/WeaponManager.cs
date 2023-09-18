using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] SkillPrefabs;

    private Transform skillParent;
    private void Start()
    {
        GameObject parentObject = new GameObject("Skill Parent");
        skillParent = parentObject.transform;
    }

    public void SkillA()
    {
        if (Player != null)
        {
            GameObject SkillA = Instantiate(SkillPrefabs[0], skillParent);
        }
        TestAtk.isTestWeapon = true;
    }
}
