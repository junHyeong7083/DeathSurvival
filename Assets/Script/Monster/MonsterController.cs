using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Thirdweb.AccountAbstraction;

public class MonsterController : MonoBehaviour
{
    #region State
    [SerializeField]
    float Speed;
    float saveSpeed;

    public float Hp;
    float maxHp;
    [SerializeField]
    float Damage;
    #endregion
    public int monsterIndex;

    Rigidbody2D rigidbody2D;

    CircleCollider2D circleCollider2D;

    Transform playerTransform;

    Animator animator;

    SpriteRenderer spriternRenderer;

    UnityEngine.Color color;

    GameObject monsterItem;

    public GameObject DamageText;
    public Transform DamagePos;
    int damage = 0;
    int checkDamage = 0;
    float sumDamage = 0;

    bool isRight = false;
    bool isDead = false;

    #region Hit
    bool isHit = false;
    bool showHitEffect = false;
    public float hitcoolTime;
    float hitTime = 0f;
    #endregion

    #region SaveDamage
    public static float PlayerAOneDamage = 0;
    public static float PlayerATwoDamage = 0;
    public static float PlayerAThreeDamage = 0;
    public static float PlayerABasicDamage = 0;

    #endregion

    DamageTextPool pool;
    GameObject monsterManagerObj;
    MonsterManager monsterManager;
    GameObject bloodEffectObj;
    BloodEffect bloodEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            damage = Random.Range(-1, 6);
            checkDamage = damage;
            if (checkDamage >= 1 && checkDamage < 5)
                checkDamage = 1;
            if (collision.gameObject.tag == "PlayerA_One")
            {
                // 공격력 따라 데미지 줄이는 코드
                Hp -= WeaponDataManager.playerAOneAtk + damage;
                sumDamage = WeaponDataManager.playerAOneAtk + damage;
                isHitAni = false;
                isHit = true;

                switch (CharacterManager.Instance.currentCharacter)
                {
                    case Character.White: // 전구
                        PlayerAOneDamage += WeaponDataManager.playerAOneAtk;
                        //  TakeDamage(sumDamage, checkDamage);
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;

                    case Character.Blue:
                        break;

                    case Character.Green:
                        break;
                }
            }
            

            if (collision.gameObject.tag == "PlayerA_Two")
            {
                // 공격력 따라 데미지 줄이는 코드
                Hp -= WeaponDataManager.playerATwoAtk + damage;
                sumDamage = WeaponDataManager.playerATwoAtk + damage;
                isHit = true;
                isHitAni = false;

                switch (CharacterManager.Instance.currentCharacter)
                {
                    case Character.White: // 전구
                        PlayerATwoDamage += WeaponDataManager.playerATwoAtk + damage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;

                    case Character.Blue:
                        break;

                    case Character.Green:
                        break;
                }
            }

            if (collision.gameObject.tag == "PlayerA_Three")
            {
                // 공격력 따라 데미지 줄이는 코드
                Hp -= WeaponDataManager.playerAThreeAtk;
                sumDamage = WeaponDataManager.playerAThreeAtk + damage;
                isHit = true;
                isHitAni = false;

                switch (CharacterManager.Instance.currentCharacter)
                {
                    case Character.White: // 전구
                        PlayerAThreeDamage += WeaponDataManager.playerAThreeAtk;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;

                    case Character.Blue:
                        break;

                    case Character.Green:
                        break;
                }
            }

            if (collision.gameObject.tag == "PlayerA_Basic")
            {
                // 공격력 따라 데미지 줄이는 코드
                Hp -= WeaponDataManager.playerABasicAtkDamage;
                sumDamage = WeaponDataManager.playerABasicAtkDamage + damage;
                isHit = true;
                isHitAni = false;

                switch (CharacterManager.Instance.currentCharacter)
                {
                    case Character.White: // 전구
                        PlayerABasicDamage += WeaponDataManager.playerABasicAtkDamage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;

                    case Character.Blue:
                        break;

                    case Character.Green:
                        break;
                }
            }





            #region 플레이어한테 너무 안붙게
            if (collision.gameObject.tag == "Player")
            {
                Speed = 0;
            }
            else if(collision.gameObject.tag != "Player")
            {
                Speed = saveSpeed;
            }
            #endregion
        }

    }


    void Start()
    {
        switch(monsterIndex)
        {
            case 0:
                saveSpeed = MincheolWork._Monster1Speed;
                maxHp = MincheolWork._Monster1HP;
                break;

            case 1:
                saveSpeed = MincheolWork._Monster2Speed;
                maxHp = MincheolWork._Monster2HP;
                break;

            case 2:
                saveSpeed = MincheolWork._Monster3Speed;
                maxHp = MincheolWork._Monster3HP;
                break;

        }
        Speed = saveSpeed;
        pool = GameObject.Find("DamageManager").GetComponent<DamageTextPool>();

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
        ones = false;
        showHitEffect = false;
        hitTime = 0f;
        knockbackTime = 0f;
        isHit = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        isMove = true;
        delayDieTime = 0f;
        if (!isStart)
        {
            switch (monsterIndex)
            {
                case 0:
                    maxHp = MincheolWork._Monster1HP;
                    break;

                case 1:
                    maxHp = MincheolWork._Monster2HP;
                    break;

                case 2:
                    maxHp = MincheolWork._Monster3HP;
                    break;
            }
        }
        // 기존의 maxHp = Hp; 라인을 삭제
        // maxHp = Hp;
        isStart = true;
        Hp = maxHp; // 이 부분이 수정되었습니다.
        isDead = false;
    }

    float delayDieTime;
    bool isMove;
    bool isHitAni = false;

    void OnSkillEnd()
    {
        Transform child = transform.GetChild(0);
        if (child != null)
        {
            child.gameObject.SetActive(false);
        }
    }

    void Update()
    {
     //  DamageText.transform.position = DamagePos.position;
        if (WeaponDataManager.playerAFourbool)
        {
            animator.SetBool("MonsterTimeStop", true);
        }
        // animator.SetBool("MonsterTimeStop", true);
        else
            animator.SetBool("MonsterTimeStop", false);

        if (!PlayerHpBar.isDie) // 플레이어가 살아있을때 움직이기
        {
            if (!isDead && Hp <= 0) // 몬스터가 죽지 않았고 HP가 0 이하인 경우
            {
                int dieSound = Random.Range(1, 7);
                switch(dieSound)
                {
                    case 1:
                        Debug.Log("sound1");

                        SoundManager.Instance.PlaySFXSound("monsterDie1");
                        break;

                    case 2:
                        Debug.Log("sound2");
                        SoundManager.Instance.PlaySFXSound("monsterDie2");
                        break;

                    case 3:
                        Debug.Log("sound3");
                        SoundManager.Instance.PlaySFXSound("monsterDie3");
                        break;

                    case 4:
                        Debug.Log("sound4");
                        SoundManager.Instance.PlaySFXSound("monsterDie4");
                        break;

                    case 5:
                        Debug.Log("sound5");
                        SoundManager.Instance.PlaySFXSound("monsterDie5");
                        break;

                    case 6:
                        Debug.Log("sound6");
                        SoundManager.Instance.PlaySFXSound("monsterDie6");
                        break;

                }
                monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
                isMove = false;
                isDead = true; // 몬스터를 죽은 상태로 표시
            }
            if (isDead)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                delayDieTime += Time.deltaTime;
                knockPos = this.transform.position;
                animator.SetBool("MonsterDie", true);
                if (delayDieTime > 1.0f)
                    this.gameObject.SetActive(false);

            }

            if (!WeaponDataManager.playerAFourbool)
            {
                if (isMove)
                {
                    Vector2 direction = (playerTransform.position - transform.position).normalized;
                    transform.Translate(direction * Speed * Time.deltaTime);
                }
            }
        }
        if (!WeaponDataManager.playerAFourbool)
        {
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

        if (isHit)
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
            if(!isDead)
            {
                if(!WeaponDataManager.playerAFourbool) // 전구 시간정지때는 넉백작동하면 딜로스남
                {
                    if (knockbackTime < 0.1f)
                    {
                        if(!isHitAni)
                        {
                            isHitAni = true;
                            animator.SetTrigger("MonsterHit");
                        }

                        Vector2 direction = (playerTransform.position - transform.position).normalized / 5;
                        Vector3 knockbackVector = direction * -1f * 50f * Time.deltaTime;
                        this.transform.Translate(knockbackVector);
                    }
                }
            
            }
            if (isDead)
            {
                if (!ones)
                {
                    bloodEffect.SpawnMonsterBlood(knockPos.x, knockPos.y);
                    ones = true;
                }
            }
        } // 넉백효과



    }
    bool ones = false;
    float knockbackTime = 0f;
    Vector3 knockPos;
}
