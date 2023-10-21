using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    Image hpBar;

    float maxHp;
    public static float currentHp;
    float saveHp;
    public static bool isDie;
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
            if(!isDie)
            {
                if (isHit)
                {
                    //Debug.Log("Hit!!");
                    currentHp -= 0.5f;
                    isHit = false;

                    playerColor = Color.blue;
                    spriteRenderer.color = playerColor;
                }
            }
        }
    }

    private void Awake()
    {
        isDie = false;
    }
    void Start()
    { 
        hpBar = GameObject.Find("HpBar").GetComponent<Image>();
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
        Debug.Log("currentHp : " + currentHp);
        if(!isDie)
        {
            Debug.Log("State.hp : " + PlayerState.Hp);
            hpBar.fillAmount = (currentHp / maxHp);
            if (PlayerState.isHpSkillPoint)
            {
                saveHp = maxHp;
                maxHp = PlayerState.Hp;
                currentHp += maxHp - saveHp;
            } // 스킬포인트 찍었다고 가정했을때 대비용

            if (!isHit)
            {
                playerColor = Color.white;
                hitEffect += Time.deltaTime;
                if (hitEffect > hitEffectcoolTime)
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

            if (currentHp <= 0)
            {
                isDie = true;
            }

        }

    }
}
