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
    public void SelectA() // 증강 들어갈거설정
    {
        isSelect = true;
        if(CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                    // Descriptions[0].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                            case 0: // 빈도
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3번
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
                            case 0: // 빈도
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
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
                            case 0: // 지속시간
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // 쿨타임
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // 데미지 증가
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // 공격력
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // 체력
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // 방어력
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // 이동속도
                    PlayerState.Speed += PlayerPrefs.GetFloat("PlayerASpeedUP");
                    break;
            }
        }
    }
    public void SelectB() // 증강 들어갈거설정
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonB)
            {
                case 0: // 1번
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                    // Descriptions[0].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                            case 0: // 빈도
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3번
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
                            case 0: // 빈도
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
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
                            case 0: // 지속시간
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // 쿨타임
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // 데미지 증가
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // 공격력
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // 체력
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // 방어력
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // 이동속도
                    PlayerState.Speed += PlayerPrefs.GetFloat("PlayerASpeedUP");
                    break;
            }
        }
    }
    public void SelectC() // 증강 들어갈거설정
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonC)
            {
                case 0: // 1번
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        //scriptions[1].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                    // Descriptions[0].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                float value1 = PlayerPrefs.GetFloat("Skill1SpeedUP");
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = PlayerPrefs.GetFloat("Skill1AtkUP");
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                            case 0: // 빈도
                                WeaponDataManager.playerATwoCoolTime -= PlayerPrefs.GetFloat("Skill2SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerATwoAtk += PlayerPrefs.GetFloat("Skill2AtkUP");
                                break;
                        }
                    }
                    break;

                case 2: // 3번
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
                            case 0: // 빈도
                                WeaponDataManager.playerAThreeCoolTime -= PlayerPrefs.GetFloat("Skill3SpeedUP");
                                break;

                            case 1: // 데미지 증가
                                WeaponDataManager.playerAThreeAtk += PlayerPrefs.GetFloat("Skill3AtkUP");
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
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
                            case 0: // 지속시간
                                WeaponDataManager.playerAFourTime += PlayerPrefs.GetFloat("Skill4TimeUP");
                                break;

                            case 1: // 쿨타임
                                WeaponDataManager.playerAFourCoolTime -= PlayerPrefs.GetFloat("Skill4CoolUP");
                                break;
                        }

                        WeaponDataManager.playerAFourTime += 0.25f;
                    }
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            WeaponDataManager.playerABasicAtkCool -= PlayerPrefs.GetFloat("BasicSpeedUP");
                            break;

                        case 1: // 데미지 증가
                            WeaponDataManager.playerABasicAtkDamage += PlayerPrefs.GetFloat("BasicAtkUP");
                            break;
                    }
                    break;

                case 5: // 공격력
                    PlayerState.Damage += PlayerPrefs.GetFloat("PlayerADamageUP");
                    break;

                case 6: // 체력
                    PlayerState.Hp += PlayerPrefs.GetFloat("PlayerAHpUP");
                    break;

                case 7: // 방어력
                    PlayerState.Defense += PlayerPrefs.GetFloat("PlayerADefenseUP");
                    break;

                case 8: // 이동속도
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
                case 0: // 1번
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[0].text = "1번스킬 사용가능";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[0].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[0].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "2번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "2번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[0].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "3번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "3번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[0].text = "4번스킬 사용가능";
                    }
                    else
                        Descriptions[0].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[0].text = "기본공격 공격 횟수 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[0].text = "기본공격 데미지 증가";
                            break;
                    }
                    break;

                case 5: // 공격력
                    IconImagePanel[0].sprite = SkillSprites[4];
                    Descriptions[0].text = "공격력 증가";
                    break;

                case 6: // 체력
                    IconImagePanel[0].sprite = SkillSprites[5];
                    Descriptions[0].text = "체력 증가";
                    break;

                case 7: // 방어력
                    IconImagePanel[0].sprite = SkillSprites[6];
                    Descriptions[0].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    IconImagePanel[0].sprite = SkillSprites[7];
                    Descriptions[0].text = "이동속도 증가";
                    break;
            }
            switch (buttonB)
            {
                case 0: // 1번
                    IconImagePanel[1].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[1].text = "1번스킬 사용가능";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[1].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "2번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "2번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[1].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "3번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "3번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[1].text = "4번스킬 사용가능";
                    }
                    else
                        Descriptions[1].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[1].text = "기본공격 공격 횟수 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[1].text = "기본공격 데미지 증가";
                            break;
                    }
                    break;

                case 5: // 공격력
                    IconImagePanel[1].sprite = SkillSprites[4];
                    Descriptions[1].text = "공격력 증가";
                    break;

                case 6: // 체력
                    IconImagePanel[1].sprite = SkillSprites[5];
                    Descriptions[1].text = "체력 증가";
                    break;

                case 7: // 방어력
                    IconImagePanel[1].sprite = SkillSprites[6];
                    Descriptions[1].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    IconImagePanel[1].sprite = SkillSprites[7];
                    Descriptions[1].text = "이동속도 증가";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1번
                    IconImagePanel[2].sprite = SkillSprites[0];
                    if (playerASkillA)
                    {
                        Descriptions[2].text = "1번스킬 사용가능";
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerASkillB)
                    {
                        Descriptions[2].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        int Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "2번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "2번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerATwoAtk.ToString();
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerASkillC)
                    {
                        Descriptions[2].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        int Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "3번스킬 공격 횟수 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "3번스킬 데미지 증가 \n 현재 데미지 : " + WeaponDataManager.playerAThreeAtk.ToString();
                                break;
                        }
                    }

                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerASkillD)
                    {
                        Descriptions[2].text = "4번스킬 사용가능";
                    }
                    else
                        Descriptions[2].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[2].text = "기본공격 공격 횟수 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[2].text = "기본공격 데미지 증가";
                            break;
                    }
                    break;

                case 5: // 공격력
                    IconImagePanel[2].sprite = SkillSprites[4];
                    Descriptions[2].text = "공격력 증가";
                    break;

                case 6: // 체력
                    IconImagePanel[2].sprite = SkillSprites[5];
                    Descriptions[2].text = "체력 증가";
                    break;

                case 7: // 방어력
                    IconImagePanel[2].sprite = SkillSprites[6];
                    Descriptions[2].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    IconImagePanel[2].sprite = SkillSprites[7];
                    Descriptions[2].text = "이동속도 증가";
                    break;
            }
        }
    }
    #endregion

    private void GenerateDistinctRandomNumbers()
    {
        // 배열 초기화
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = -1; // 중복 확인을 위해 음수로 초기화
        }

        // 중복 없는 세 개의 난수 생성
        for (int i = 0; i < arr.Length;)
        {
            int randomValue = Random.Range(0, 9);

            // 중복 확인
            if (!ArrayContains(arr, randomValue))
            {
                arr[i] = randomValue;
                i++;
            }
        }
    }

    // 배열에 특정 값이 포함되어 있는지 확인하는 함수
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
