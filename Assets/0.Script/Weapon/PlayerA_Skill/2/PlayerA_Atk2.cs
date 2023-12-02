using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerA_Atk2 : MonoBehaviour
{
    Animator animator;
    BoxCollider2D collider2D;
    public static bool playerA_Atk2 = false;
    public float radios;
    public float coolTime;

    private bool isCoolingDown = false;

    private void Start()
    {
        playerA_Atk2 = true;
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        collider2D.enabled = false;
    }

    private void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
        this.transform.localScale = new Vector3(radios, radios, 0);
        DetectAndAttackEnemy();
    }

    void DetectAndAttackEnemy()
    {
        Collider2D[] enemiesInRadius = Physics2D.OverlapCircleAll(transform.position, radios);

        foreach (var enemy in enemiesInRadius)
        {
            if (enemy.CompareTag("Monster") && !isCoolingDown)
            {
                collider2D.enabled = true;
                Vector2 directionToEnemy = enemy.transform.position - transform.position;
                float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                animator.SetTrigger("isAttack");
                StartCoroutine(isDelayCollider());
                StartCoroutine(CoolDownAttack());
                break; // 첫 번째로 탐지된 적만 공격
            }
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
        yield return new WaitForSeconds(WeaponDataManager.playerATwoCoolTime);
        isCoolingDown = false;
    }
}
