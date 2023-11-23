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
    public void SelectA() // 증강 들어갈거설정
    {
        isSelect = true;
        if(CharacterManager.Instance.currentCharacter == Character.White)
        {
            switch (buttonA)
            {
                case 0: // 1번
                    if(playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[0].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if(!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[0].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[0].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }
                    
                    break;

                case 1: // 2번
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[0].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[0].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[0].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[0].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[0].text = "이동속도 증가";
                    break;
            }
        }
    }
    public void SelectB() // 증강 들어갈거설정
    {
        isSelect = true;
        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            Debug.Log("WHITE");
            switch (buttonB)
            {

                case 0: // 1번
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[1].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[1].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[1].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[1].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[1].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[1].text = "이동속도 증가";
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
                    if (playerASkillA)
                    {
                        Descriptions[0].text = "1번스킬 사용가능";
                        playerASkillA = false;
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[0].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[0].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[0].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[0].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[0].text = "이동속도 증가";
                    break;
            }
            switch (buttonB)
            {

                case 0: // 1번
                    if (playerASkillA)
                    {
                    //    WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[1].text = "1번스킬 사용가능";
                      // playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[1].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                            //    WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[1].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                              //  WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[1].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    //WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[1].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[1].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[1].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[1].text = "이동속도 증가";
                    break;
            }
            switch (buttonC)
            {
                case 0: // 1번
                    if (playerASkillA)
                    {
                        WeaponManager.Instance.StartPattern("atk1");
                        Descriptions[2].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                           //     WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                            //    WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[2].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                  //  WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[2].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[2].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[2].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[2].text = "이동속도 증가";
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
                        Descriptions[2].text = "1번스킬 사용가능";
                        playerASkillA = false;
                    }
                    else if (!playerASkillA)
                    {
                        int Askill1 = Random.Range(0, 2);
                        switch (Askill1)
                        {
                            case 0: // 재생속도 증가x
                                Descriptions[2].text = "1번스킬 회전속도 1증가 \n 현재 속도 : " + WeaponDataManager.playerAOneSpeed.ToString();
                                WeaponDataManager.playerAOneSpeed += 1;
                                break;

                            case 1: // 데미지 증가
                                Descriptions[2].text = "1번스킬 데미지 5증가 \n 현재 데미지 : " + WeaponDataManager.playerAOneAtk.ToString();
                                WeaponDataManager.playerAOneAtk += 5;
                                break;
                        }
                    }

                    break;

                case 1: // 2번
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
                    break;

                case 2: // 3번
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
                    break;

                case 3: // 4번 시간증가
                    Descriptions[2].text = "4번스킬 속박 시간 증가 \n 현재 속박 시간 : " + WeaponDataManager.playerAFourTime.ToString();
                    WeaponDataManager.playerAFourTime += 0.25f;
                    break;

                case 4: //기본 공격
                    int AskillBasic = Random.Range(0, 2);
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
                    Descriptions[2].text = "공격력 증가";
                    break;

                case 6: // 체력
                    Descriptions[2].text = "체력 증가";
                    break;

                case 7: // 방어력
                    Descriptions[2].text = "방어력 증가";
                    break;

                case 8: // 이동속도
                    Descriptions[2].text = "이동속도 증가";
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
