using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Animator animator;

    SpriteRenderer spriternRenderer;

    UnityEngine.Color color;

    GameObject monsterItem;

    [SerializeField]
    bool isRight = false;

    bool isDead = false;

    GameObject monsterManagerObj;
    MonsterManager monsterManager;
    GameObject bloodEffectObj;
    BloodEffect bloodEffect;
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
        animator = GetComponent<Animator>();

        bloodEffectObj = GameObject.Find("BloodManager");

        bloodEffect = bloodEffectObj.GetComponent<BloodEffect>();

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
            bloodEffect.SpawnMonsterBlood(this.transform.position.x, this.transform.position.y);
            monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
            this.gameObject.SetActive(false);
            isDead = true; // 몬스터를 죽은 상태로 표시
        }
        if(isDead)
        {
         //   animator.SetTrigger("isDie");
         // 애니메이션 클립에서 setactive(false) 설정하기

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
