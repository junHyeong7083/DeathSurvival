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
        PlayerADamage[0].text = "�⺻���� : " + MonsterController.PlayerABasicDamage.ToString();
        PlayerADamage[1].text = "1����ų : " + MonsterController.PlayerAOneDamage.ToString();
        PlayerADamage[2].text = "2����ų : " + MonsterController.PlayerATwoDamage.ToString();
        PlayerADamage[3].text = "3����ų : " + MonsterController.PlayerAThreeDamage.ToString();
        PlayerADamage[4].text = "4����ų : " + PlayerAskillTime.ToString("F2") + "��";
    }
}
