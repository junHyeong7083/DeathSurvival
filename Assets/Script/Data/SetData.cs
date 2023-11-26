using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetData : MonoBehaviour
{
    public InputField[] inputFields;
    public UnityEngine.UI.Text[] currnetText;
    #region
    /*   public void SetM1Hp()
       {
           if (inputFields[0] == null)
               Debug.Log("rr");

           float Value = float.Parse(inputFields[0].text);
           PlayerPrefs.SetFloat("M1HP", Value);
           PlayerPrefs.Save();
       }*/

    public void MonsterTotalSet()
    {
        SetM1Hp();
        SetM1Speed();
        SetM2Hp();
        SetM2Speed();
        SetM3Hp();
        SetM3Speed();
    }

    public void MonsterTotalInit()
    {
        PlayerPrefs.SetFloat("M1HP", 0);
        PlayerPrefs.SetFloat("M1Speed", 0);

        PlayerPrefs.SetFloat("M2HP", 0);
        PlayerPrefs.SetFloat("M2Speed", 0);

        PlayerPrefs.SetFloat("M3HP", 0);
        PlayerPrefs.SetFloat("M3Speed", 0);

        PlayerPrefs.Save();
    }


    public void SetM1Hp()
    {
        if (inputFields[0] == null)
        {
            Debug.Log("Input field is null");
            return;
        }

        string inputText = inputFields[0].text;

        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M1HP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M1HP에 대한 잘못된 입력 형식");
        }
    }

    public void SetM1Speed()
    {
        if (inputFields[1] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[1].text;

        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M1Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M1Speed 대한 잘못된 입력 형식");
        }
    }
    public void SetM2Hp()
    {
        if (inputFields[2] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[2].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M2HP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M2HP 대한 잘못된 입력 형식");
        }
    }

    public void SetM2Speed()
    {
        if (inputFields[3] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[3].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M2Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M2Speed 대한 잘못된 입력 형식");
        }
    }
    public void SetM3Hp()
    {
        if (inputFields[4] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[4].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M3HP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M3HP 대한 잘못된 입력 형식");
        }

    }

    public void SetM3Speed()
    {
        if (inputFields[5] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[5].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("M3Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("M3Speed 대한 잘못된 입력 형식");
        }
    }
    #endregion

    #region PlayerState

    public void PlayerStateTotalSet()
    {
        SetPlayerHP();
        SetPlayerSpeed();
        SetPlayerATK();
        SetPlayerDef();
        SetAStateDamageUp();
        SetAStateSpeedUp();
        SetAStateHpUp();
        SetAStateDefenseUp();
    }

    public void PlayerStateTotalInit()
    {
        float value = 0;
        PlayerPrefs.SetFloat("PlayerAHP", 0);
        PlayerPrefs.SetFloat("PlayerASpeed", value);
        PlayerPrefs.SetFloat("PlayerADamage", value);
        PlayerPrefs.SetFloat("PlayerADefense", value);
        PlayerPrefs.SetFloat("PlayerADamageUP", value);
        PlayerPrefs.SetFloat("PlayerASpeedUP", value);
        PlayerPrefs.SetFloat("PlayerAHpUP", value);
        PlayerPrefs.SetFloat("PlayerADefenseUP", value);

        PlayerPrefs.Save();
    }
    public void SetPlayerHP()
    {
        if (inputFields[6] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[6].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerAHP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerAHP 대한 잘못된 입력 형식");
        }
    }
    public void SetPlayerSpeed()
    {
        if (inputFields[7] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[7].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerASpeed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerASpeed 대한 잘못된 입력 형식");
        }
    }
    public void SetPlayerATK()
    {
        if (inputFields[8] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[8].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerADamage", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerADamage 대한 잘못된 입력 형식");
        }

    }
    public void SetPlayerDef()
    {
        if (inputFields[9] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[9].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerADefense", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerADefense 대한 잘못된 입력 형식");
        }
    }
    #endregion

    #region Skill1

    public void Skill1TotalSet()
    {
        SetSkill1Atk();
        SetSkill1AtkUP();
        SetSkill1Speed();
        SetSkill1SpeedUP();
    }

    public void Skill1TotalInit()
    {
        float value = 0;
        PlayerPrefs.SetFloat("ASkill1Atk", value);
        PlayerPrefs.SetFloat("ASkill1AtkUP", value);
        PlayerPrefs.SetFloat("ASkill1Speed", value);
        PlayerPrefs.SetFloat("ASkill1SpeedUP", value);

        PlayerPrefs.Save();
    }
    public void SetSkill1Atk()
    {
        if (inputFields[10] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[10].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill1Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill1Atk 대한 잘못된 입력 형식");
        }
    }
    public void SetSkill1AtkUP()
    {
        if (inputFields[11] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[11].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill1AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill1AtkUP 대한 잘못된 입력 형식");
        }
    }
    public void SetSkill1Speed()
    {
        if (inputFields[12] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[12].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill1Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1Speed 대한 잘못된 입력 형식");
        }
    }
    public void SetSkill1SpeedUP()
    {
        if (inputFields[13] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[13].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill1SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1SpeedUP 대한 잘못된 입력 형식");
        }
    }
    #endregion

    #region Skill2
    public void Skill2TotalSet()
    {
        SetSkill2Atk();
        SetSkill2AtkUP();
        SetSkill2Speed();
        SetSkill2SpeedUP();
    }

    public void Skill2TotalInit()
    {
        float value = 0;
        PlayerPrefs.SetFloat("ASkill2Atk", value);
        PlayerPrefs.SetFloat("ASkill2AtkUP", value);
        PlayerPrefs.SetFloat("ASkill2Speed", value);
        PlayerPrefs.SetFloat("ASkill2SpeedUP", value);

        PlayerPrefs.Save();
    }

    public void SetSkill2Atk()
    {
        if (inputFields[14] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[14].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill2Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill2Atk 대한 잘못된 입력 형식");
        }

    }
    public void SetSkill2AtkUP()
    {
        if (inputFields[15] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[15].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill2AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill2AtkUP 대한 잘못된 입력 형식");
        }

      
    }
    public void SetSkill2Speed()
    {
        if (inputFields[16] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[16].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill2Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill2Speed 대한 잘못된 입력 형식");
        }

    }
    public void SetSkill2SpeedUP()
    {
        if (inputFields[17] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[17].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill2SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill2SpeedUP 대한 잘못된 입력 형식");
        }

    }
    #endregion

    #region Skill3

    public void Skill3TotalSet()
    {
        SetSkill3Atk();
        SetSkill3AtkUP();
        SetSkill3Speed();
        SetSkill3SpeedUP();
    }

    public void Skill3TotalInit()
    {
        float value = 0;
        PlayerPrefs.SetFloat("ASkill3Atk", value);
        PlayerPrefs.SetFloat("ASkill3AtkUP", value);
        PlayerPrefs.SetFloat("ASkill3Speed", value);
        PlayerPrefs.SetFloat("ASkill3SpeedUP", value);

        PlayerPrefs.Save();
    }
    public void SetSkill3Atk()
    {
        if (inputFields[18] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[18].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill3Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill3Atk 대한 잘못된 입력 형식");
        }

   
    }
    public void SetSkill3AtkUP()
    {
        if (inputFields[19] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[19].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill3AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill3AtkUP 대한 잘못된 입력 형식");
        }

 
    }
    public void SetSkill3Speed()
    {
        if (inputFields[20] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[20].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill3Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill3Speed 대한 잘못된 입력 형식");
        }

       
    }
    public void SetSkill3SpeedUP()
    {
        if (inputFields[21] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[21].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill3SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill3SpeedUP 대한 잘못된 입력 형식");
        }


    
    }
    #endregion

    #region Skill4
    public void Skill4TotalSet()
    {
        SetSkill4Time();
        SetSkill4TimeUP();
        SetSkill4Cool();
        SetSkill4CoolUP();
    }

    public void Skill4TotalInit()
    {
        float value = 0;
        PlayerPrefs.SetFloat("ASkill4Time", value);
        PlayerPrefs.SetFloat("ASkill4TimeUP", value);

        PlayerPrefs.SetFloat("ASkill4Cool", value);
        PlayerPrefs.SetFloat("ASkill4CoolUP", value);

        PlayerPrefs.Save();
    }

    public void SetSkill4Time()
    {
        if (inputFields[22] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[22].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill4Time", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill4Time 대한 잘못된 입력 형식");
        }

   
    }
    public void SetSkill4TimeUP()
    {

        if (inputFields[23] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[23].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill4TimeUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill4TimeUP 대한 잘못된 입력 형식");
        }


    }

    public void SetSkill4Cool()
    {
        if (inputFields[24] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[24].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill4Cool", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill4Cool 대한 잘못된 입력 형식");
        }

     
    }
    public void SetSkill4CoolUP()
    {
        if (inputFields[25] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[25].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ASkill4CoolUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ASkill4CoolUP 대한 잘못된 입력 형식");
        }


      
    }
    #endregion

    #region Basic

    public void SetBasicAtk()
    {
        if (inputFields[26] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[26].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ABasicAtk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ABasicAtk 대한 잘못된 입력 형식");
        }

   
    }
    public void SetBasicAtkUP()
    {
        if (inputFields[27] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[27].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ABasicAtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ABasicAtkUP 대한 잘못된 입력 형식");
        }

     
    }
    public void SetBasicSpeed()
    {

        if (inputFields[28] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[28].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ABasicSpeed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ABasicSpeed 대한 잘못된 입력 형식");
        }

     
    }
    public void SetBasicSpeedUP()
    {
        if (inputFields[29] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[29].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("ABasicSpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("BasicSpeedUP 대한 잘못된 입력 형식");
        }



      
    }

    #endregion

    #region
    public void SetAStateDamageUp()
    {
        if (inputFields[30] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[30].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerADamageUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerADamageUP 대한 잘못된 입력 형식");
        }
    }
    public void SetAStateSpeedUp()
    {
        if (inputFields[31] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[31].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerASpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerASpeedUP 대한 잘못된 입력 형식");
        }
    }
    public void SetAStateHpUp()
    {
        if (inputFields[32] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[32].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerAHpUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerAHpUP 대한 잘못된 입력 형식");
        }
    }
    public void SetAStateDefenseUp()
    {
        if (inputFields[33] == null)
        {
            Debug.Log("Input field is null");
            return;
        }
        string inputText = inputFields[33].text;
        if (float.TryParse(inputText, out float value))
        {
            PlayerPrefs.SetFloat("PlayerADefenseUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerADefenseUP 대한 잘못된 입력 형식");
        }
    }


    #endregion
    private void Update()
    {
        currnetText[0].text = "몬스터1 체력 : " + PlayerPrefs.GetFloat("M1HP").ToString(); ;
        currnetText[1].text = "몬스터1 이속 : " + PlayerPrefs.GetFloat("M1Speed").ToString();
        currnetText[2].text = "몬스터2 체력 : " + PlayerPrefs.GetFloat("M2HP").ToString();
        currnetText[3].text = "몬스터2 이속 : " + PlayerPrefs.GetFloat("M2Speed").ToString();
        currnetText[4].text = "몬스터3 체력 : " + PlayerPrefs.GetFloat("M3HP").ToString();
        currnetText[5].text = "몬스터3 이속 : " + PlayerPrefs.GetFloat("M3Speed").ToString();

        currnetText[6].text = "플레이어 체력 : " + PlayerPrefs.GetFloat("PlayerAHP").ToString();
        currnetText[7].text = "플레이어 이속 : " + PlayerPrefs.GetFloat("PlayerASpeed").ToString();
        currnetText[8].text = "플레이어 공격력 : " + PlayerPrefs.GetFloat("PlayerADamage").ToString();
        currnetText[9].text = "플레이어 방어력 : " + PlayerPrefs.GetFloat("PlayerADefense").ToString();

        currnetText[10].text = "스킬1공격력 : " + PlayerPrefs.GetFloat("ASkill1Atk").ToString();
        currnetText[11].text = "스킬1공격력업 : " + PlayerPrefs.GetFloat("ASkill1AtkUP").ToString();
        currnetText[12].text = "스킬1공격속도 : " + PlayerPrefs.GetFloat("ASkill1Speed").ToString();
        currnetText[13].text = "스킬1공격속도업 : " + PlayerPrefs.GetFloat("ASkill1SpeedUP").ToString();

        currnetText[14].text = "스킬2공격력 : " + PlayerPrefs.GetFloat("ASkill2Atk").ToString();
        currnetText[15].text = "스킬2공격력업 : " + PlayerPrefs.GetFloat("ASkill2AtkUP").ToString();
        currnetText[16].text = "스킬2공격속도 : " + PlayerPrefs.GetFloat("ASkill2Speed").ToString();
        currnetText[17].text = "스킬2공격속도업 : " + PlayerPrefs.GetFloat("ASkill2SpeedUP").ToString();

        currnetText[18].text = "스킬3공격력 : " + PlayerPrefs.GetFloat("ASkill3Atk").ToString();
        currnetText[19].text = "스킬3공격력업 : " + PlayerPrefs.GetFloat("ASkill3AtkUP").ToString();
        currnetText[20].text = "스킬3공격속도 : " + PlayerPrefs.GetFloat("ASkill3Speed").ToString();
        currnetText[21].text = "스킬3공격속도업 : " + PlayerPrefs.GetFloat("ASkill3SpeedUP").ToString();

        currnetText[22].text = "스킬4지속시간 : " + PlayerPrefs.GetFloat("ASkill4Time").ToString();
        currnetText[23].text = "스킬4지속시간업 : " + PlayerPrefs.GetFloat("ASkill4TimeUP").ToString();
        currnetText[24].text = "스킬4쿨타임 : " + PlayerPrefs.GetFloat("ASkill4Cool").ToString();
        currnetText[25].text = "스킬4쿨타임업 : " + PlayerPrefs.GetFloat("ASkill4CoolUP").ToString();

        currnetText[26].text = "기본공격 : " + PlayerPrefs.GetFloat("ABasicAtk").ToString();
        currnetText[27].text = "기본공격업 : " + PlayerPrefs.GetFloat("ABasicAtkUP").ToString();
        currnetText[28].text = "기본공격속도: " + PlayerPrefs.GetFloat("ABasicSpeed").ToString();
        currnetText[29].text = "기본공격속도 업 : " + PlayerPrefs.GetFloat("ABasicSpeedUP").ToString();

        currnetText[30].text = "기본공격력 업 : " + PlayerPrefs.GetFloat("PlayerADamageUP").ToString();
        currnetText[31].text = "기본이속업 : " + PlayerPrefs.GetFloat("PlayerASpeedUP").ToString();
        currnetText[32].text = "기본체력업: " + PlayerPrefs.GetFloat("PlayerAHpUP").ToString();
        currnetText[33].text = "기본방어력 업 : " + PlayerPrefs.GetFloat("PlayerADefenseUP").ToString();
    }
}
