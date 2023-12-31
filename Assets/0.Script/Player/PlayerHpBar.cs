using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    Image hpBg;
    Image hpBar;
    Camera camera;
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

    
    private void Awake()
    {
        isDie = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!WeaponDataManager.playerBFourbool)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                if (!isDie)
                {
                    if (isHit)
                    {
                        //Debug.Log("Hit!!");
                        currentHp -= 10f* (1 - PlayerState.Defense);
                        isHit = false;

                        //  playerColor = Color.blue;
                        //  spriteRenderer.color = playerColor;
                    }
                }
            }
        }
    }

    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                if (!isDie)
                {
                    if (isHit)
                    {
                        //Debug.Log("Hit!!");
                        currentHp -= 0.5f;
                        isHit = false;

                        //  playerColor = Color.blue;
                        //  spriteRenderer.color = playerColor;
                    }
                }
            }
        }*/
    void Start()
    {
        camera = Camera.main;
        hpBg = GameObject.Find("HpBG").GetComponent<Image>();
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

        if(!isDie)
        {
            //Debug.Log("State.hp : " + PlayerState.Hp);
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

        #region HpBar Transform
        if(Pixelate.showHpBar)
        {
                switch (CharacterManager.Instance.currentCharacter)
            {
                case Character.White:
                    hpBg.transform.position = camera.WorldToScreenPoint(this.transform.position + new Vector3(0, -0.7f, 0));
                    break;

                case Character.Blue:
                    hpBg.transform.position = camera.WorldToScreenPoint(this.transform.position + new Vector3(0, -0.7f, 0));
                    break;

                    case Character.Green:
                    hpBg.transform.position = camera.WorldToScreenPoint(this.transform.position + new Vector3(0, -0.9f, 0));
                    break;

            }
        }
        else
            hpBg.transform.position = camera.WorldToScreenPoint(this.transform.position + new Vector3(0, -30f, 0));
        #endregion
    }
}
