using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPManager : MonoBehaviour
{

    [Header("-----������ �г�-----")]
    public GameObject LevelUpPanel;

    [Header("-----�����г� ������ / �ؽ�Ʈ-----")]
    public Image[] IconImagePanel;
    public Text[] Descriptions;

    [Header("-----��ų�����ܵ�-----")]
    public Sprite[] SkillSprites;


    [Header("-----������ ȿ��-----")]
    public ParticleSystem[] levelUpParticles;

    Image hpBg;
    bool isSelect = false;

    int buttonA = 0, buttonB = 0, buttonC = 0;
    int[] arr = new int[3];
    int index = 0;

    #region Bool PlayerA
    bool playerASkillA = true;
    bool playerASkillB = true;
    bool playerASkillC = true;
    bool playerASkillD = true;
    #endregion
    #region Bool PlayerB
    bool playerBSkillA = true;
    bool playerBSkillB = true;
    bool playerBSkillC = true;
    bool playerBSkillD = true;
    #endregion
    #region Bool PlayerC
    bool playerCSkillA = true;
    bool playerCSkillB = true;
    bool playerCSkillC = true;
    bool playerCSkillD = true;
    #endregion
    [SerializeField]
    int[] currentSkillLevel = new int[8];
    private void Start()
    {
        index = 0;
        hpBg = GameObject.Find("HpBG").GetComponent<Image>();
        LevelUpPanel.SetActive(false);

        ControllerParticle(false);

        for(int e = 0; e < currentSkillLevel.Length; ++e)
        {
            currentSkillLevel[e] = 0;
        }


    }
    #region AskillRandomIndex
    int Askill1 = 0;
    int Askill2 = 0;
    int Askill3 = 0;
    int Askill4 = 0;
    int AskillBasic = 0;
    #endregion
    #region BskillRandomIndex
    int Bskill1 = 0;
    int Bskill2 = 0;
    int Bskill3 = 0;
    int Bskill4 = 0;
    int BskillBasic = 0;
    #endregion
    #region CskillRandomIndex
    int Cskill1 = 0;
    int Cskill2 = 0;
    int Cskill3 = 0;
    int Cskill4 = 0;
    int CskillBasic = 0;
    #endregion

    #region SelectBtn
    public void SelectA() // ���� ���ż���
    {
        ControllerParticle(false);

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
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch(buttonA)
            {
                case 0:
                    if(playerBSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk1");
                        playerBSkillA = false;
                    }
                    else if(!playerBSkillA)
                    {
                        WeaponDataManager.playerBOneAtk += 0.5f; //  �켱 ������ ������ ����
                    }
                    break;

                case 1:
                    if(playerBSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk1");
                        playerBSkillB = false;
                    }
                    else if(!playerBSkillB)
                    {

                    }
                    break;

                case 2:
                    if(playerBSkillC)
                    {

                    }
                    else if(!playerBSkillC)
                    {

                    }
                    break;

                case 3:
                    if(playerBSkillD)
                    {

                    }
                    else if(!playerBSkillD)
                    {

                    }
                    break;

                case 4:
                    int BsillBasic = Random.Range(0, 2);
                    switch(BsillBasic)
                    {
                        case 0: // ��
                            break;

                        case 1: // ���ݷ�
                            break;
                    }
                    break;

                case 5: // atk
                    //PlayerState.Damage += 
                    break;

                case 6: // hp
                        //PlayerState.Hp += 
                    break;

                case 7: // def
                   // PlayerState.Defense +=
                    break;

                case 8: // speed
                    //PlayerState.Speed
                    break;
            }
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch(buttonA)
            {
                case 0:
                    if(playerCSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playeCatk1");
                        playerCSkillA = false;
                    }
                    else if(!playerCSkillA)
                    {

                    }
                    break;

                case 1:
                    if(playerCSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk2");
                        playerCSkillB = false;
                    }
                    else if(!playerCSkillB)
                    {

                    }
                    break;

                case 2:
                    if(playerCSkillC)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk3");
                        playerCSkillC = false;
                    }
                    else if(!playerCSkillC)
                    {

                    }
                    break;

                case 3:
                    if(playerCSkillD)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk4");
                        playerCSkillD = false;
                    }
                    else if(playerCSkillD)
                    {

                    }
                    break;

                case 4:
                    int CskillBasic = Random.Range(0, 3);
                    switch(CskillBasic)
                    {
                        case 0: // ��Ÿ��
                         //   WeaponDataManager.playerCBasicCoolTime -=  ��Ÿ�� ���ҷ���
                            break;

                        case 1: // �������ӽð�
                           // WeaponDataManager.playerCBasicAtkTime += �������ӽð�
                            break;

                        case 2:  // ������
                           // WeaponDataManager.playerCBasicAtkDamage += ������
                            break;


                    }
                    break;

                case 5: // ���ݷ�
                   //   PlayerState.Damage +=
                    break; 

                case 6: // ü��
                   // PlayerState.Hp += 
                    break;

                case 7: // ����
                   // PlayerState.Defense -= 
                    break;

                case 8: // �̵��ӵ�
                   //  PlayerState.Speed +=
                    break;

            }
        }
    }
    public void SelectB() // ���� ���ż���
    {
        ControllerParticle(false);

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
        ControllerParticle(false);

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
                        Askill1 = Random.Range(0, 2);
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
                        Askill2 = Random.Range(0, 2);
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
                        Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch(Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4����ų �ӹ� �ð� ���� ";
                                break;

                            case 1:
                                Descriptions[0].text = "4����ų ��Ÿ�� ���� ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    AskillBasic = Random.Range(0, 2);
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
                        Askill1 = Random.Range(0, 2);
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
                         Askill2 = Random.Range(0, 2);
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
                         Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4����ų �ӹ� �ð� ���� ";
                                break;

                            case 1:
                                Descriptions[0].text = "4����ų ��Ÿ�� ���� ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                     AskillBasic = Random.Range(0, 2);
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
                         Askill1 = Random.Range(0, 2);
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
                         Askill2 = Random.Range(0, 2);
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
                         Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4����ų �ӹ� �ð� ���� ";
                                break;

                            case 1:
                                Descriptions[0].text = "4����ų ��Ÿ�� ���� ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                     AskillBasic = Random.Range(0, 2);
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
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch (buttonA)
            {
                case 0: // 1��
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerBSkillA)
                    {
                        Descriptions[0].text = "1����ų ��밡��";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[0].text = "������ ���� : " ;
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;    
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[0].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // ��
                                Descriptions[0].text = "�ڼ� ���� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[0].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // ��
                                Descriptions[0].text = "������ ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[0].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch(Bskill4)
                        {
                            case 0:
                                Descriptions[0].text = "��Ÿ�� ����";
                                break;

                            case 1:
                                Descriptions[0].text = "���� �ð� ����";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //�⺻ ����
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // ��
                            Descriptions[0].text = "������ ����";
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
                    if (playerBSkillA)
                    {
                        Descriptions[1].text = "1����ų ��밡��";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[1].text = "������ ���� : ";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[1].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // ��
                                Descriptions[1].text = "�ڼ� ���� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[1].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // ��
                                Descriptions[1].text = "������ ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[1].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                Descriptions[1].text = "��Ÿ�� ����";
                                break;

                            case 1:
                                Descriptions[1].text = "���� �ð� ����";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //�⺻ ����
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // ��
                            Descriptions[1].text = "������ ����";
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
                    if (playerBSkillA)
                    {
                        Descriptions[2].text = "1����ų ��밡��";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[2].text = "������ ���� : ";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[2].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // ��
                                Descriptions[2].text = "�ڼ� ���� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[2].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // ��
                                Descriptions[2].text = "������ ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[2].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                Descriptions[2].text = "��Ÿ�� ����";
                                break;

                            case 1:
                                Descriptions[2].text = "���� �ð� ����";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //�⺻ ����
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // ��
                            Descriptions[2].text = "������ ����";
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
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch (buttonA)
            {
                case 0: // 1��
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerCSkillA)
                    {
                        Descriptions[0].text = "1����ų ��밡��";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[0].text = "�������ӽð� ���� : ";
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "��Ÿ�� ���� : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[0].text = "���ݷ� ���� : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[0].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // ��
                                Descriptions[0].text = "�������ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "��Ÿ�� ����";
                                break;

                            case 2:
                                Descriptions[0].text = "���ݷ� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[0].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // ��
                                Descriptions[0].text = "���� ���ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "��Ÿ�� ����";
                                break;

                            case 2: // ������ ����
                                Descriptions[0].text = "���� ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[0].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch(Cskill4)
                        {
                            case 0:
                                Descriptions[0].text = "�������ӽð� ����";
                                break;

                            case 1:
                                Descriptions[0].text = "��Ÿ�� ����";
                                break;
                        }

                    }

                    break;

                case 4: //�⺻ ����
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // ��
                            Descriptions[0].text = "�⺻���� ���� �ð� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[0].text = "�����ð� ����";
                            break;

                        case 2:
                            Descriptions[0].text = "���ݷ� ����";
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
                    if (playerCSkillA)
                    {
                        Descriptions[1].text = "1����ų ��밡��";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[1].text = "�������ӽð� ���� : ";
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "��Ÿ�� ���� : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[1].text = "���ݷ� ���� : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[1].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // ��
                                Descriptions[1].text = "�������ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "��Ÿ�� ����";
                                break;

                            case 2:
                                Descriptions[1].text = "���ݷ� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[1].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // ��
                                Descriptions[1].text = "���� ���ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "��Ÿ�� ����";
                                break;

                            case 2: // ������ ����
                                Descriptions[1].text = "���� ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[1].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[1].text = "�������ӽð� ����";
                                break;

                            case 1:
                                Descriptions[1].text = "��Ÿ�� ����";
                                break;
                        }

                    }

                    break;

                case 4: //�⺻ ����
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // ��
                            Descriptions[1].text = "�⺻���� ���� �ð� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[1].text = "�����ð� ����";
                            break;

                        case 2:
                            Descriptions[1].text = "���ݷ� ����";
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
                    if (playerCSkillA)
                    {
                        Descriptions[2].text = "1����ų ��밡��";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[2].text = "�������ӽð� ���� : ";
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "��Ÿ�� ���� : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[2].text = "���ݷ� ���� : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[2].text = "2����ų ��밡��";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // ��
                                Descriptions[2].text = "�������ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "��Ÿ�� ����";
                                break;

                            case 2:
                                Descriptions[2].text = "���ݷ� ����";
                                break;
                        }
                    }
                    break;

                case 2: // 3��
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[2].text = "3����ų ��밡��";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // ��
                                Descriptions[2].text = "���� ���ӽð� ����";
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "��Ÿ�� ����";
                                break;

                            case 2: // ������ ����
                                Descriptions[2].text = "���� ����";
                                break;
                        }
                    }
                    break;

                case 3: // 4�� �ð�����
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[2].text = "4����ų ��밡��";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[2].text = "�������ӽð� ����";
                                break;

                            case 1:
                                Descriptions[2].text = "��Ÿ�� ����";
                                break;
                        }

                    }

                    break;

                case 4: //�⺻ ����
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // ��
                            Descriptions[2].text = "�⺻���� ���� �ð� ����";
                            break;

                        case 1: // ������ ����
                            Descriptions[2].text = "�����ð� ����";
                            break;

                        case 2:
                            Descriptions[2].text = "���ݷ� ����";
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

    void ControllerParticle(bool isPlay)
    {
        switch(isPlay)
        {
            case true:
                for (int e = 0; e < levelUpParticles.Length; e++)
                {
                    levelUpParticles[e].gameObject.SetActive(true);
                    levelUpParticles[e].Play();
                }
                break;

            case false:
                for (int e = 0; e < levelUpParticles.Length; e++)
                {
                    levelUpParticles[e].gameObject.SetActive(false);
                    levelUpParticles[e].Stop();
                }
                break;

        }
    }

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
                if (currentSkillLevel[i] <= 10)
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


            ControllerParticle(true);
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
