using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour
{
    #region PlayerA
    public static float playerAOneAtk;
    public static float playerATwoAtk;
    public static float playerAThreeAtk;
    #endregion

    private void Awake()
    {
        playerAOneAtk = 25f;
        playerATwoAtk = 50f;
        playerAThreeAtk = 100f;
    }
}
