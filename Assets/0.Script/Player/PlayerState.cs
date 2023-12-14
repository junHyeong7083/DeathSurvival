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
    private static PlayerState instance;

    [SerializeField]
    int CharacterIndex;
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
   //     Defense = 1f;
   //     Damage = 1f;
   //     Hp = 10f;
   //     Speed = 5f;
        //attractionSpeed = 15f;

        switch(CharacterIndex)
        {
            case 0:
                Hp = 200f;
                Speed = 3;
                Damage = 100;
                Defense = 0.8f;
                break;

            case 1:
                Hp = 150f;
                Speed = 5;
                Damage = 150;
                Defense = 0.9f;
                break;

            case 2:
                Hp = 250;
                Speed = 4;
                Damage = 200;
                Defense = 0.6f;
                break;
        }
    }

    private void Update()
    {
    }

}
