using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Image hpBar;

    float maxHp;
    float currentHp;
    float saveHp;

    bool isHit = true;
    [SerializeField]
    float hitcoolTime;
    float hitTime = 0f;

    SpriteRenderer spriteRenderer;
    Color playerColor;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (isHit)
            {
                Debug.Log("Hit!!");
                currentHp -= 0.5f;
                isHit = false;

                playerColor = Color.blue;
                spriteRenderer.color = playerColor;
            }
        }
    }

    void Start()
    {
        maxHp = PlayerState.Hp;
        currentHp = maxHp;

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerColor = spriteRenderer.color;
    }


    float hitEffect = 0f;
    [SerializeField]
    float hitEffectcoolTime;

    void Update()
    {   
        hpBar.fillAmount = (currentHp / maxHp);
        if(PlayerState.isHpSkillPoint)
        {
            saveHp = maxHp;
            maxHp = PlayerState.Hp;
            currentHp += maxHp - saveHp;
        } // 스킬포인트 찍었다고 가정했을때 대비용

        if (!isHit)
        {
            playerColor = Color.white;
            hitEffect += Time.deltaTime;
            if(hitEffect > hitEffectcoolTime)
            {
                spriteRenderer.color = playerColor;
                hitEffect = 0f;
            }
            hitTime += Time.deltaTime;
            if (hitTime > hitcoolTime)
            {
                isHit = true;
                hitTime = 0f;
            }
        } // 피격 쿨타임


    }
}
