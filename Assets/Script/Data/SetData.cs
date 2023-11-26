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
            Debug.Log("PlayerHP ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerSpeed ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerDamage ���� �߸��� �Է� ����");
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
            Debug.Log("PlayerDefense ���� �߸��� �Է� ����");
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
            Debug.Log("Skill1Atk ���� �߸��� �Է� ����");
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
            Debug.Log("Skill1AtkUP ���� �߸��� �Է� ����");
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
            PlayerPrefs.SetFloat("Skill1SpeedUP", value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Skill1SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill2Atk ���� �߸��� �Է� ����");
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
            Debug.Log("Skill2AtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill2Speed ���� �߸��� �Է� ����");
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
            Debug.Log("Skill2SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill3Atk ���� �߸��� �Է� ����");
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
            Debug.Log("Skill3AtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill3Speed ���� �߸��� �Է� ����");
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
            Debug.Log("Skill3SpeedUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill4Time ���� �߸��� �Է� ����");
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
            Debug.Log("Skill4TimeUP ���� �߸��� �Է� ����");
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
            Debug.Log("Skill4Cool ���� �߸��� �Է� ����");
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
            Debug.Log("Skill4CoolUP ���� �߸��� �Է� ����");
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
            Debug.Log("BasicAtk ���� �߸��� �Է� ����");
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
            Debug.Log("BasicAtkUP ���� �߸��� �Է� ����");
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
            Debug.Log("BasicSpeed ���� �߸��� �Է� ����");
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
            Debug.Log("BasicSpeedUP ���� �߸��� �Է� ����");
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

        currnetText[6].text = "�÷��̾� ü�� : " + PlayerPrefs.GetFloat("PlayerHP").ToString();
        currnetText[7].text = "�÷��̾� �̼� : " + PlayerPrefs.GetFloat("PlayerSpeed").ToString();
        currnetText[8].text = "�÷��̾� ���ݷ� : " + PlayerPrefs.GetFloat("PlayerDamage").ToString();
        currnetText[9].text = "�÷��̾� ���� : " + PlayerPrefs.GetFloat("PlayerDefense").ToString();

        currnetText[10].text = "��ų1���ݷ� : " + PlayerPrefs.GetFloat("Skill1Atk").ToString();
        currnetText[11].text = "��ų1���ݷ¾� : " + PlayerPrefs.GetFloat("Skill1AtkUP").ToString();
        currnetText[12].text = "��ų1���ݼӵ� : " + PlayerPrefs.GetFloat("Skill1Speed").ToString();
        currnetText[13].text = "��ų1���ݼӵ��� : " + PlayerPrefs.GetFloat("Skill1SpeedUP").ToString();

        currnetText[14].text = "��ų2���ݷ� : " + PlayerPrefs.GetFloat("Skill2Atk").ToString();
        currnetText[15].text = "��ų2���ݷ¾� : " + PlayerPrefs.GetFloat("Skill2AtkUP").ToString();
        currnetText[16].text = "��ų2���ݼӵ� : " + PlayerPrefs.GetFloat("Skill2Speed").ToString();
        currnetText[17].text = "��ų2���ݼӵ��� : " + PlayerPrefs.GetFloat("Skill2SpeedUP").ToString();

        currnetText[18].text = "��ų3���ݷ� : " + PlayerPrefs.GetFloat("Skill3Atk").ToString();
        currnetText[19].text = "��ų3���ݷ¾� : " + PlayerPrefs.GetFloat("Skill3AtkUP").ToString();
        currnetText[20].text = "��ų3���ݼӵ� : " + PlayerPrefs.GetFloat("Skill3Speed").ToString();
        currnetText[21].text = "��ų3���ݼӵ��� : " + PlayerPrefs.GetFloat("Skill3SpeedUP").ToString();

        currnetText[22].text = "��ų4���ӽð� : " + PlayerPrefs.GetFloat("Skill4Time").ToString();
        currnetText[23].text = "��ų4���ӽð��� : " + PlayerPrefs.GetFloat("Skill4TimeUP").ToString();
        currnetText[24].text = "��ų4��Ÿ�� : " + PlayerPrefs.GetFloat("Skill4Cool").ToString();
        currnetText[25].text = "��ų4��Ÿ�Ӿ� : " + PlayerPrefs.GetFloat("Skill4CoolUP").ToString();

        currnetText[26].text = "�⺻���� : " + PlayerPrefs.GetFloat("BasicAtk").ToString();
        currnetText[27].text = "�⺻���ݾ� : " + PlayerPrefs.GetFloat("BasicAtkUP").ToString();
        currnetText[28].text = "�⺻���ݼӵ�: " + PlayerPrefs.GetFloat("BasicSpeed").ToString();
        currnetText[29].text = "�⺻���ݼӵ� �� : " + PlayerPrefs.GetFloat("BasicSpeedUP").ToString();

        currnetText[30].text = "�⺻���ݷ� �� : " + PlayerPrefs.GetFloat("PlayerADamageUP").ToString();
        currnetText[31].text = "�⺻�̼Ӿ� : " + PlayerPrefs.GetFloat("PlayerASpeedUP").ToString();
        currnetText[32].text = "�⺻ü�¾�: " + PlayerPrefs.GetFloat("PlayerAHpUP").ToString();
        currnetText[33].text = "�⺻���� �� : " + PlayerPrefs.GetFloat("PlayerADefenseUP").ToString();
    }
}
