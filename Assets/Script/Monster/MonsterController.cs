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

    bool isRight = false;
    bool isDead = false;
    bool isHit = false;
    bool showHitEffect = false;
    public float hitcoolTime;
    float hitTime = 0f;
    GameObject monsterManagerObj;
    MonsterManager monsterManager;
    GameObject bloodEffectObj;
    BloodEffect bloodEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            if (collision.gameObject.tag == "PlayerA_One")
            {
                // ���ݷ� ���� ������ ���̴� �ڵ�
               Hp -= WeaponDataManager.playerAOneAtk;
                isHit = true;
            }

            if (collision.gameObject.tag == "PlayerA_Two")
            {
                // ���ݷ� ���� ������ ���̴� �ڵ�
                Hp -= WeaponDataManager.playerATwoAtk;
                isHit = true;
            }

            if (collision.gameObject.tag == "PlayerA_Three")
            {
                // ���ݷ� ���� ������ ���̴� �ڵ�
                Hp -= WeaponDataManager.playerAThreeAtk;
                isHit = true;
            }
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
    }
    float delayDieTime;
    bool isMove;
    void Update()
    {
        if (!PlayerHpBar.isDie) // �÷��̾ ��������� �����̱�
        {
            if (!isDead && Hp <= 0) // ���Ͱ� ���� �ʾҰ� HP�� 0 ������ ���
            {
                bloodEffect.SpawnMonsterBlood(this.transform.position.x, this.transform.position.y);
                monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
                isMove = false;
                isDead = true; // ���͸� ���� ���·� ǥ��
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

        if(isHit)
        {
            showHitEffect = true;
            knockbackTime += Time.deltaTime;
            hitTime += Time.deltaTime;
            if(hitTime >= hitcoolTime)
            {
                knockbackTime = 0f;
                hitTime = 0f;
                isHit = false;
                showHitEffect = false;
            }
        }
        if(showHitEffect)
        {
            if(knockbackTime < 0.1f)
            {
                Debug.Log("!");
                Vector2 direction = (playerTransform.position - transform.position).normalized / 5;
                Vector3 knockbackVector = direction * -1f * 50f * Time.deltaTime;
                transform.Translate(knockbackVector);

            }
        } // �˹�ȿ��



    }
    float knockbackTime = 0f;
}
