using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{
    public static float testValue = 0.5f;
    public void Pattern1()
    {
        WeaponManager.Instance.StartPattern("atk1");
        TestAtk.isTestAtk1 = true;
    }

    public void Pattern2()
    {
        WeaponManager.Instance.StartPattern("atk2");
    }

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
}
