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
    Rigidbody2D rigidbody2D;

    CircleCollider2D circleCollider2D;

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
        circleCollider2D = GetComponent<CircleCollider2D>();

        gameObject.GetComponent<CircleCollider2D>().enabled = true;

        rigidbody2D = GetComponent<Rigidbody2D>();

        isMove = true;

        delayDieTime = 0f;

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
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        isMove = true;
        delayDieTime = 0f;
        if (!isStart)
            maxHp = Hp;
        isStart = true;
        Hp = maxHp;
        isDead = false;
      //  animator.SetBool("MonsterDie", false);
    }
    float delayDieTime;
    bool isMove;
    void Update()
    {
        if (!PlayerHpBar.isDie) // 플레이어가 살아있을때 움직이기
        {
            if (!isDead && Hp <= 0) // 몬스터가 죽지 않았고 HP가 0 이하인 경우
            {
                bloodEffect.SpawnMonsterBlood(this.transform.position.x, this.transform.position.y);
                monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
                isMove = false;
                isDead = true; // 몬스터를 죽은 상태로 표시
            }
            if (isDead)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                delayDieTime += Time.deltaTime;
                animator.SetBool("MonsterDie", true);
                if (delayDieTime > 1.0f)
                    this.gameObject.SetActive(false);

            }


            if (isMove)
            {
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                transform.Translate(direction * Speed * Time.deltaTime);
            }
        }

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
