using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerC_Atk3 : MonoBehaviour
{
    public GameObject topEffect;
    public GameObject healCircle;
    Animator mainanimator;
    Animator topanimator;
    Image atk3Icon;
    float checkTime; // 스킬 찍자마자 공격이 가능하도록
    float attackTime = 0f;
    bool isAttack = false;

    float sizeUp = 10f;
    Vector3 originAtkPanelSize;
    CircleCollider2D circleCollider;
    void Start()
    {
        GameObject atk3IconObj = GameObject.Find("CameraCanvas/ShowSkillIcon/PlayerC/BG3/SkillC");
        if (atk3IconObj != null)
        {
            atk3Icon = atk3IconObj.GetComponent<Image>();
            atk3Icon.fillAmount = 1f;
        }

        circleCollider = healCircle.GetComponent<CircleCollider2D>();
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
            healCircle.GetComponent<CircleCollider2D>().enabled = true;
            if (!isOnes)
            {
                atk3Icon.fillAmount = 0f;

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
            float fillAmount = Mathf.Clamp(checkTime / WeaponDataManager.playerAFourCoolTime, 0, 1);
            atk3Icon.fillAmount = fillAmount;
            healCircle.GetComponent<CircleCollider2D>().enabled = false;
            if (healCircle.transform.localScale.x >= originAtkPanelSize.x)
            {
                healCircle.transform.localScale -= new Vector3(sizeUp * Time.deltaTime, sizeUp * Time.deltaTime, 0f);
            }
            checkTime += Time.deltaTime;
        }
    }
}
