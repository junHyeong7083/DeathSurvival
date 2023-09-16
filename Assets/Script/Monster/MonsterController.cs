using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    GameObject monsterItem;
    [SerializeField]
    bool isRight = false;


    GameObject monsterManagerObj;
    MonsterManager monsterManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TestSkill")
        {
            // ���ݷ� ���� ������ ���̴� �ڵ�
            Hp -= 100f;
        }
    }


    void Start()
    {
        monsterManagerObj = GameObject.Find("MonsterManager");

        monsterManager = monsterManagerObj.GetComponent<MonsterManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        spriternRenderer = GetComponent<SpriteRenderer>();
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

    bool isDead = false;
    void Update()
    {
        if (!isDead && Hp <= 0) // ���Ͱ� ���� �ʾҰ� HP�� 0 ������ ���
        {
            monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
            this.gameObject.SetActive(false);
            isDead = true; // ���͸� ���� ���·� ǥ��
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
