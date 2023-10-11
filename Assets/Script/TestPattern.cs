using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{
    public void Pattern1()
    {
        WeaponManager.Instance.StartPattern("atk1");
        TestAtk.isTestAtk1 = true;
    }

    public void Pattern2()
    {
        WeaponManager.Instance.StartPattern("atk2");
    }
}
