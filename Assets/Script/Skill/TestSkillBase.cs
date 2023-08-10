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
            PlayerState.HP += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill2()
    {
        if (canFirst)
        {
            PlayerState.ATT += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill3()
    {
        if (canFirst)
        {
            PlayerState.DF += 2;
            canFirst = false;
        }
    }
    public void OnePointSkill4()
    {
        if (canFirst)
        {
            PlayerState.HP += 1;
            PlayerState.DF += 1;
            canFirst = false;
        }
    }
    public void OnePointSkill5()
    {
        if (canFirst)
        {
            PlayerState.ATT += 1;
            PlayerState.DF += 1;
            canFirst = false;
        }
    }

    public void TwoPointSkill1()
    {
        if (canSecond)
        {
            PlayerState.HP += 2;
            PlayerState.ATT += 1;
            canSecond = false;
        }
    }
    public void TwoPointSkill2()
    {
        if (canSecond)
        {
            PlayerState.DF += 2;
            PlayerState.ATT += 1;
            canSecond = false;
        }   
    }
    public void TwoPointSkill3()
    {
        if (canSecond)
        {
            PlayerState.ATT += 2;
            PlayerState.HP += 1;
            canSecond = false;
        }
    }

}
