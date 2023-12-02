using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkillBase : MonoBehaviour
{
    bool canFirst;
    bool canSecond;
    private void Start()
    {
        canFirst = true;
        canSecond = true;
    }
    public void OnePointSkill1()
    {
        if(canFirst)
        {
            PlayerState.Hp += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill2()
    {
        if (canFirst)
        {
            PlayerState.Damage += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill3()
    {
        if (canFirst)
        {
            PlayerState.Defense += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill4()
    {
        if (canFirst)
        {
            PlayerState.Hp += 1;
            PlayerState.Defense += 1;
            canFirst = false;
        }
    }
    public void OnePointSkill5()
    {
        if (canFirst)
        {
            PlayerState.Damage += 1;
            PlayerState.Defense += 1;
            canFirst = false;
        }
    }

    public void TwoPointSkill1()
    {
        if (canSecond)
        {
            PlayerState.Hp += 2;
            PlayerState.Damage += 1;
            canSecond = false;
        }
    }
    public void TwoPointSkill2()
    {
        if (canSecond)
        {
            PlayerState.Defense += 2;
            PlayerState.Damage += 1;
            canSecond = false;
        }   
    }
    public void TwoPointSkill3()
    {
        if (canSecond)
        {
            PlayerState.Damage += 2;
            PlayerState.Hp += 1;
            canSecond = false;
        }
    }

}
