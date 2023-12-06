using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_Atk3 : MonoBehaviour
{
    public GameObject topEffect;
    public GameObject healCircle;
    Animator mainanimator;
    Animator topanimator;

    float checkTime; // 스킬 찍자마자 공격이 가능하도록
    float attackTime = 0f;
    bool isAttack = false;

    float sizeUp = 10f;
    Vector3 originAtkPanelSize;
    void Start()
    {
        originAtkPanelSize = healCircle.transform.localScale;
        checkTime = WeaponDataManager.playerCThreeCoolTime;
        mainanimator = GetComponent<Animator>();
        topanimator =topEffect.GetComponent<Animator>();
    }

    bool isOnes = false;
    void Update()
    {
        this.transform.position =new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y-0.1f, PlayerController.PlayerPos.z);


      if (checkTime >= WeaponDataManager.playerCThreeCoolTime)
        {
            isAttack = true;
            if(!isOnes)
            {
                mainanimator.SetTrigger("isAttack");
                topanimator.SetBool("isAttack", true);

                isOnes = true;
            }

            if (healCircle.transform.localScale.x <= WeaponDataManager.playerCThreeAtkSize)
            {
                healCircle.transform.localScale += new Vector3(sizeUp * Time.deltaTime, sizeUp * Time.deltaTime, 0f);
            }


            checkTime = WeaponDataManager.playerCThreeCoolTime;
            attackTime += Time.deltaTime;
            if(attackTime >= WeaponDataManager.playerCThreeAtkContinueTime)
            {
                if(isOnes)
                {
                    mainanimator.SetTrigger("isIdle");

                    isOnes = false;
                }
                topanimator.SetBool("isAttack", false);
                attackTime = 0f;
                isAttack = false;
                checkTime = 0f;
            }
        }

      if(!isAttack)
        {
            if (healCircle.transform.localScale.x >= originAtkPanelSize.x)
            {
                healCircle.transform.localScale -= new Vector3(sizeUp * Time.deltaTime, sizeUp * Time.deltaTime, 0f);
            }
            checkTime += Time.deltaTime;
        }
    }
}
