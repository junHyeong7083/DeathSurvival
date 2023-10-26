using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{

    public static float testValue = 1f; // 테스트용
    public void Pattern1()
    {
        WeaponManager.Instance.StartPattern("atk1");
        TestAtk.isTestAtk1 = true;
    }

    public void Pattern2()
    {
        WeaponManager.Instance.StartPattern("atk2");
    }

    #region Pattern3
    public void Pattern3()
    {
        WeaponManager.Instance.StartPattern("atk3");
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
        WeaponManager.Instance.StartPattern("atk4");
    }
}
