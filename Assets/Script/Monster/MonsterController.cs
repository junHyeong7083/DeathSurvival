using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region State
    [SerializeField]
    float Speed; 
    [SerializeField]
    float Hp; 
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
            Destroy(this.gameObject);
    }


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriternRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
