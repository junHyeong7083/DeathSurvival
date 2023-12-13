using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA_Basic : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    Animator animator;

    bool isRight = true;
//    float damage = 0f;
    float checkTime;
    bool canAtk = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        checkTime = 0f;
        canAtk = true;
        //  damage = WeaponDataManager.playerABasicAtkDamage;
        Debug.Log("WeaponDataManager.playerABasicAtkCool  : " + WeaponDataManager.playerABasicAtkCool);
        isRight = false;
    }


    // Update is called once per frame
    void Update()
    {
        //this.transform.position = PlayerController.PlayerPos
        if (Pixelate.showHpBar)
        {
            if(canAtk)
            {
                if (isRight)
                {
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x + 1.5f, PlayerController.PlayerPos.y, 0);
                   // Debug.Log("¿À");
                    canAtk = false;
                    isRight = false;
                    spriteRenderer.flipX = false;
                    animator.SetTrigger("isAtk");
                }
                else if(!isRight)
                {
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x - 1.5f, PlayerController.PlayerPos.y, 0);
                 //   Debug.Log("¿Þ");
                    canAtk = false;
                    isRight = true;
                    animator.SetTrigger("isAtk");
                    spriteRenderer.flipX = true;
                    //   this.gameObject.SetActive(false);
                }
            }
            else if(!canAtk)
            {
                checkTime += Time.deltaTime;
                if (checkTime > PlayerPrefs.GetFloat("ABasicSpeed"))
                {
                    checkTime = 0f; 
                    canAtk = true;
                }
            }

        }
    }
}
