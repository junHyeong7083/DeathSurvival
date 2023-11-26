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
            Debug.Log("M1HP�� ���� �߸��� �Է� ����");
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
            Debug.Log("M1Speed ���� �߸��� �Է� ����");
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
            Debug.Log("M2HP ���� �߸��� �Է� ����");
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
            Debug.Log("M2Speed ���� �߸��� �Է� ����");
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
            Debug.Log("M3HP ���� �߸��� �Է� ����");
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
            Debug.Log("M3Speed ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerAHP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerASpeed ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerADamage ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerADefense ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill1Atk ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill1AtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill1Speed ���� �߸��� �Է� ����");
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
            Debug.Log("Skill1SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill2Atk ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill2AtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill2Speed ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill2SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill3Atk ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill3AtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill3Speed ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill3SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill4Time ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill4TimeUP ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill4Cool ���� �߸��� �Է� ����");
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
            Debug.Log("ASkill4CoolUP ���� �߸��� �Է� ����");
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
            Debug.Log("ABasicAtk ���� �߸��� �Է� ����");
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
            Debug.Log("ABasicAtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("ABasicSpeed ���� �߸��� �Է� ����");
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
            Debug.Log("BasicSpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerADamageUP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerASpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerAHpUP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerADefenseUP ���� �߸��� �Է� ����");
        }
    }


    #endregion
    private void Update()
    {
        currnetText[0].text = "����1 ü�� : " + PlayerPrefs.GetFloat("M1HP").ToString(); ;
        currnetText[1].text = "����1 �̼� : " + PlayerPrefs.GetFloat("M1Speed").ToString();
        currnetText[2].text = "����2 ü�� : " + PlayerPrefs.GetFloat("M2HP").ToString();
        currnetText[3].text = "����2 �̼� : " + PlayerPrefs.GetFloat("M2Speed").ToString();
        currnetText[4].text = "����3 ü�� : " + PlayerPrefs.GetFloat("M3HP").ToString();
        currnetText[5].text = "����3 �̼� : " + PlayerPrefs.GetFloat("M3Speed").ToString();

        currnetText[6].text = "�÷��̾� ü�� : " + PlayerPrefs.GetFloat("PlayerAHP").ToString();
        currnetText[7].text = "�÷��̾� �̼� : " + PlayerPrefs.GetFloat("PlayerASpeed").ToString();
        currnetText[8].text = "�÷��̾� ���ݷ� : " + PlayerPrefs.GetFloat("PlayerADamage").ToString();
        currnetText[9].text = "�÷��̾� ���� : " + PlayerPrefs.GetFloat("PlayerADefense").ToString();

        currnetText[10].text = "��ų1���ݷ� : " + PlayerPrefs.GetFloat("ASkill1Atk").ToString();
        currnetText[11].text = "��ų1���ݷ¾� : " + PlayerPrefs.GetFloat("ASkill1AtkUP").ToString();
        currnetText[12].text = "��ų1���ݼӵ� : " + PlayerPrefs.GetFloat("ASkill1Speed").ToString();
        currnetText[13].text = "��ų1���ݼӵ��� : " + PlayerPrefs.GetFloat("ASkill1SpeedUP").ToString();

        currnetText[14].text = "��ų2���ݷ� : " + PlayerPrefs.GetFloat("ASkill2Atk").ToString();
        currnetText[15].text = "��ų2���ݷ¾� : " + PlayerPrefs.GetFloat("ASkill2AtkUP").ToString();
        currnetText[16].text = "��ų2���ݼӵ� : " + PlayerPrefs.GetFloat("ASkill2Speed").ToString();
        currnetText[17].text = "��ų2���ݼӵ��� : " + PlayerPrefs.GetFloat("ASkill2SpeedUP").ToString();

        currnetText[18].text = "��ų3���ݷ� : " + PlayerPrefs.GetFloat("ASkill3Atk").ToString();
        currnetText[19].text = "��ų3���ݷ¾� : " + PlayerPrefs.GetFloat("ASkill3AtkUP").ToString();
        currnetText[20].text = "��ų3���ݼӵ� : " + PlayerPrefs.GetFloat("ASkill3Speed").ToString();
        currnetText[21].text = "��ų3���ݼӵ��� : " + PlayerPrefs.GetFloat("ASkill3SpeedUP").ToString();

        currnetText[22].text = "��ų4���ӽð� : " + PlayerPrefs.GetFloat("ASkill4Time").ToString();
        currnetText[23].text = "��ų4���ӽð��� : " + PlayerPrefs.GetFloat("ASkill4TimeUP").ToString();
        currnetText[24].text = "��ų4��Ÿ�� : " + PlayerPrefs.GetFloat("ASkill4Cool").ToString();
        currnetText[25].text = "��ų4��Ÿ�Ӿ� : " + PlayerPrefs.GetFloat("ASkill4CoolUP").ToString();

        currnetText[26].text = "�⺻���� : " + PlayerPrefs.GetFloat("ABasicAtk").ToString();
        currnetText[27].text = "�⺻���ݾ� : " + PlayerPrefs.GetFloat("ABasicAtkUP").ToString();
        currnetText[28].text = "�⺻���ݼӵ�: " + PlayerPrefs.GetFloat("ABasicSpeed").ToString();
        currnetText[29].text = "�⺻���ݼӵ� �� : " + PlayerPrefs.GetFloat("ABasicSpeedUP").ToString();

        currnetText[30].text = "�⺻���ݷ� �� : " + PlayerPrefs.GetFloat("PlayerADamageUP").ToString();
        currnetText[31].text = "�⺻�̼Ӿ� : " + PlayerPrefs.GetFloat("PlayerASpeedUP").ToString();
        currnetText[32].text = "�⺻ü�¾�: " + PlayerPrefs.GetFloat("PlayerAHpUP").ToString();
        currnetText[33].text = "�⺻���� �� : " + PlayerPrefs.GetFloat("PlayerADefenseUP").ToString();
    }
}
