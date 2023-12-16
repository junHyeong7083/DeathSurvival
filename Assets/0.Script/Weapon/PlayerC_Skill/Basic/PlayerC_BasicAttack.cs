using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerC_BasicAttack : PlayerController
{
    GameObject Dir;

    float attackTime = 3f;
    float coolTime = 3f;
    Animator animator;
    BoxCollider2D boxCollider2D;
    

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();  
        Dir = GameObject.Find("Dir");
        animator = GetComponent<Animator>();

        StartCoroutine(Atk());
    }


    bool isOnes = false;
    IEnumerator Atk()
    {
        while(true)
        {
            if(!isOnes)
            {
                isOnes = true;
                float startTime = Time.time;
                animator.SetBool("isCool", false);
                WeaponDataManager.playerCBasicBool = true;
                boxCollider2D.enabled = true;
                while (Time.time - startTime < WeaponDataManager.playerCBasicAtkTime)
                {
                    if (Dir.transform.position.x >= PlayerPos.x)
                    {
                       // Debug.Log("¿À");
                        this.transform.localEulerAngles = new Vector3(180, 0, 270);
                        this.transform.position = new Vector3(PlayerController.PlayerPos.x + 1.0f, PlayerController.PlayerPos.y, 0);
                    }
                    else
                    {
                        //Debug.Log("¿Þ");
                        this.transform.localEulerAngles = new Vector3(0, 0, 90);
                        this.transform.position = new Vector3(PlayerController.PlayerPos.x - 1.0f, PlayerController.PlayerPos.y, 0);
                    }

                    yield return null;
                }
                startTime = Time.time;
                animator.SetBool("isCool", true);
                WeaponDataManager.playerCBasicBool = false;
                boxCollider2D.enabled = false;
                while (Time.time - startTime < WeaponDataManager.playerCBasicCoolTime)
                {
                    yield return null;
                }
                isOnes = false;
            }
           
        }
    }








    
    void Update()
    {
        
    }
}
