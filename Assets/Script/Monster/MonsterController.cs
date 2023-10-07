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
