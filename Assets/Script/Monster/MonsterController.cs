using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonsterController : MonoBehaviour
{
    #region State
    [SerializeField]
    float Speed;

    public float Hp; 
    [SerializeField]
    float Damage;
    #endregion
    Transform playerTransform;

    SpriteRenderer spriternRenderer;

    [SerializeField]
    bool isRight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TestSkill")
        {
            // 공격력 따라 데미지 줄이는 코드
            Hp -= 100f;
        }
    }


    void Start()
    {
        Hp = maxHp;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriternRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Hp < 0)
        {
            this.gameObject.SetActive(false);
        }


        Vector2 direction = (playerTransform.position - transform.position).normalized;
        this.GetComponent<Rigidbody2D>().velocity = direction * Speed;

        if (this.transform.position.x <= playerTransform.position.x)
        {
            isRight = true;
            spriternRenderer.flipX = true;
        }
        else
        {
            isRight = false;
            spriternRenderer.flipX = false;
        }
            
    }
}
