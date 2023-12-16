using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPManager : MonoBehaviour
{
    [Header("-----레벨업 패널-----")]
    public GameObject LevelUpPanel;

    [Header("-----패널 아이콘 이미지-----")]
    public GameObject[] panelIconImage;

    [Header("-----패널 텍스트-----")]
    public Text[] panelLevelText;

    [Header("-----인게임 텍스트-----")]
    public Text[] gameLevelText;

    [Header("-----선택패널 아이콘 / 텍스트-----")]
    public Image[] IconImagePanel;
    public Text[] Descriptions;
    public Text[] PropertyDescriptions;
    public Text[] nameDescriptions;
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

        for(int e = 0; e < panelIconImage.Length; ++e)
        {
            panelIconImage[e].gameObject.SetActive(false);
        }


        switch(CharacterManager.Instance.currentCharacter)
        {
            case Character.White:
                panelIconImage[0].gameObject.SetActive(true);
                break;

            case Character.Blue:
                panelIconImage[1].gameObject.SetActive(true);
                break;


            case Character.Green:
                panelIconImage[2].gameObject.SetActive(true);
                break;

        }


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
                    currentSkillLevel[0]++;
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
                                float value1 = WeaponDataManager.playerAOneSpeed * 0.05f;
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 =  WeaponDataManager.playerAOneAtk * 0.05f;
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    currentSkillLevel[1]++;
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
                                float value1 = WeaponDataManager.playerATwoCoolTime * 0.05f;
                                WeaponDataManager.playerATwoCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerATwoAtk * 0.05f;
                                WeaponDataManager.playerATwoAtk += value2;
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    currentSkillLevel[2]++;
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
                                float value1 = WeaponDataManager.playerAThreeCoolTime * 0.05f;
                                WeaponDataManager.playerAThreeCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerAThreeAtk * 0.05f;
                                WeaponDataManager.playerAThreeAtk += value2;
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    currentSkillLevel[3]++;
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
                                float value1 = WeaponDataManager.playerAFourTime * 0.05f;
                                WeaponDataManager.playerAFourTime += value1;
                                break;

                            case 1: // 쿨타임
                                float value2 = WeaponDataManager.playerAFourCoolTime * 0.05f;
                                WeaponDataManager.playerAFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4: //기본 공격
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            float value1 = WeaponDataManager.playerABasicAtkCool * 0.05f;
                            WeaponDataManager.playerABasicAtkCool -= value1;
                            break;

                        case 1: // 데미지 증가
                            float value2 = WeaponDataManager.playerABasicAtkDamage * 0.05f;
                            WeaponDataManager.playerABasicAtkDamage += value2;
                            break;
                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch(buttonA)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerBSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk1");
                        playerBSkillA = false;
                    }
                    else if(!playerBSkillA)
                    {
                        float value1 = WeaponDataManager.playerBOneAtk * 0.05f;
                        WeaponDataManager.playerBOneAtk += value1; //  우선 데미지 증가만 구현
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerBSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk2");
                        playerBSkillB = false;
                    }
                    else if(!playerBSkillB)
                    {
                        float value1 = WeaponDataManager.playerBTwoSize * 0.05f;
                        WeaponDataManager.playerBTwoSize += value1;
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerBSkillC)
                    {
                        playerBSkillC = false;
                        WeaponManager.Instance.StartPattern("playerBatk3");
                    }
                    else if(!playerBSkillC) // 데미지 증가
                    {
                        float value1 = WeaponDataManager.playerBThreeDamage * 0.05f;
                        WeaponDataManager.playerBThreeDamage += value1;
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerBSkillD)
                    {
                        playerBSkillD = false;
                        WeaponManager.Instance.StartPattern("playerBatk4");
                    }
                    else if(!playerBSkillD)
                    {
                        switch(Bskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerBFourCoolTime * 0.05f;
                                WeaponDataManager.playerBFourCoolTime -= value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerBFourTime * 0.05f;
                                WeaponDataManager.playerBFourTime += value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch(BskillBasic)
                    {
                        case 0: // 빈도
                            float value2 = WeaponDataManager.playerBBasicDamage * 0.05f;
                            WeaponDataManager.playerBBasicDamage += value2;
                            break;
                    }
                    break;

                case 5: // atk
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // hp
                    currentSkillLevel[5]++;
                    float valueHp= PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // def
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // speed
                    currentSkillLevel[7]++;
                    float valueSpeed  = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch(buttonA)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerCSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playeCatk1");
                        playerCSkillA = false;
                    }
                    else if(!playerCSkillA)
                    {
                        switch( Cskill1)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCOneContinueTime * 0.05f;
                                WeaponDataManager.playerCOneContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCOneCoolTime * 0.05f;
                                WeaponDataManager.playerCOneCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.plyaerCOneDamage * 0.05f;
                                WeaponDataManager.plyaerCOneDamage += value3;
                                break;

                        }
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerCSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk2");
                        playerCSkillB = false;
                    }
                    else if(!playerCSkillB)
                    {
                        switch(Cskill2)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCTwoAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCTwoAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCTwoCoolTime * 0.05f;
                                WeaponDataManager.playerCTwoCoolTime -= value2;

                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCTwoDamage * 0.05f;
                                WeaponDataManager.playerCTwoDamage += value3;
                                break;
                        }
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerCSkillC)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk3");
                        playerCSkillC = false;
                    }
                    else if(!playerCSkillC)
                    {
                        switch(Cskill3)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCThreeAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCThreeAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCThreeCoolTime * 0.05f;
                                WeaponDataManager.playerCThreeCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCThreeAtkSize * 0.05f;
                                WeaponDataManager.playerCThreeAtkSize += value3;
                                break;
                        }
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerCSkillD)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk4");
                        playerCSkillD = false;
                    }
                    else if(playerCSkillD)
                    {
                        switch(Cskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCFourAtkTime * 0.05f;
                                WeaponDataManager.playerCFourAtkTime += value1;

                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCFourCoolTime * 0.05f;
                                WeaponDataManager.playerCFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch(CskillBasic)
                    {
                        case 0: 
                            float value1 = WeaponDataManager.playerCBasicAtkTime * 0.05f;
                            WeaponDataManager.playerCBasicAtkTime -= value1;
                            break;

                        case 1:
                            float value2 = WeaponDataManager.playerCBasicCoolTime * 0.05f;
                            WeaponDataManager.playerCBasicCoolTime -= value2;
                            break;

                        case 2:
                            float value3 = WeaponDataManager.playerCBasicAtkDamage * 0.05f;
                            WeaponDataManager.playerCBasicAtkDamage -= value3;
                            break;


                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueDamage = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueDamage;
                    break; 

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp= PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef= PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed= PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
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
                    currentSkillLevel[0]++;
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
                                float value1 = WeaponDataManager.playerAOneSpeed * 0.05f;
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = WeaponDataManager.playerAOneAtk * 0.05f;
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    currentSkillLevel[1]++;
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
                                float value1 = WeaponDataManager.playerATwoCoolTime * 0.05f;
                                WeaponDataManager.playerATwoCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerATwoAtk * 0.05f;
                                WeaponDataManager.playerATwoAtk += value2;
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    currentSkillLevel[2]++;
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
                                float value1 = WeaponDataManager.playerAThreeCoolTime * 0.05f;
                                WeaponDataManager.playerAThreeCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerAThreeAtk * 0.05f;
                                WeaponDataManager.playerAThreeAtk += value2;
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    currentSkillLevel[3]++;
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
                                float value1 = WeaponDataManager.playerAFourTime * 0.05f;
                                WeaponDataManager.playerAFourTime += value1;
                                break;

                            case 1: // 쿨타임
                                float value2 = WeaponDataManager.playerAFourCoolTime * 0.05f;
                                WeaponDataManager.playerAFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4: //기본 공격
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            float value1 = WeaponDataManager.playerABasicAtkCool * 0.05f;
                            WeaponDataManager.playerABasicAtkCool -= value1;
                            break;

                        case 1: // 데미지 증가
                            float value2 = WeaponDataManager.playerABasicAtkDamage * 0.05f;
                            WeaponDataManager.playerABasicAtkDamage += value2;
                            break;
                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if (CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch (buttonB)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerBSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk1");
                        playerBSkillA = false;
                    }
                    else if (!playerBSkillA)
                    {
                        float value1 = WeaponDataManager.playerBOneAtk * 0.05f;
                        WeaponDataManager.playerBOneAtk += value1; //  우선 데미지 증가만 구현
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerBSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk2");
                        playerBSkillB = false;
                    }
                    else if (!playerBSkillB)
                    {
                        float value1 = WeaponDataManager.playerBTwoSize * 0.05f;
                        WeaponDataManager.playerBTwoSize += value1;
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerBSkillC)
                    {
                        playerBSkillC = false;
                        WeaponManager.Instance.StartPattern("playerBatk3");
                    }
                    else if (!playerBSkillC) // 데미지 증가
                    {
                        float value1 = WeaponDataManager.playerBThreeDamage * 0.05f;
                        WeaponDataManager.playerBThreeDamage += value1;
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerBSkillD)
                    {
                        playerBSkillD = false;
                        WeaponManager.Instance.StartPattern("playerBatk4");
                    }
                    else if (!playerBSkillD)
                    {
                        switch (Bskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerBFourCoolTime * 0.05f;
                                WeaponDataManager.playerBFourCoolTime -= value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerBFourTime * 0.05f;
                                WeaponDataManager.playerBFourTime += value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            float value2 = WeaponDataManager.playerBBasicDamage * 0.05f;
                            WeaponDataManager.playerBBasicDamage += value2;
                            break;
                    }
                    break;

                case 5: // atk
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // hp
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // def
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // speed
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if (CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch (buttonB)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerCSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playeCatk1");
                        playerCSkillA = false;
                    }
                    else if (!playerCSkillA)
                    {
                        switch (Cskill1)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCOneContinueTime * 0.05f;
                                WeaponDataManager.playerCOneContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCOneCoolTime * 0.05f;
                                WeaponDataManager.playerCOneCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.plyaerCOneDamage * 0.05f;
                                WeaponDataManager.plyaerCOneDamage += value3;
                                break;

                        }
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerCSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk2");
                        playerCSkillB = false;
                    }
                    else if (!playerCSkillB)
                    {
                        switch (Cskill2)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCTwoAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCTwoAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCTwoCoolTime * 0.05f;
                                WeaponDataManager.playerCTwoCoolTime -= value2;

                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCTwoDamage * 0.05f;
                                WeaponDataManager.playerCTwoDamage += value3;
                                break;
                        }
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerCSkillC)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk3");
                        playerCSkillC = false;
                    }
                    else if (!playerCSkillC)
                    {
                        switch (Cskill3)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCThreeAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCThreeAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCThreeCoolTime * 0.05f;
                                WeaponDataManager.playerCThreeCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCThreeAtkSize * 0.05f;
                                WeaponDataManager.playerCThreeAtkSize += value3;
                                break;
                        }
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerCSkillD)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk4");
                        playerCSkillD = false;
                    }
                    else if (playerCSkillD)
                    {
                        switch (Cskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCFourAtkTime * 0.05f;
                                WeaponDataManager.playerCFourAtkTime += value1;

                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCFourCoolTime * 0.05f;
                                WeaponDataManager.playerCFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch (CskillBasic)
                    {
                        case 0:
                            float value1 = WeaponDataManager.playerCBasicAtkTime * 0.05f;
                            WeaponDataManager.playerCBasicAtkTime -= value1;
                            break;

                        case 1:
                            float value2 = WeaponDataManager.playerCBasicCoolTime * 0.05f;
                            WeaponDataManager.playerCBasicCoolTime -= value2;
                            break;

                        case 2:
                            float value3 = WeaponDataManager.playerCBasicAtkDamage * 0.05f;
                            WeaponDataManager.playerCBasicAtkDamage -= value3;
                            break;


                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueDamage = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueDamage;
                    break;

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
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
                    currentSkillLevel[0]++;
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
                                float value1 = WeaponDataManager.playerAOneSpeed * 0.05f;
                                WeaponDataManager.playerAOneSpeed += value1;
                                break;

                            case 1: // 데미지 증가
                                //Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                float value2 = WeaponDataManager.playerAOneAtk * 0.05f;
                                WeaponDataManager.playerAOneAtk += value2;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
                    currentSkillLevel[1]++;
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
                                float value1 = WeaponDataManager.playerATwoCoolTime * 0.05f;
                                WeaponDataManager.playerATwoCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerATwoAtk * 0.05f;
                                WeaponDataManager.playerATwoAtk += value2;
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    currentSkillLevel[2]++;
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
                                float value1 = WeaponDataManager.playerAThreeCoolTime * 0.05f;
                                WeaponDataManager.playerAThreeCoolTime -= value1;
                                break;

                            case 1: // 데미지 증가
                                float value2 = WeaponDataManager.playerAThreeAtk * 0.05f;
                                WeaponDataManager.playerAThreeAtk += value2;
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    currentSkillLevel[3]++;
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
                                float value1 = WeaponDataManager.playerAFourTime * 0.05f;
                                WeaponDataManager.playerAFourTime += value1;
                                break;

                            case 1: // 쿨타임
                                float value2 = WeaponDataManager.playerAFourCoolTime * 0.05f;
                                WeaponDataManager.playerAFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4: //기본 공격
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            float value1 = WeaponDataManager.playerABasicAtkCool * 0.05f;
                            WeaponDataManager.playerABasicAtkCool -= value1;
                            break;

                        case 1: // 데미지 증가
                            float value2 = WeaponDataManager.playerABasicAtkDamage * 0.05f;
                            WeaponDataManager.playerABasicAtkDamage += value2;
                            break;
                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if (CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch (buttonC)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerBSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk1");
                        playerBSkillA = false;
                    }
                    else if (!playerBSkillA)
                    {
                        float value1 = WeaponDataManager.playerBOneAtk * 0.05f;
                        WeaponDataManager.playerBOneAtk += value1; //  우선 데미지 증가만 구현
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerBSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerBatk2");
                        playerBSkillB = false;
                    }
                    else if (!playerBSkillB)
                    {
                        float value1 = WeaponDataManager.playerBTwoSize * 0.05f;
                        WeaponDataManager.playerBTwoSize += value1;
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerBSkillC)
                    {
                        playerBSkillC = false;
                        WeaponManager.Instance.StartPattern("playerBatk3");
                    }
                    else if (!playerBSkillC) // 데미지 증가
                    {
                        float value1 = WeaponDataManager.playerBThreeDamage * 0.05f;
                        WeaponDataManager.playerBThreeDamage += value1;
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerBSkillD)
                    {
                        playerBSkillD = false;
                        WeaponManager.Instance.StartPattern("playerBatk4");
                    }
                    else if (!playerBSkillD)
                    {
                        switch (Bskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerBFourCoolTime * 0.05f;
                                WeaponDataManager.playerBFourCoolTime -= value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerBFourTime * 0.05f;
                                WeaponDataManager.playerBFourTime += value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            float value2 = WeaponDataManager.playerBBasicDamage * 0.05f;
                            WeaponDataManager.playerBBasicDamage += value2;
                            break;
                    }
                    break;

                case 5: // atk
                    currentSkillLevel[4]++;
                    float valueAtk = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueAtk;
                    break;

                case 6: // hp
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // def
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // speed
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
                    break;
            }
        }
        else if (CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch (buttonC)
            {
                case 0:
                    currentSkillLevel[0]++;
                    if (playerCSkillA)
                    {
                        WeaponManager.Instance.StartPattern("playeCatk1");
                        playerCSkillA = false;
                    }
                    else if (!playerCSkillA)
                    {
                        switch (Cskill1)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCOneContinueTime * 0.05f;
                                WeaponDataManager.playerCOneContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCOneCoolTime * 0.05f;
                                WeaponDataManager.playerCOneCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.plyaerCOneDamage * 0.05f;
                                WeaponDataManager.plyaerCOneDamage += value3;
                                break;

                        }
                    }
                    break;

                case 1:
                    currentSkillLevel[1]++;
                    if (playerCSkillB)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk2");
                        playerCSkillB = false;
                    }
                    else if (!playerCSkillB)
                    {
                        switch (Cskill2)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCTwoAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCTwoAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCTwoCoolTime * 0.05f;
                                WeaponDataManager.playerCTwoCoolTime -= value2;

                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCTwoDamage * 0.05f;
                                WeaponDataManager.playerCTwoDamage += value3;
                                break;
                        }
                    }
                    break;

                case 2:
                    currentSkillLevel[2]++;
                    if (playerCSkillC)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk3");
                        playerCSkillC = false;
                    }
                    else if (!playerCSkillC)
                    {
                        switch (Cskill3)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCThreeAtkContinueTime * 0.05f;
                                WeaponDataManager.playerCThreeAtkContinueTime += value1;
                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCThreeCoolTime * 0.05f;
                                WeaponDataManager.playerCThreeCoolTime -= value2;
                                break;

                            case 2:
                                float value3 = WeaponDataManager.playerCThreeAtkSize * 0.05f;
                                WeaponDataManager.playerCThreeAtkSize += value3;
                                break;
                        }
                    }
                    break;

                case 3:
                    currentSkillLevel[3]++;
                    if (playerCSkillD)
                    {
                        WeaponManager.Instance.StartPattern("playerCatk4");
                        playerCSkillD = false;
                    }
                    else if (playerCSkillD)
                    {
                        switch (Cskill4)
                        {
                            case 0:
                                float value1 = WeaponDataManager.playerCFourAtkTime * 0.05f;
                                WeaponDataManager.playerCFourAtkTime += value1;

                                break;

                            case 1:
                                float value2 = WeaponDataManager.playerCFourCoolTime * 0.05f;
                                WeaponDataManager.playerCFourCoolTime -= value2;
                                break;
                        }
                    }
                    break;

                case 4:
                    switch (CskillBasic)
                    {
                        case 0:
                            float value1 = WeaponDataManager.playerCBasicAtkTime * 0.05f;
                            WeaponDataManager.playerCBasicAtkTime -= value1;
                            break;

                        case 1:
                            float value2 = WeaponDataManager.playerCBasicCoolTime * 0.05f;
                            WeaponDataManager.playerCBasicCoolTime -= value2;
                            break;

                        case 2:
                            float value3 = WeaponDataManager.playerCBasicAtkDamage * 0.05f;
                            WeaponDataManager.playerCBasicAtkDamage -= value3;
                            break;


                    }
                    break;

                case 5: // 공격력
                    currentSkillLevel[4]++;
                    float valueDamage = PlayerState.Damage * 0.05f;
                    PlayerState.Damage += valueDamage;
                    break;

                case 6: // 체력
                    currentSkillLevel[5]++;
                    float valueHp = PlayerState.Hp * 0.05f;
                    PlayerState.Hp += valueHp;
                    break;

                case 7: // 방어력
                    currentSkillLevel[6]++;
                    float valueDef = PlayerState.Defense * 0.05f;
                    PlayerState.Defense += valueDef;
                    break;

                case 8: // 이동속도
                    currentSkillLevel[7]++;
                    float valueSpeed = PlayerState.Speed * 0.05f;
                    PlayerState.Speed += valueSpeed;
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
                    PropertyDescriptions[0].text = "스킬";
                    if (playerASkillA)
                    {
                        nameDescriptions[0].text = "단절된 정신";
                        Descriptions[0].text = "주위로 에너지를 회전시킵니다.";
                    }
                    else if (!playerASkillA)
                    {
                        Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                nameDescriptions[0].text = "단절된 정신";
                                Descriptions[0].text = "회전속도 증가\n + 0.5%";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[0].text = "단절된 정신";
                                Descriptions[0].text = "데미지 증가\n + 0.5% ";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerASkillB)
                    {
                        nameDescriptions[0].text = "E.C.T";
                        Descriptions[0].text = "직선형태의 에너지를 방출 시킵니다.";
                    }
                    else
                    {
                        Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                nameDescriptions[0].text = "E.C.T";
                                Descriptions[0].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[0].text = "E.C.T";
                                Descriptions[0].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[2];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerASkillC)
                    {
                        nameDescriptions[0].text = "광공해";
                        Descriptions[0].text = "무차별 광역 공격을 합니다.";
                    }
                    else
                    {
                        Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                nameDescriptions[0].text = "광공해";
                                Descriptions[0].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[0].text = "광공해";
                                Descriptions[0].text = "데미지 증가\n + 0.5% ";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerASkillD)
                    {
                        nameDescriptions[0].text = "정체된 정신";
                        Descriptions[0].text = "적들을 마비시켜 움직임을 제어합니다.";
                    }
                    else
                    {
                        Askill4 = Random.Range(0, 2);
                        switch(Askill4)
                        {
                            case 0:
                                nameDescriptions[0].text = "정체된 정신";
                                Descriptions[0].text = "속박 시간 증가\n + 0.5%";
                                break;

                            case 1:
                                nameDescriptions[0].text = "정체된 정신";
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    AskillBasic = Random.Range(0, 2);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    PropertyDescriptions[0].text = "기본 공격";
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            nameDescriptions[0].text = "";
                            Descriptions[0].text = "공격 딜레이 감소\n - 0.5%";
                            break;

                        case 1: // 데미지 증가
                            nameDescriptions[0].text = "";
                            Descriptions[0].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    IconImagePanel[0].sprite = SkillSprites[4];
                    PropertyDescriptions[0].text = "능력치";
                    nameDescriptions[0].text = "";
                    Descriptions[0].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    IconImagePanel[0].sprite = SkillSprites[5];
                    PropertyDescriptions[0].text = "능력치";
                    nameDescriptions[0].text = "";
                    Descriptions[0].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    IconImagePanel[0].sprite = SkillSprites[6];
                    PropertyDescriptions[0].text = "능력치";
                    nameDescriptions[0].text = "";
                    Descriptions[0].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    IconImagePanel[0].sprite = SkillSprites[7];
                    PropertyDescriptions[0].text = "능력치";
                    nameDescriptions[0].text = "";
                    Descriptions[0].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonB)
            {
                case 0: // 1번
                    IconImagePanel[1].sprite = SkillSprites[0];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerASkillA)
                    {
                        nameDescriptions[1].text = "단절된 정신";
                        Descriptions[1].text = "주위로 에너지를 회전시킵니다.";
                    }
                    else if (!playerASkillA)
                    {
                        Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                nameDescriptions[1].text = "단절된 정신";
                                Descriptions[1].text = "회전속도 증가\n + 0.5%";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[1].text = "단절된 정신";
                                Descriptions[1].text = "데미지 증가\n + 0.5%";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerASkillB)
                    {
                        nameDescriptions[1].text = "E.C.T";
                        Descriptions[1].text = "직선형태의 에너지를 방출 시킵니다.";
                    }
                    else
                    {
                         Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                nameDescriptions[1].text = "E.C.T";
                                Descriptions[1].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[1].text = "E.C.T";
                                Descriptions[1].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[1].sprite = SkillSprites[2];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerASkillC)
                    {
                        nameDescriptions[1].text = "광공해";
                        Descriptions[1].text = "무차별 광역 공격을 합니다.";
                    }
                    else
                    {
                         Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                nameDescriptions[1].text = "광공해";
                                Descriptions[1].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[1].text = "광공해";
                                Descriptions[1].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[1].sprite = SkillSprites[3];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerASkillD)
                    {
                        nameDescriptions[1].text = "정체된 정신";
                        Descriptions[1].text = "적들을 마비시켜 움직임을 제어합니다.";
                    }
                    else
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                nameDescriptions[1].text = "정체된 정신";
                                Descriptions[0].text = "속박 시간 증가\n + 0.5% ";
                                break;

                            case 1:
                                nameDescriptions[1].text = "정체된 정신";
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                     AskillBasic = Random.Range(0, 2);
                    IconImagePanel[1].sprite = SkillSprites[2];
                    PropertyDescriptions[1].text = "기본 공격";
                    switch (AskillBasic)
                    {
                        case 0: // 빈도
                            nameDescriptions[1].text = "";
                            Descriptions[1].text = "공격 딜레이 감소\n - 0.5%";
                            break;

                        case 1: // 데미지 증가
                            nameDescriptions[1].text = "";
                            Descriptions[1].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[4];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[5]; 
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[6];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[7];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1번
                    IconImagePanel[2].sprite = SkillSprites[0];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerASkillA)
                    {
                        nameDescriptions[2].text = "단절된 정신";
                        Descriptions[2].text = "주위로 에너지를 회전시킵니다";
                    }
                    else if (!playerASkillA)
                    {
                         Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                nameDescriptions[2].text = "단절된 정신";
                                Descriptions[2].text = "회전속도 증가\n + 0.5%";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[2].text = "단절된 정신";
                                Descriptions[2].text = "데미지 증가\n + 0.5%";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[2].sprite = SkillSprites[1];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerASkillB)
                    {
                        nameDescriptions[2].text = "E.C.T";
                        Descriptions[2].text = "직선형태의 에너지를 방출 시킵니다.";
                    }
                    else
                    {
                         Askill2 = Random.Range(0, 2);
                        switch (Askill2)
                        {
                            case 0: // 빈도
                                nameDescriptions[2].text = "E.C.T";
                                Descriptions[2].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[2].text = "E.C.T";
                                Descriptions[2].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[2].sprite = SkillSprites[2];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerASkillC)
                    {
                        nameDescriptions[2].text = "광공해 ";
                        Descriptions[2].text = "무차별 광역 공격을 합니다.";
                    }
                    else
                    {
                         Askill3 = Random.Range(0, 2);
                        switch (Askill3)
                        {
                            case 0: // 빈도
                                nameDescriptions[2].text = "광공해 ";
                                Descriptions[2].text = "공격 딜레이 감소\n - 0.5%";
                                break;

                            case 1: // 데미지 증가
                                nameDescriptions[2].text = "광공해 ";
                                Descriptions[2].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[2].sprite = SkillSprites[3];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerASkillD)
                    {
                        nameDescriptions[2].text = "정체된 정신 ";
                        Descriptions[2].text = "적들을 마비시켜 움직임을 제어합니다.";
                    }
                    else
                    {
                        Askill4 = Random.Range(0, 2);
                        switch (Askill4)
                        {
                            case 0:
                                nameDescriptions[2].text = "정체된 정신 ";
                                Descriptions[0].text = "속박 시간 증가\n + 0.5% ";
                                break;

                            case 1:
                                nameDescriptions[2].text = "정체된 정신 ";
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                     AskillBasic = Random.Range(0, 2);
                    PropertyDescriptions[2].text = "기본 공격";
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (AskillBasic)
                    {
                        case 0: // 빈도

                            Descriptions[2].text = "공격 딜레이 감소\n - 0.5%";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[2].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    IconImagePanel[2].sprite = SkillSprites[4];
                    PropertyDescriptions[2].text = "능력치";
                    nameDescriptions[2].text = "";
                    Descriptions[2].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    IconImagePanel[2].sprite = SkillSprites[5];
                    PropertyDescriptions[2].text = "능력치";
                    nameDescriptions[2].text = "";
                    Descriptions[2].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    IconImagePanel[2].sprite = SkillSprites[6];
                    PropertyDescriptions[2].text = "능력치";
                    nameDescriptions[2].text = "";
                    Descriptions[2].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    IconImagePanel[2].sprite = SkillSprites[7];
                    PropertyDescriptions[2].text = "능력치";
                    nameDescriptions[2].text = "";
                    Descriptions[2].text = "이동속도 증가\n + 0.5%";
                    break;
            }
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    IconImagePanel[0].sprite = SkillSprites[0];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerBSkillA)
                    {
                        nameDescriptions[0].text = "다가오는 상흔";
                        Descriptions[0].text = "다시 되돌아오는 도끼를 던집니다.";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                nameDescriptions[0].text = "다가오는 상흔";
                                Descriptions[0].text = "데미지 증가\n + 0.5%";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;    
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerBSkillB)
                    {
                        nameDescriptions[0].text = "주시하는 상흔";
                        Descriptions[0].text = "도끼를 던져 적들의 이동을 제한합니다.";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                nameDescriptions[0].text = "주시하는 상흔";
                                Descriptions[0].text = "마그네틱 범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerBSkillC)
                    {
                        nameDescriptions[0].text = "주시하는 상흔";
                        Descriptions[0].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // 빈도
                                nameDescriptions[0].text = "주시하는 상흔";
                                Descriptions[0].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerBSkillD)
                    {
                        nameDescriptions[0].text = "상흔기록";
                        Descriptions[0].text = "한순간 주위의 모든것이 느려질 정도의 속도를 가집니다.";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch(Bskill4)
                        {
                            case 0:
                                nameDescriptions[0].text = "상흔기록";
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 1:
                                nameDescriptions[0].text = "상흔기록";
                                Descriptions[0].text = "버프 시간 증가\n + 0.5%";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    BskillBasic = Random.Range(0, 1);
                    nameDescriptions[0].text = "";
                    PropertyDescriptions[0].text = "기본 공격";
                    IconImagePanel[0].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[0].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[4];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[5];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[6];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[7];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonB)
            {
                case 0: // 1번
                    IconImagePanel[1].sprite = SkillSprites[0];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerBSkillA)
                    {
                        nameDescriptions[1].text = "다가오는 상흔";
                        Descriptions[1].text = "다시 되돌아오는 도끼를 던집니다.";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                nameDescriptions[1].text = "다가오는 상흔";
                                Descriptions[1].text = "데미지 증가\n + 0.5 % ";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerBSkillB)
                    {
                        nameDescriptions[1].text = "주시하는 상흔";
                        Descriptions[1].text = "도끼를 던져 적들의 이동을 제한합니다.";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                nameDescriptions[1].text = "주시하는 상흔";
                                Descriptions[1].text = "마그네틱 범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[1].sprite = SkillSprites[1];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerBSkillC)
                    {
                        nameDescriptions[1].text = "주시하는 상흔";
                        Descriptions[1].text = "3번스킬 사용가능";
                    }
                    else
                    {
                        Bskill3 = Random.Range(0, 1);
                        switch (Bskill3)
                        {
                            case 0: // 빈도
                                nameDescriptions[1].text = "주시하는 상흔";
                                Descriptions[1].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[1].sprite = SkillSprites[3];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerBSkillD)
                    {
                        nameDescriptions[1].text = "상흔기록";
                        Descriptions[1].text = "한순간 주위의 모든것이 느려질 정도의 속도를 가집니다.";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                nameDescriptions[1].text = "상흔기록";
                                Descriptions[1].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 1:
                                nameDescriptions[1].text = "상흔기록";
                                Descriptions[1].text = "버프 시간 증가\n + 0.5%";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    BskillBasic = Random.Range(0, 1); PropertyDescriptions[1].text = "기본 공격";
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            nameDescriptions[1].text = "";
                            Descriptions[1].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[4];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[5];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[6];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[7];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1번
                    IconImagePanel[2].sprite = SkillSprites[0];
                    nameDescriptions[2].text = "다가오는 상흔";
                    PropertyDescriptions[2].text = "스킬";
                    if (playerBSkillA)
                    {
                        Descriptions[2].text = "다시 되돌아오는 도끼를 던집니다.";
                    }
                    else if (!playerBSkillA)
                    {
                        Bskill1 = Random.Range(0, 1);
                        switch (Bskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "데미지 증가\n + 0.5%";
                                // WeaponDataManager.playerAOneSpeed += 1;
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    nameDescriptions[2].text = "주시하는 상흔";
                    IconImagePanel[2].sprite = SkillSprites[1];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerBSkillB)
                    {
                        Descriptions[2].text = "도끼를 던져 적들의 이동을 제한합니다.";
                    }
                    else
                    {
                        Bskill2 = Random.Range(0, 1);
                        switch (Bskill2)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "마그네틱 범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    nameDescriptions[2].text = "주시하는 상흔";
                    IconImagePanel[2].sprite = SkillSprites[1];
                    PropertyDescriptions[2].text = "스킬";
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
                                Descriptions[2].text = "데미지 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    nameDescriptions[2].text = "상흔기록";
                    IconImagePanel[2].sprite = SkillSprites[3];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerBSkillD)
                    {
                        Descriptions[2].text = "한순간 주위의 모든것이 느려질 정도의 속도를 가집니다.";
                    }
                    else
                    {
                        Bskill4 = Random.Range(0, 2);
                        switch (Bskill4)
                        {
                            case 0:
                                Descriptions[2].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 1:
                                Descriptions[2].text = "버프 시간 증가\n + 0.5%";
                                break;
                        }
                    }
                    //WeaponDataManager.playerAFourTime += 0.25f;

                    break;

                case 4: //기본 공격
                    nameDescriptions[2].text = "";
                    BskillBasic = Random.Range(0, 1);
                    PropertyDescriptions[2].text = "기본 공격";
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (BskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[2].text = "데미지 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[4];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[5];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[6];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[7];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "이동속도 증가\n + 0.5%";
                    break;
            }
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    nameDescriptions[0].text = "고통과 환희";
                    IconImagePanel[0].sprite = SkillSprites[0];
                    PropertyDescriptions[0].text = "스킬";
                    if (playerCSkillA)
                    {
                        Descriptions[0].text = "적에게 고통을 주는 장판을 생성합니다.";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[0].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[0].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    nameDescriptions[0].text = "고통과 전이";
                    PropertyDescriptions[0].text = "스킬";
                    if (playerCSkillB)
                    {
                        Descriptions[0].text = "캐릭터의 이동한 지점에 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2:
                                Descriptions[0].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    IconImagePanel[0].sprite = SkillSprites[1];
                    PropertyDescriptions[0].text = "스킬";
                    nameDescriptions[0].text = "윤회의 시작";
                    if (playerCSkillC)
                    {
                        Descriptions[0].text = "적의 체력을 흡수하는 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[0].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[0].text = "범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    IconImagePanel[0].sprite = SkillSprites[3];
                    PropertyDescriptions[0].text = "스킬";
                    nameDescriptions[0].text = "타종";
                    if (playerCSkillD)
                    {
                        Descriptions[0].text = "캐릭터가 바라보는 방향으로 공격을 합니다.";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch(Cskill4)
                        {
                            case 0:
                                Descriptions[0].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1:
                                Descriptions[0].text = "쿨타임 감소\n - 0.5%";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    CskillBasic = Random.Range(0, 3);
                    IconImagePanel[0].sprite = SkillSprites[2];
                    nameDescriptions[0].text = "";
                    PropertyDescriptions[0].text = "기본 공격";
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[0].text = "공격 지속시간 증가\n + 0.5%";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[0].text = "장전 시간 감소\n - 0.5%";
                            break;

                        case 2:
                            Descriptions[0].text = "공격력 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[4];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[5];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[6];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[0].text = "";
                    IconImagePanel[0].sprite = SkillSprites[7];
                    PropertyDescriptions[0].text = "능력치";
                    Descriptions[0].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonB)
            {
                case 0: // 1번
                    nameDescriptions[1].text = "고통과 환희";
                    IconImagePanel[1].sprite = SkillSprites[0];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerCSkillA)
                    {
                        Descriptions[1].text = "적에게 고통을 주는 장판을 생성합니다.";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소\n - 0.5%";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[1].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    nameDescriptions[1].text = "고통과 전이";
                    IconImagePanel[1].sprite = SkillSprites[1];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerCSkillB)
                    {
                        Descriptions[1].text = "캐릭터의 이동한 지점에 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2:
                                Descriptions[1].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    nameDescriptions[1].text = "윤회의 시작";
                    IconImagePanel[1].sprite = SkillSprites[1];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerCSkillC)
                    {
                        Descriptions[1].text = "적의 체력을 흡수하는 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[1].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[1].text = "범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    nameDescriptions[1].text = "타종";
                    IconImagePanel[1].sprite = SkillSprites[3];
                    PropertyDescriptions[1].text = "스킬";
                    if (playerCSkillD)
                    {
                        Descriptions[1].text = "캐릭터가 바라보는 방향으로 공격을 합니다.";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[1].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1:
                                Descriptions[1].text = "쿨타임 감소\n - 0.5%";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    nameDescriptions[1].text = "";
                    CskillBasic = Random.Range(0, 3);
                    PropertyDescriptions[1].text = "기본 공격";
                    IconImagePanel[1].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[1].text = "공격 지속시간 증가\n + 0.5%";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[1].text = "장전 시간 감소\n - 0.5%";
                            break;

                        case 2:
                            Descriptions[1].text = "공격력 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[4];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[5];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[6];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[1].text = "";
                    IconImagePanel[1].sprite = SkillSprites[7];
                    PropertyDescriptions[1].text = "능력치";
                    Descriptions[1].text = "이동속도 증가\n + 0.5%";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1번
                    nameDescriptions[2].text = "고통과 환희";
                    IconImagePanel[2].sprite = SkillSprites[0];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerCSkillA)
                    {
                        Descriptions[2].text = "적에게 고통을 주는 장판을 생성합니다.";
                    }
                    else if (!playerCSkillA)
                    {
                        Cskill1 = Random.Range(0, 3);
                        switch (Cskill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소\n - 0.5%";
                                //     WeaponDataManager.playerAOneAtk += 5;
                                break;

                            case 2:
                                Descriptions[2].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 1: // 2번
                    nameDescriptions[2].text = "고통과 전이";
                    IconImagePanel[2].sprite = SkillSprites[1];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerCSkillB)
                    {
                        Descriptions[2].text = "캐릭터의 이동한 지점에 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill2 = Random.Range(0, 3);
                        switch (Cskill2)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2:
                                Descriptions[2].text = "공격력 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 2: // 3번
                    nameDescriptions[2].text = "윤회의 시작";
                    IconImagePanel[2].sprite = SkillSprites[1];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerCSkillC)
                    {
                        Descriptions[2].text = "적의 체력을 흡수하는 장판을 생성합니다.";
                    }
                    else
                    {
                        Cskill3 = Random.Range(0, 3);
                        switch (Cskill3)
                        {
                            case 0: // 빈도
                                Descriptions[2].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "쿨타임 감소\n - 0.5%";
                                break;

                            case 2: // 데미지 증가
                                Descriptions[2].text = "범위 증가\n + 0.5%";
                                break;
                        }
                    }
                    break;

                case 3: // 4번 시간증가
                    nameDescriptions[2].text = "타종";
                    IconImagePanel[2].sprite = SkillSprites[3];
                    PropertyDescriptions[2].text = "스킬";
                    if (playerCSkillD)
                    {
                        Descriptions[2].text = "캐릭터가 바라보는 방향으로 공격을 합니다.";
                    }
                    else
                    {
                        Cskill4 = Random.Range(0, 2);
                        switch (Cskill4)
                        {
                            case 0:
                                Descriptions[2].text = "공격 지속시간 증가\n + 0.5%";
                                break;

                            case 1:
                                Descriptions[2].text = "쿨타임 감소\n - 0.5%";
                                break;
                        }

                    }

                    break;

                case 4: //기본 공격
                    nameDescriptions[2].text = "";
                    CskillBasic = Random.Range(0, 3);
                    PropertyDescriptions[2].text = "기본 공격";
                    IconImagePanel[2].sprite = SkillSprites[2];
                    switch (CskillBasic)
                    {
                        case 0: // 빈도
                            Descriptions[2].text = "공격 지속시간 증가\n + 0.5%";
                            break;

                        case 1: // 데미지 증가
                            Descriptions[2].text = "장전 시간 감소\n - 0.5%";
                            break;

                        case 2:
                            Descriptions[2].text = "공격력 증가\n + 0.5%";
                            break;
                    }
                    break;

                case 5: // 공격력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[4];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "공격력 증가\n + 0.5%";
                    break;

                case 6: // 체력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[5];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "체력 증가\n + 0.5%";
                    break;

                case 7: // 방어력
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[6];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "방어력 증가\n + 0.5%";
                    break;

                case 8: // 이동속도
                    nameDescriptions[2].text = "";
                    IconImagePanel[2].sprite = SkillSprites[7];
                    PropertyDescriptions[2].text = "능력치";
                    Descriptions[2].text = "이동속도 증가\n + 0.5%";
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

        for(int e = 0; e< gameLevelText.Length; ++e)
        {
            if (currentSkillLevel[e] >= 1)
                gameLevelText[e].text = currentSkillLevel[e].ToString();
            else
                gameLevelText[e].text = "";

            panelLevelText[e].text = currentSkillLevel[e].ToString();
        }
        

        
    }
}
