using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour
{
    #region PlayerA
    public static float playerAOneAtk;
    public static float playerAOneSpeed;
    public static float playerATwoAtk;
    public static float playerATwoCoolTime;
    public static float playerAThreeAtk;
    public static float playerAThreeCoolTime;
    public static float playerAFourTime;
    public static float playerAFourCoolTime;
    public static bool playerAFourbool;
    public static float playerABasicAtkDamage;
    public static float playerABasicAtkCool;
    #endregion


    #region PlayerB
    public static float playerBOneAtk;


    public static bool playerBTwobool;

    public static bool playerBFourbool;
    public static float playerBFourTime;
    public static float playerBFourCoolTime;
    #endregion

    #region PlayerC
    public static float playerCBasicAtkTime;
    public static float playerCBasicCoolTime;
    public static bool playerCBasicBool;
    public static float playerCBasicAtkDamage;

    public static float playerCOneContinueTime = 2f;
    public static float playerCOneCoolTime = 7f;
    public static float plyaerCOneDamage;


    public static float playerCTwoAtkContinueTime;
    public static float playerCTwoCoolTime;
    public static float playerCTwoDamage;


    public static float playerCThreeCoolTime; // 쿨타임
    public static float playerCThreeAtkContinueTime; // 공격지속시간
    public static float playerCThreeAtkSize; // 공격 범위

    public static float playerCFourCoolTime = 5f;
    public static float playerCFourAtkTime = 5f;
    public static int playerCFourAtkCnt = 1;
    public static bool playerCFourbool = false;
    #endregion
    private void Awake()
    {
          playerAOneSpeed = 1;
          playerAOneAtk =25f;
          playerATwoAtk =15f;
          playerATwoCoolTime = 2f;
          playerAThreeAtk =100f;
          playerAThreeCoolTime = 3f;
          playerAFourTime =4f;
          playerAFourCoolTime = 30f;
          playerAFourbool = false;
          playerABasicAtkDamage = 1000f;
          playerABasicAtkCool = 3f;

        playerBFourTime = 10f;
        playerBFourCoolTime = 30f;
        playerBFourbool = false;
        playerBTwobool = false;

        playerCBasicAtkTime = 3f;
        playerCBasicCoolTime = 3f;
        playerCBasicBool = false;




        playerCThreeCoolTime = 30f; // 쿨타임
        playerCThreeAtkContinueTime = 10f;
        playerCThreeAtkSize = 5;

        playerCTwoCoolTime = 10f;
        playerCTwoAtkContinueTime = 3f;

    }

    private void Update()
    {
        if (playerATwoCoolTime <= 0.5f)
            playerATwoCoolTime = 0.5f;

        if (playerAThreeCoolTime <= 0.5f)
            playerAThreeCoolTime = 0.5f;
    }
}
