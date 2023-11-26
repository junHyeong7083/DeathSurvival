using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MincheolWork : MonoBehaviour
{
    [Header("Monster1")]
    [SerializeField]
    float Monster1HP;
    public static float _Monster1HP;
    [SerializeField]
    float Monster1Speed;
    public static float _Monster1Speed;


    [Header("Monster2")]
    [SerializeField]
    float Monster2HP;
    public static float _Monster2HP;
    [SerializeField]
    float Monster2Speed;
    public static float _Monster2Speed;

    [Header("Monster3")]
    [SerializeField]
    float Monster3HP;
    public static float _Monster3HP;
    [SerializeField]
    float Monster3Speed;
    public static float _Monster3Speed;

    [Header("����")]
    [SerializeField]
    float HP;
    [SerializeField]
    float Damage;
    [SerializeField]
    [Tooltip("0~1.0���̰� �Է� / 0���������� ���� ����")]
    float Defense;
    [SerializeField]
    float Speed;



    [Header("�⺻����")]
    [SerializeField]
    float BasicAtkDamage;
    [SerializeField]
    [Tooltip("�⺻���� ��Ÿ��(���� ���ݼӵ�)")]
    float BasicAtkCool;

    [Header("1����ų")]
    [SerializeField]
    float skill1Damage;
    [SerializeField]
    [Tooltip("�ִϸ��̼� ����ӵ�(�������� ������ ȸ��)")]
    float skill1Speed;

    [Header("2����ų")]
    [SerializeField]
    float skill2Damage;
    [SerializeField]
    [Tooltip("���� ��Ÿ��")]
    float skill2Cool;

    [Header("3����ų")]
    [SerializeField]
    float skill3Damage;
    [SerializeField]
    float skill3Cool;

    [Header("4����ų")]
    [SerializeField]
    [Tooltip("���Ͱ� �ð������ϴ� �ð�")]
    float StopTime;
    [SerializeField]
    [Tooltip("���� �ð����������� ��Ÿ��")]
    float StopCool;

    
    void Awake()
    {
        _Monster1HP = PlayerPrefs.GetFloat("M1HP");
        _Monster1Speed = PlayerPrefs.GetFloat("M1Speed");
        _Monster2HP = PlayerPrefs.GetFloat("M2HP");
        _Monster2Speed = PlayerPrefs.GetFloat("M2Speed");
        _Monster3HP = PlayerPrefs.GetFloat("M3HP");
        _Monster3Speed = PlayerPrefs.GetFloat("M3Speed");

        WeaponDataManager.playerABasicAtkDamage = PlayerPrefs.GetFloat("BasicAtk");
        WeaponDataManager.playerABasicAtkCool = PlayerPrefs.GetFloat("BasicSpeed");
        WeaponDataManager.playerAOneAtk = PlayerPrefs.GetFloat("Skill1Atk");
        WeaponDataManager.playerAOneSpeed = PlayerPrefs.GetFloat("Skill1Speed");
        WeaponDataManager.playerATwoAtk = PlayerPrefs.GetFloat("Skill2Atk");
        WeaponDataManager.playerATwoCoolTime = PlayerPrefs.GetFloat("Skill2Speed");
        WeaponDataManager.playerAThreeAtk = PlayerPrefs.GetFloat("Skill3Atk");
        WeaponDataManager.playerAThreeCoolTime = PlayerPrefs.GetFloat("Skill3Speed");
        WeaponDataManager.playerAFourTime = PlayerPrefs.GetFloat("Skill4Time");
        WeaponDataManager.playerAFourCoolTime = PlayerPrefs.GetFloat("Skill4Cool");

/*        PlayerState.Hp = PlayerPrefs.GetFloat("PlayerHP");
        PlayerState.Speed = PlayerPrefs.GetFloat("PlayerSpeed");
        PlayerState.Damage = PlayerPrefs.GetFloat("PlayerDamage");
        PlayerState.Defense = PlayerPrefs.GetFloat("PlayerDefense");*/
    }
}
