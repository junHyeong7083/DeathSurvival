using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MonsterController : MonoBehaviour
{
    #region State
    [SerializeField]
    float Speed;

    public float Hp;
    float maxHp;
    [SerializeField]
    float Damage;
    #endregion

    Transform playerTransform;

    SpriteRenderer spriternRenderer;

    UnityEngine.Color color;

    GameObject monsterItem;

    [SerializeField]
    bool isRight = false;

    bool isDead = false;

    GameObject monsterManagerObj;
    MonsterManager monsterManager;
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
        monsterManagerObj = GameObject.Find("MonsterManager");

        monsterManager = monsterManagerObj.GetComponent<MonsterManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        spriternRenderer = GetComponent<SpriteRenderer>();

        color = spriternRenderer.color;
    }

    bool isStart = false;
    private void OnEnable()
    {
        if(!isStart)
            maxHp = Hp;
        isStart = true;
        Hp = maxHp;
        isDead = false;
    }


    void Update()
    {
        if (!isDead && Hp <= 0) // 몬스터가 죽지 않았고 HP가 0 이하인 경우
        {
            monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
            this.gameObject.SetActive(false);
            isDead = true; // 몬스터를 죽은 상태로 표시
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
