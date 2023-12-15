using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSkillIcon : MonoBehaviour
{
    public GameObject[] playerSet;
    public Image[] playerAIcon;
    bool timeStopCool = false;
    float timeStopCoolTime = 0f;
    private void Start()
    {
        for (int e = 0; e < playerAIcon.Length; ++e)
        {
            playerAIcon[e].gameObject.SetActive(false);
        }

    }


    private void Update()
    {
        #region Icon Setactive(true)
        if (PlayerA_Atk1.playerA_Atk1)
            playerAIcon[0].gameObject.SetActive(PlayerA_Atk1.playerA_Atk1);
       if(PlayerA_Atk2.playerA_Atk2)
            playerAIcon[1].gameObject.SetActive(PlayerA_Atk2.playerA_Atk2);
       if(PlayerA_Atk3.playerA_Atk3)
            playerAIcon[2].gameObject.SetActive(PlayerA_Atk3.playerA_Atk3);
       if(WeaponDataManager.playerAFourbool)
            playerAIcon[3].gameObject.SetActive(WeaponDataManager.playerAFourbool);
        #endregion


        if (CharacterManager.Instance.currentCharacter == Character.White)
        {
            playerSet[0].gameObject.SetActive(true);
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Blue)
        {
            playerSet[1].gameObject.SetActive(true);
        }
        else if(CharacterManager.Instance.currentCharacter == Character.Green)
        {
            playerSet[2].gameObject.SetActive(true);
        }
    }
}
