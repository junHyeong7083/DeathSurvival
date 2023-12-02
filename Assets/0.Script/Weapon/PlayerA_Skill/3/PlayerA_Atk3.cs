using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA_Atk3 : MonoBehaviour
{
    Animator animator;
    BoxCollider2D collider2D;

    public static bool playerA_Atk3 = false;
    public float radios;
    public float PosyValue;
    private bool isCoolingDown = false;
    int randomValueX;
    int randomValueY;
    Vector3 thisScale;
    private void Start()
    {
        playerA_Atk3 = true;
        thisScale = transform.localScale;
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        collider2D.enabled = false;
    }

    private void Update()
    {

        randomValueX = Random.Range(-5, 5);
        randomValueY = Random.Range(-10, 1);
        //this.transform.position = PlayerController.PlayerPos;
        DetectAndAttackEnemy();
    }

    void DetectAndAttackEnemy()
    {
        Collider2D[] enemiesInRadius = Physics2D.OverlapCircleAll(PlayerController.PlayerPos, radios);

        float closestDistance = float.MaxValue;
        Transform closestEnemy = null;

        foreach (var enemy in enemiesInRadius)
        {
            if (enemy.CompareTag("Monster"))
            {
                float distanceToPlayer = Vector3.Distance(PlayerController.PlayerPos, enemy.transform.position);
                if (distanceToPlayer < closestDistance)
                {
                    closestDistance = distanceToPlayer;
                    closestEnemy = enemy.transform;
                }
            }
        }

        if (closestEnemy != null && !isCoolingDown)
        {
            collider2D.enabled = true;
            this.transform.localScale = new Vector3(thisScale.x + randomValueY*1.5f, thisScale.y, thisScale.z);
            this.transform.position = new Vector3(closestEnemy.transform.position.x + randomValueX, PlayerController.PlayerPos.y + 6f, 0) ;
            animator.SetTrigger("isAttack");
            StartCoroutine(isDelayCollider());
            StartCoroutine(CoolDownAttack());
        }
    }
    IEnumerator isDelayCollider()
    {
        yield return new WaitForSeconds(0.1f);
        collider2D.enabled = false;
    }

    IEnumerator CoolDownAttack()
    {
        isCoolingDown = true;
        //Debug.Log("!!");
        yield return new WaitForSeconds(WeaponDataManager.playerAThreeCoolTime);
        isCoolingDown = false;
    }
}
