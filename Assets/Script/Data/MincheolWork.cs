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
        _Monster1HP = Monster1HP;
        _Monster1Speed = Monster1Speed;
        _Monster2HP = Monster2HP;
        _Monster2Speed = Monster2Speed;
        _Monster3HP = Monster3HP;
        _Monster3Speed = Monster3Speed;

        WeaponDataManager.playerABasicAtkDamage = BasicAtkDamage;
        WeaponDataManager.playerABasicAtkCool = BasicAtkCool;
        WeaponDataManager.playerAOneAtk = skill1Damage;
        WeaponDataManager.playerAOneSpeed = skill1Speed;
        WeaponDataManager.playerATwoAtk = skill2Damage;
        WeaponDataManager.playerATwoCoolTime = skill2Cool;
        WeaponDataManager.playerAThreeAtk = skill3Damage;
        WeaponDataManager.playerAThreeCoolTime = skill3Cool;
        WeaponDataManager.playerAFourTime = StopTime;
        WeaponDataManager.playerAFourCoolTime = StopCool;

        PlayerState.Hp = HP;
        PlayerState.Speed = Speed;
        PlayerState.Damage = Damage;
        PlayerState.Defense = Defense;
    }

}
