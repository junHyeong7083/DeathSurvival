using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{

    public static float testValue = 1f; // 테스트용

    int[] playerA = new int[10];

    private void Start()
    {
        for(int e = 0; e < playerA.Length; e++)
        {
            playerA[e] = 0;
        }
    }
    public void Pattern1()
    {
        if (playerA[0] == 0)
        {
            WeaponManager.Instance.StartPattern("atk1");
            TestAtk.isTestAtk1 = true;
            playerA[0]++;
        }
    }

    public void Pattern2()
    {
        if (playerA[1] == 0)
        {
            WeaponManager.Instance.StartPattern("atk2");
            playerA[1]++;
        }
       // WeaponManager.Instance.StartPattern("atk2");
    }

    #region Pattern3
    public void Pattern3()
    {
        if (playerA[2] == 0)
        {
            WeaponManager.Instance.StartPattern("atk3");
            playerA[2]++;
        }
       // WeaponManager.Instance.StartPattern("atk3");
    }

    public void ValueUP()
    {
        testValue += 0.3f;
    }
    public void ValueDown()
    {
        testValue -= 0.3f;
    }
    #endregion 

    public void Pattern4()
    {
        if (playerA[3] == 0)
        {
            WeaponManager.Instance.StartPattern("atk4");
            playerA[3]++;   
        }
        //WeaponManager.Instance.StartPattern("atk4");
    }

    public void Pattern5()
    {
        WeaponManager.Instance.StartPattern("playerBatk4");
    }

    public void Pattern6()
    {
        WeaponManager.Instance.StartPattern("playerBatk1");
    }

    public void Pattern7()
    {
        WeaponManager.Instance.StartPattern("playerBatk2");
    }

    public void Pattern8()
    {
        WeaponManager.Instance.StartPattern("playerBatk3");
    }
}
