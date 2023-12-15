using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPManager : MonoBehaviour
{

    [Header("-----레벨업 패널-----")]
    public GameObject LevelUpPanel;

    [Header("-----선택패널 아이콘 / 텍스트-----")]
    public Image[] IconImagePanel;
    public Text[] Descriptions;

    [Header("-----스킬아이콘들-----")]
    public Sprite[] SkillSprites;


    [Header("-----레벨업 효과-----")]
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
    public void SelectA() // 증강 들어갈거설정
    {
        ControllerParticle(false);

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
                        WeaponDataManager.playerBOneAtk += 0.5f; //  우선 데미지 증가만 구현
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
                        case 0: // 빈도
                            break;

                        case 1: // 공격력
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
                        case 0: // 쿨타임
                         //   WeaponDataManager.playerCBasicCoolTime -=  쿨타임 감소로직
                            break;

                        case 1: // 공격지속시간
                           // WeaponDataManager.playerCBasicAtkTime += 공격지속시간
                            break;

                        case 2:  // 데미지
                           // WeaponDataManager.playerCBasicAtkDamage += 데미지
                            break;


                    }
                    break;

                case 5: // 공격력
                   //   PlayerState.Damage +=
                    break; 

                case 6: // 체력
                   // PlayerState.Hp += 
                    break;

                case 7: // 방어력
                   // PlayerState.Defense -= 
                    break;

                case 8: // 이동속도
                   //  PlayerState.Speed +=
                    break;

            }
        }
    }
    public void SelectB() // 증강 들어갈거설정
    {
        ControllerParticle(false);

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
        ControllerParticle(false);

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
                        Askill1 = Random.Range(0, 2);
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
                        Askill2 = Random.Range(0, 2);
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
                        Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch(Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4번스킬 속박 시간 증가 ";
                                break;

                            case 1:
                                Descriptions[0].text = "4번스킬 쿨타임 감소 ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    AskillBasic = Random.Range(0, 2);
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
                        Askill1 = Random.Range(0, 2);
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
                         Askill2 = Random.Range(0, 2);
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
                         Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4번스킬 속박 시간 증가 ";
                                break;

                            case 1:
                                Descriptions[0].text = "4번스킬 쿨타임 감소 ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                     AskillBasic = Random.Range(0, 2);
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
                         Askill1 = Random.Range(0, 2);
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
                         Askill2 = Random.Range(0, 2);
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
                         Askill3 = Random.Range(0, 2);
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
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                Descriptions[0].text = "4번스킬 속박 시간 증가 ";
                                break;

                            case 1:
                                Descriptions[0].text = "4번스킬 쿨타임 감소 ";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                     AskillBasic = Random.Range(0, 2);
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
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerBSkillA)
                    {
                        Descriptions[0].text = "1번스킬 사용가능";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[0].text = "데미지 증가 : " ;
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;    
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[0].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "자석 범위 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[0].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "데미지 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[0].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch(Bskill4)
                        {
                            case 0:
                                Descriptions[0].text = "쿨타임 감소";
                                break;

                            case 1:
                                Descriptions[0].text = "버프 시간 증가";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[0].text = "데미지 증가";
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
                    if (playerBSkillA)
                    {
                        Descriptions[1].text = "1번스킬 사용가능";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "데미지 증가 : ";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[1].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "자석 범위 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[1].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "데미지 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[1].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                Descriptions[1].text = "쿨타임 감소";
                                break;

                            case 1:
                                Descriptions[1].text = "버프 시간 증가";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[1].text = "데미지 증가";
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
                    if (playerBSkillA)
                    {
                        Descriptions[2].text = "1번스킬 사용가능";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "데미지 증가 : ";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerBSkillB)
                    {
                        Descriptions[2].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "자석 범위 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerBSkillC)
                    {
                        Descriptions[2].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "데미지 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerBSkillD)
                    {
                        Descriptions[2].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                Descriptions[2].text = "쿨타임 감소";
                                break;

                            case 1:
                                Descriptions[2].text = "버프 시간 증가";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    BskillBasic = Random.Range(0, 1);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[2].text = "데미지 증가";
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
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    IconImagePanel[0].sprite = SkillSprites[0];
                    if (playerCSkillA)
                    {
                        Descriptions[0].text = "1번스킬 사용가능";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[0].text = "공격지속시간 증가 : ";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소 : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[0].text = "공격력 증가 : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[0].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "공격지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소";
                                break;

                            case 2:
                                Descriptions[0].text = "공격력 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[0].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "공격 지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[0].text = "범위 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[0].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch(Cskill4)
                        {
                            case 0:
                                Descriptions[0].text = "공격지속시간 증가";
                                break;

                            case 1:
                                Descriptions[0].text = "쿨타임 감소";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[0].text = "기본공격 공격 시간 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[0].text = "장전시간 감소";
                            break;

                        case 2:
                            Descriptions[0].text = "공격력 증가";
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
                    if (playerCSkillA)
                    {
                        Descriptions[1].text = "1번스킬 사용가능";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "공격지속시간 증가 : ";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소 : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[1].text = "공격력 증가 : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[1].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "공격지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소";
                                break;

                            case 2:
                                Descriptions[1].text = "공격력 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[1].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "공격 지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[1].text = "범위 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[1].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[1].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[1].text = "공격지속시간 증가";
                                break;

                            case 1:
                                Descriptions[1].text = "쿨타임 감소";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[1].text = "기본공격 공격 시간 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[1].text = "장전시간 감소";
                            break;

                        case 2:
                            Descriptions[1].text = "공격력 증가";
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
                    if (playerCSkillA)
                    {
                        Descriptions[2].text = "1번스킬 사용가능";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "공격지속시간 증가 : ";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소 : ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[2].text = "공격력 증가 : ";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerCSkillB)
                    {
                        Descriptions[2].text = "2번스킬 사용가능";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "공격지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소";
                                break;

                            case 2:
                                Descriptions[2].text = "공격력 증가";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    if (playerCSkillC)
                    {
                        Descriptions[2].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "공격 지속시간 증가";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[2].text = "범위 증가";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[2].sprite = SkillSprites[3];
                    if (playerCSkillD)
                    {
                        Descriptions[2].text = "4번스킬 사용가능";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[2].text = "공격지속시간 증가";
                                break;

                            case 1:
                                Descriptions[2].text = "쿨타임 감소";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[2].text = "기본공격 공격 시간 증가";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[2].text = "장전시간 감소";
                            break;

                        case 2:
                            Descriptions[2].text = "공격력 증가";
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
