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
        // "SkillParent" 빈 오브젝트 생성
        GameObject parentObject = new GameObject("Skill Data");
        skillParent = parentObject.transform;

        // "SkillParent" 빈 오브젝트를 "WeaponManager"의 자식으로 설정
        skillParent.parent = this.transform;
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
