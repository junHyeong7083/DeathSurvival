using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk2 : MonoBehaviour
{
    GameObject SkillData;
    GameObject Player;
    Transform PlayerTransform;
    GameObject Dir;


    GameObject skillParentB; // �� ������Ʈ�� ������ ����

    public static bool isTestAtk1 = false;
    private void Start()
    {
        SkillData = GameObject.Find("WeaponManager/Skill Data");
        Player = GameObject.Find("Player");
        Dir = GameObject.Find("Dir");
        PlayerTransform = Player.transform;
        // ��ų�� ���� �� ������Ʈ ����
        skillParentB = new GameObject("Skill ParentB");

        skillParentB.transform.parent = SkillData.transform;
    }

}
