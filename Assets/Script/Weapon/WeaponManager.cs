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
        // "SkillParent" �� ������Ʈ ����
        GameObject parentObject = new GameObject("Skill Data");
        skillParent = parentObject.transform;

        // "SkillParent" �� ������Ʈ�� "WeaponManager"�� �ڽ����� ����
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
