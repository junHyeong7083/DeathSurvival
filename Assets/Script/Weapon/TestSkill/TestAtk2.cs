using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk2 : MonoBehaviour
{
    GameObject SkillData;
    GameObject Player;
    Transform PlayerTransform;
    GameObject Dir;


    GameObject skillParentB; // 빈 오브젝트를 저장할 변수

    public static bool isTestAtk1 = false;
    private void Start()
    {
        SkillData = GameObject.Find("WeaponManager/Skill Data");
        Player = GameObject.Find("Player");
        Dir = GameObject.Find("Dir");
        PlayerTransform = Player.transform;
        // 스킬을 넣을 빈 오브젝트 생성
        skillParentB = new GameObject("Skill ParentB");

        skillParentB.transform.parent = SkillData.transform;
    }

}
