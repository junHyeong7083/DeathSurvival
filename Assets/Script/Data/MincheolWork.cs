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

    [Header("스탯")]
    [SerializeField]
    float HP;
    [SerializeField]
    float Damage;
    [SerializeField]
    [Tooltip("0~1.0사이값 입력 / 0에가까울수록 방어력 높음")]
    float Defense;
    [SerializeField]
    float Speed;



    [Header("기본공격")]
    [SerializeField]
    float BasicAtkDamage;
    [SerializeField]
    [Tooltip("기본공격 쿨타임(롤의 공격속도)")]
    float BasicAtkCool;

    [Header("1번스킬")]
    [SerializeField]
    float skill1Damage;
    [SerializeField]
    [Tooltip("애니메이션 재생속도(높을수록 빠르게 회전)")]
    float skill1Speed;

    [Header("2번스킬")]
    [SerializeField]
    float skill2Damage;
    [SerializeField]
    [Tooltip("공격 쿨타임")]
    float skill2Cool;

    [Header("3번스킬")]
    [SerializeField]
    float skill3Damage;
    [SerializeField]
    float skill3Cool;

    [Header("4번스킬")]
    [SerializeField]
    [Tooltip("몬스터가 시간정지하는 시간")]
    float StopTime;
    [SerializeField]
    [Tooltip("다음 시간정지까지의 쿨타임")]
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
