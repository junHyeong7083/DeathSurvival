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
            PlayerPrefs.SetFloat("PlayerHP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerHP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("PlayerSpeed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerSpeed 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("PlayerDamage", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerDamage 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("PlayerDefense", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("PlayerDefense 대한 잘못된 입력 형식");
        }
    }
    #endregion

    #region Skill1
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
            PlayerPrefs.SetFloat("Skill1Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1Atk 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill1AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1AtkUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill1Speed", value);
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
            PlayerPrefs.SetFloat("Skill1SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1SpeedUP 대한 잘못된 입력 형식");
        }
    }
    #endregion

    #region Skill2
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
            PlayerPrefs.SetFloat("Skill2Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill2Atk 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill2AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill2AtkUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill2Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill2Speed 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill2SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill2SpeedUP 대한 잘못된 입력 형식");
        }

    }
    #endregion

    #region Skill3
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
            PlayerPrefs.SetFloat("Skill3Atk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill3Atk 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill3AtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill3AtkUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill3Speed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill3Speed 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill3SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill3SpeedUP 대한 잘못된 입력 형식");
        }


    
    }
    #endregion

    #region Skill4
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
            PlayerPrefs.SetFloat("Skill4Time", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill4Time 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill4TimeUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill4TimeUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill4Cool", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill4Cool 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("Skill4CoolUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill4CoolUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("BasicAtk", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("BasicAtk 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("BasicAtkUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("BasicAtkUP 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("BasicSpeed", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("BasicSpeed 대한 잘못된 입력 형식");
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
            PlayerPrefs.SetFloat("BasicSpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("BasicSpeedUP 대한 잘못된 입력 형식");
        }



      
    }

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

        currnetText[6].text = "플레이어 체력 : " + PlayerPrefs.GetFloat("PlayerHP").ToString();
        currnetText[7].text = "플레이어 이속 : " + PlayerPrefs.GetFloat("PlayerSpeed").ToString();
        currnetText[8].text = "플레이어 공격력 : " + PlayerPrefs.GetFloat("PlayerDamage").ToString();
        currnetText[9].text = "플레이어 방어력 : " + PlayerPrefs.GetFloat("PlayerDefense").ToString();

        currnetText[10].text = "스킬1공격력 : " + PlayerPrefs.GetFloat("Skill1Atk").ToString();
        currnetText[11].text = "스킬1공격력업 : " + PlayerPrefs.GetFloat("Skill1AtkUP").ToString();
        currnetText[12].text = "스킬1공격속도 : " + PlayerPrefs.GetFloat("Skill1Speed").ToString();
        currnetText[13].text = "스킬1공격속도업 : " + PlayerPrefs.GetFloat("Skill1SpeedUP").ToString();

        currnetText[14].text = "스킬2공격력 : " + PlayerPrefs.GetFloat("Skill2Atk").ToString();
        currnetText[15].text = "스킬2공격력업 : " + PlayerPrefs.GetFloat("Skill2AtkUP").ToString();
        currnetText[16].text = "스킬2공격속도 : " + PlayerPrefs.GetFloat("Skill2Speed").ToString();
        currnetText[17].text = "스킬2공격속도업 : " + PlayerPrefs.GetFloat("Skill2SpeedUP").ToString();

        currnetText[18].text = "스킬3공격력 : " + PlayerPrefs.GetFloat("Skill3Atk").ToString();
        currnetText[19].text = "스킬3공격력업 : " + PlayerPrefs.GetFloat("Skill3AtkUP").ToString();
        currnetText[20].text = "스킬3공격속도 : " + PlayerPrefs.GetFloat("Skill3Speed").ToString();
        currnetText[21].text = "스킬3공격속도업 : " + PlayerPrefs.GetFloat("Skill3SpeedUP").ToString();

        currnetText[22].text = "스킬4지속시간 : " + PlayerPrefs.GetFloat("Skill4Time").ToString();
        currnetText[23].text = "스킬4지속시간업 : " + PlayerPrefs.GetFloat("Skill4TimeUP").ToString();
        currnetText[24].text = "스킬4쿨타임 : " + PlayerPrefs.GetFloat("Skill4Cool").ToString();
        currnetText[25].text = "스킬4쿨타임업 : " + PlayerPrefs.GetFloat("Skill4CoolUP").ToString();

        currnetText[26].text = "기본공격 : " + PlayerPrefs.GetFloat("BasicAtk").ToString();
        currnetText[27].text = "기본공격업 : " + PlayerPrefs.GetFloat("BasicAtkUP").ToString();
        currnetText[28].text = "기본공격속도: " + PlayerPrefs.GetFloat("BasicSpeed").ToString();
        currnetText[29].text = "기본공격속도 업 : " + PlayerPrefs.GetFloat("BasicSpeedUP").ToString();

        currnetText[30].text = "기본공격력 업 : " + PlayerPrefs.GetFloat("PlayerADamageUP").ToString();
        currnetText[31].text = "기본이속업 : " + PlayerPrefs.GetFloat("PlayerASpeedUP").ToString();
        currnetText[32].text = "기본체력업: " + PlayerPrefs.GetFloat("PlayerAHpUP").ToString();
        currnetText[33].text = "기본방어력 업 : " + PlayerPrefs.GetFloat("PlayerADefenseUP").ToString();
    }
}
