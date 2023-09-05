using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public static float Defense; // 방어력
    public static float Damage; // 공격력
    public static float Hp; // 체력
    public static float Speed; // 이동속도


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

        Defense = 1f;
        Damage = 1f;
        Hp = 1f;
        Speed = 5f;
    }

    private void Update()
    {
        _Defense = Defense;
        _Damage = Damage;
        _Hp = Hp;
        _Speed = Speed;
    }

}
