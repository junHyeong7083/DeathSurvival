using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public static float Defense; // ����

    public static float Damage; // ���ݷ�

    public static float Hp; // ü��
    public static bool isHpSkillPoint = false;

    public static float Speed; // �̵��ӵ�
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
                Hp = PlayerPrefs.GetFloat("PlayerAHP");
                Speed = PlayerPrefs.GetFloat("PlayerASpeed");
                Damage = PlayerPrefs.GetFloat("PlayerADamage");
                Defense = PlayerPrefs.GetFloat("PlayerADefense");
                break;

            case 1:
                Hp = PlayerPrefs.GetFloat("PlayerAHP");
                Speed = PlayerPrefs.GetFloat("PlayerASpeed");
                Damage = PlayerPrefs.GetFloat("PlayerADamage");
                Defense = PlayerPrefs.GetFloat("PlayerADefense");
                break;

            case 2:
                Hp = PlayerPrefs.GetFloat("PlayerCHP");
                Speed = PlayerPrefs.GetFloat("PlayerCSpeed");
                Damage = PlayerPrefs.GetFloat("PlayerCDamage");
                Defense = PlayerPrefs.GetFloat("PlayerCDefense");
                break;
        }
    }

    private void Update()
    {
    }

}
