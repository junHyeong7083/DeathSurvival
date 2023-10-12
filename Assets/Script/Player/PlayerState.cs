using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public static float Defense; // 방어력

    public static float Damage; // 공격력

    public static float Hp; // 체력
    public static bool isHpSkillPoint = false;

    public static float Speed; // 이동속도
    public static float detectRange;
    //public static float attractionSpeed;
    [SerializeField]
    private int Level;

    #region See Inspector
    [SerializeField]
    float _Defense;
    [SerializeField]
    float _Damage;
    [SerializeField]
    float _Hp;
    [SerializeField]
    float _Speed;
    #endregion

    private static PlayerState instance;
    private void Awake()
    {
        // -----------------------------
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(this.gameObject);
        detectRange = 2.5f;
        Defense = 1f;
        Damage = 1f;
        Hp = 10f;
        Speed = 5f;
        //attractionSpeed = 15f;
    }

    private void Update()
    {
        _Defense = Defense;
        _Damage = Damage;
        _Hp = Hp;
        _Speed = Speed;
    }

}
