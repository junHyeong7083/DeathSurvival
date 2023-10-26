using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour
{
    #region PlayerA
    public static float playerAOneAtk;
    public static float playerATwoAtk;
    public static float playerAThreeAtk;
    public static float playerAFourTime;
    public static bool playerAFourbool;
    #endregion

    private void Awake()
    {

        playerAOneAtk = 25f;
        playerATwoAtk = 15f;
        playerAThreeAtk = 100f;
        playerAFourTime = 4f;
        playerAFourbool = false;
    }
}
