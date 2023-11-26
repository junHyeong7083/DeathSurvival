using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPManager : MonoBehaviour
{
    public GameObject LevelUpPanel;
    public Image[] IconImagePanel;
    public Sprite[] SkillSprites;
    Image hpBg;
    bool isSelect = false;

    int buttonA = 0, buttonB = 0, buttonC = 0;
    int[] arr = new int[3];
    int index = 0;
    bool playerASkillA = true;
    bool playerASkillB = true;
    bool playerASkillC = true;
    bool playerASkillD = true;

    public Text[] Descriptions;
    private void Start()
    {
        index = 0;
        hpBg = GameObject.Find("HpBG").GetComponent<Image>();
        LevelUpPanel.SetActive(false);
    }
    #region SelectBtn
    public void SelectA() // ���� ���ż���
    {
        isSelect = true;
        if(CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonA)
            {
                case 0: // 1��
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                    // Descriptions[0].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // ������ ����
                                //Descriptions[0].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    if (playerASkillB)
                    {
                        WeaponManager.Instance.StartPattern("atk2");
                        playerASkillB = false;
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    if (playerASkillC)
                    {
                        WeaponManager.Instance.StartPattern("atk3");
                        playerASkillC = false;
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    if (playerASkillD)
                    {
                        playerASkillD = false;
                        WeaponManager.Instance.StartPattern("atk4");
                     //   WeaponDataManager.playerAFourbool = true;
                    }
                    else
                    {
                        int Askill4 = Random.Range(0, 2);
                        switch(Askill4)
                        {
                            case 0: // ���ӽð�
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // ��Ÿ��
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // ������ ����
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // ü��
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // ����
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // �̵��ӵ�
                    PlayerState.Speed += PlayerPrefs.GetFloat("PlayerASpeedUP");
                    break;
            }
        }
    }
    public void SelectB() // ���� ���ż���
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonB)
            {
                case 0: // 1��
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                    // Descriptions[0].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // ������ ����
                                //Descriptions[0].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    if (playerASkillB)
                    {
                        WeaponManager.Instance.StartPattern("atk2");
                        playerASkillB = false;
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    if (playerASkillC)
                    {
                        WeaponManager.Instance.StartPattern("atk3");
                        playerASkillC = false;
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    if (playerASkillD)
                    {
                        playerASkillD = false;
                        WeaponManager.Instance.StartPattern("atk4");
                        //   WeaponDataManager.playerAFourbool = true;
                    }
                    else
                    {
                        int Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0: // ���ӽð�
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // ��Ÿ��
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // ������ ����
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // ü��
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // ����
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // �̵��ӵ�
                    PlayerState.Speed += PlayerPrefs.GetFloat("PlayerASpeedUP");
                    break;
            }
        }
    }
    public void SelectC() // ���� ���ż���
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonC)
            {
                case 0: // 1��
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                    // Descriptions[0].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // ������ ����
                                //Descriptions[0].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    if (playerASkillB)
                    {
                        WeaponManager.Instance.StartPattern("atk2");
                        playerASkillB = false;
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    if (playerASkillC)
                    {
                        WeaponManager.Instance.StartPattern("atk3");
                        playerASkillC = false;
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // ������ ����
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    if (playerASkillD)
                    {
                        playerASkillD = false;
                        WeaponManager.Instance.StartPattern("atk4");
                        //   WeaponDataManager.playerAFourbool = true;
                    }
                    else
                    {
                        int Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0: // ���ӽð�
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // ��Ÿ��
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // ������ ����
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // ü��
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // ����
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // �̵��ӵ�
                    PlayerState.Speed += PlayerPrefs.GetFloat("PlayerASpeedUP");
                    break;
            }
        }
    }
    void SetRandomBox()
    {
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            Debug.Log("ButtonA : " + buttonA);
            Debug.Log("ButtonB : " + buttonB);
            Debug.Log("ButtonC : " + buttonC);
            switch (buttonA)
            {
                case 0: // 1��
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[0].text = "1����ų ��밡��";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[0].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[0].text = "2����ų ��밡��";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                Descriptions[0].text = "2����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "2����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[0].text = "3����ų ��밡��";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                Descriptions[0].text = "3����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "3����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[0].text = "4����ų ��밡��";
                    }
                    else
                        Descriptions[0].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            Descriptions[0].text = "�⺻���� ���� Ƚ�� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[0].text = "�⺻���� ������ ����";
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    IconImagePanel[0].sprite = SkillSprites[4];
                    Descriptions[0].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    IconImagePanel[0].sprite = SkillSprites[5];
                    Descriptions[0].text = "ü�� ����";
                    break;

                case 7: // ����
                    IconImagePanel[0].sprite = SkillSprites[6];
                    Descriptions[0].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    IconImagePanel[0].sprite = SkillSprites[7];
                    Descriptions[0].text = "�̵��ӵ� ����";
                    break;
            }
            switch (buttonB)
            {
                case 0: // 1��
                    IconImagePanel[1].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[1].text = "1����ų ��밡��";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[1].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[1].text = "2����ų ��밡��";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                Descriptions[1].text = "2����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "2����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[1].text = "3����ų ��밡��";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                Descriptions[1].text = "3����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "3����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[1].text = "4����ų ��밡��";
                    }
                    else
                        Descriptions[1].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            Descriptions[1].text = "�⺻���� ���� Ƚ�� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[1].text = "�⺻���� ������ ����";
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    IconImagePanel[1].sprite = SkillSprites[4];
                    Descriptions[1].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    IconImagePanel[1].sprite = SkillSprites[5];
                    Descriptions[1].text = "ü�� ����";
                    break;

                case 7: // ����
                    IconImagePanel[1].sprite = SkillSprites[6];
                    Descriptions[1].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    IconImagePanel[1].sprite = SkillSprites[7];
                    Descriptions[1].text = "�̵��ӵ� ����";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1��
                    IconImagePanel[2].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[2].text = "1����ų ��밡��";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[2].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[2].text = "2����ų ��밡��";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // ��
                                Descriptions[2].text = "2����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "2����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[2].text = "3����ų ��밡��";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // ��
                                Descriptions[2].text = "3����ų ���� Ƚ�� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "3����ų ������ ���� \n ���� ������ : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[2].text = "4����ų ��밡��";
                    }
                    else
                        Descriptions[2].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // ��
                            Descriptions[2].text = "�⺻���� ���� Ƚ�� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[2].text = "�⺻���� ������ ����";
                            break;
                    }
                    break;

                case 5: // ���ݷ�
                    IconImagePanel[2].sprite = SkillSprites[4];
                    Descriptions[2].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    IconImagePanel[2].sprite = SkillSprites[5];
                    Descriptions[2].text = "ü�� ����";
                    break;

                case 7: // ����
                    IconImagePanel[2].sprite = SkillSprites[6];
                    Descriptions[2].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    IconImagePanel[2].sprite = SkillSprites[7];
                    Descriptions[2].text = "�̵��ӵ� ����";
                    break;
            }
        }
    }
    #endregion

    private void GenerateDistinctRandomNumbers()
    {
        // �迭 �ʱ�ȭ
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = -1; // �ߺ� Ȯ���� ���� ������ �ʱ�ȭ
        }

        // �ߺ� ���� �� ���� ���� ����
        for (int i = 0; i < arr.Length;)
        {
            int randomValue = Random.Range(0, 9);

            // �ߺ� Ȯ��
            if (!ArrayContains(arr, randomValue))
            {
                arr[i] = randomValue;
                i++;
            }
        }
    }

    // �迭�� Ư�� ���� ���ԵǾ� �ִ��� Ȯ���ϴ� �Լ�
    private bool ArrayContains(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
    private void Update()
    {
        if(PlayerLevelBar.isLevelUp)
        {
            GenerateDistinctRandomNumbers();
            buttonA = arr[0];
            buttonB = arr[1];
            buttonC = arr[2];
            SetRandomBox();
            index = 0;
            hpBg.gameObject.SetActive(false);
            LevelUpPanel.gameObject.SetActive(true);
            UIManager.isPause = true;
            PlayerLevelBar.isLevelUp = false;
        }
        if(isSelect)
        {
            hpBg.gameObject.SetActive(true);
            LevelUpPanel.gameObject.SetActive(false);
            UIManager.isPause = false;
            isSelect = false;
        }
        
    }
}
