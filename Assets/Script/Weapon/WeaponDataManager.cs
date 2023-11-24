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
    }

    private void Update()
    {
        if (playerATwoCoolTime <= 0.5f)
            playerATwoCoolTime = 0.5f;

        if (playerAThreeCoolTime <= 0.5f)
            playerAThreeCoolTime = 0.5f;
    }
}
