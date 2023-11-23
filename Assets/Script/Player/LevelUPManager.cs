using JetBrains.Annotations;
using NBitcoin.RPC;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPManager : MonoBehaviour
{
    public GameObject LevelUpPanel;
    Image hpBg;
    bool isSelect = false;

    int buttonA = 0, buttonB = 0, buttonC = 0;
    int[] arr = new int[3];
    int index = 0;
    bool playerASkillA = true;
    bool playerASkillB = true;

    public Text[] Descriptions;
    private void Start()
    {

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
                    if(playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[0].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if(!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[0].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[0].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }
                    
                    break;

                case 1: // 2��
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[0].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[0].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[0].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[0].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[0].text = "�̵��ӵ� ����";
                    break;
            }
        }
    }
    public void SelectB() // ���� ���ż���
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            Debug.Log("WHITE");
            switch (buttonB)
            {

                case 0: // 1��
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[1].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[1].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[1].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[1].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[1].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[1].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[1].text = "�̵��ӵ� ����";
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
                    if (playerASkillA)
                    {
                        Descriptions[0].text = "1����ų ��밡��";
                        playerASkillA = false;
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[0].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[0].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[0].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[0].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[0].text = "�̵��ӵ� ����";
                    break;
            }
            switch (buttonB)
            {

                case 0: // 1��
                    if (playerASkillA)
                    {
                    //    WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[1].text = "1����ų ��밡��";
                      // playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[1].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                            //    WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[1].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                              //  WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[1].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[1].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[1].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[1].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[1].text = "�̵��ӵ� ����";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1��
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[2].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[2].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                           //     WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                            //    WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[2].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                  //  WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[2].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[2].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[2].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[2].text = "�̵��ӵ� ����";
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
                        Descriptions[2].text = "1����ų ��밡��";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // ����ӵ� ����x
                                Descriptions[2].text = "1����ų ȸ���ӵ� 1���� \n ���� �ӵ� : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // ������ ����
                                Descriptions[2].text = "1����ų ������ 5���� \n ���� ������ : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2��
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
                    break;

                case 2: // 3��
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
                    break;

                case 3: // 4�� �ð�����
                    Descriptions[2].text = "4����ų �ӹ� �ð� ���� \n ���� �ӹ� �ð� : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //�⺻ ����
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[2].text = "���ݷ� ����";
                    break;

                case 6: // ü��
                    Descriptions[2].text = "ü�� ����";
                    break;

                case 7: // ����
                    Descriptions[2].text = "���� ����";
                    break;

                case 8: // �̵��ӵ�
                    Descriptions[2].text = "�̵��ӵ� ����";
                    break;
            }
        }
    }
    #endregion


    private void Update()
    {
        if(PlayerLevelBar.isLevelUp)
        {
            SetRandomBox();
             buttonA = Random.Range(0, 8);
            buttonB = Random.Range(0, 8);
            buttonC = Random.Range(0, 8);
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
