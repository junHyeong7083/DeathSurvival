using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DieTxtManager : MonoBehaviour
{
    public Text[] PlayerADamage;
    int PlayerAskillTime;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAskillTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #region PlayerA Skill4 TimeSave
        if (WeaponDataManager.playerAFourbool)
            PlayerAskillTime +=(int )Time.deltaTime;
        #endregion
        PlayerADamage[0].text = "기본공격 : " + MonsterController.PlayerABasicDamage.ToString();
        PlayerADamage[1].text = "1번스킬 : " + MonsterController.PlayerAOneDamage.ToString();
        PlayerADamage[2].text = "2번스킬 : " + MonsterController.PlayerATwoDamage.ToString();
        PlayerADamage[3].text = "3번스킬 : " + MonsterController.PlayerAThreeDamage.ToString();
        PlayerADamage[4].text = "4번스킬 : " + PlayerAskillTime.ToString("F2") + "초";
    }
}
