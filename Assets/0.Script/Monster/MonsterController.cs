using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using System.Drawing;

public class MonsterController : MonoBehaviour
{
    #region State
    float Speed;
    [SerializeField]
    float saveSpeed;

     float Hp;
    [SerializeField]
    float maxHp;
    [SerializeField]
    float Damage;
    #endregion
    public int monsterIndex;
    public bool isDetect = false;
    Rigidbody2D rigidbody2D;
    Rigidbody2D targetRigid;
    GameObject targetPlayer;
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

    public static float PlayerBOneDamage = 0;
    public static float PlayerBTwoDamage = 0;
    public static float PlayerBThreeDamage = 0;
    public static float PlayerBBasicDamage = 0;

    public static float PlayerCOneDamage = 0;
    public static float PlayerCTwoDamage = 0;
    public static float PlayerCThreeDamage = 0;
    public static float PlayerCBasicDamage = 0;
    #endregion

    bool isHitPlayerBFourSkill = false;

    DamageTextPool pool;
    GameObject monsterManagerObj;
    MonsterManager monsterManager;
    GameObject bloodEffectObj;
    BloodEffect bloodEffect;

    bool isMagnetic = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            damage = Random.Range(-1, 6);
            checkDamage = damage;
            if (checkDamage >= 1 && checkDamage < 5)
                checkDamage = 1;
            switch (CharacterManager.Instance.currentCharacter)
            {
                
                case Character.White:
                    if (collision.gameObject.tag == "PlayerA_One")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerAOneAtk + damage;
                        sumDamage = WeaponDataManager.playerAOneAtk + damage;
                        isHitAni = false;
                        isHit = true;


                        PlayerAOneDamage += WeaponDataManager.playerAOneAtk;
                        //  TakeDamage(sumDamage, checkDamage);
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerA_Two")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerATwoAtk + damage;
                        sumDamage = WeaponDataManager.playerATwoAtk + damage;
                        isHit = true;
                        isHitAni = false;


                        PlayerATwoDamage += WeaponDataManager.playerATwoAtk + damage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerA_Three")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerAThreeAtk;
                        sumDamage = WeaponDataManager.playerAThreeAtk + damage;
                        isHit = true;
                        isHitAni = false;

                        PlayerAThreeDamage += WeaponDataManager.playerAThreeAtk;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerA_Basic")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerABasicAtkDamage;
                        sumDamage = WeaponDataManager.playerABasicAtkDamage + damage;
                        isHit = true;
                        isHitAni = false;

                         PlayerABasicDamage += WeaponDataManager.playerABasicAtkDamage;
                         pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;
                    }
                    break;

                case Character.Blue:
                    if (collision.gameObject.tag == "PlayerB_One")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerBOneAtk + damage;
                        sumDamage = WeaponDataManager.playerBOneAtk + damage;
                        isHitAni = false;
                        isHit = true;


                        PlayerBOneDamage += WeaponDataManager.playerBOneAtk;
                        //  TakeDamage(sumDamage, checkDamage);
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerB_Two")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                       // Hp -= WeaponDataManager.playerBTwoAtk + damage;
                      //  sumDamage = WeaponDataManager.playerATwoAtk + damage;
                        isHit = true;
                        isHitAni = false;


                      //  PlayerATwoDamage += WeaponDataManager.playerATwoAtk + damage;
                       // pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerB_Three")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerBThreeDamage;
                        sumDamage = WeaponDataManager.playerBThreeDamage + damage;
                        isHit = true;
                        isHitAni = false;

                        PlayerBThreeDamage += WeaponDataManager.playerBThreeDamage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerB_Basic")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerBBasicDamage;
                        sumDamage = WeaponDataManager.playerBBasicDamage + damage;
                        isHit = true;
                        isHitAni = false;

                        PlayerBBasicDamage += WeaponDataManager.playerBBasicDamage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;
                    }
                    break;

                case Character.Green:
                    if (collision.gameObject.tag == "PlayerC_One")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.plyaerCOneDamage + damage;
                        sumDamage = WeaponDataManager.plyaerCOneDamage + damage;
                        isHitAni = false;
                        isHit = true;


                        PlayerCOneDamage += WeaponDataManager.plyaerCOneDamage;
                        //  TakeDamage(sumDamage, checkDamage);
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerC_Two")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerCTwoDamage + damage;
                        sumDamage = WeaponDataManager.playerCTwoDamage + damage;
                        isHit = true;
                        isHitAni = false;


                        PlayerCTwoDamage += WeaponDataManager.playerCTwoDamage + damage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                    }
                    if (collision.gameObject.tag == "PlayerC_Three")
                    {
                     /*   // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerAThreeAtk;
                        sumDamage = WeaponDataManager.playerAThreeAtk + damage;
                        isHit = true;
                        isHitAni = false;

                        PlayerCThreeDamage += WeaponDataManager.playerAThreeAtk;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);*/
                    }
                    if (collision.gameObject.tag == "PlayerC_Basic")
                    {
                        // 공격력 따라 데미지 줄이는 코드
                        Hp -= WeaponDataManager.playerCBasicAtkDamage;
                        sumDamage = WeaponDataManager.playerCBasicAtkDamage + damage;
                        isHit = true;
                        isHitAni = false;

                        PlayerCBasicDamage += WeaponDataManager.playerCBasicAtkDamage;
                        pool.ShowDamageText(DamagePos.position, sumDamage, checkDamage);
                        break;
                    }
                    break;
            }

            if (WeaponDataManager.playerBFourbool)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    newColor.a = 0.5f;
                    spriternRenderer.color = newColor;
                    isHitPlayerBFourSkill = true;
                }
            }
            if(collision.gameObject.tag == "PlayerB_Magnetic")
            {
                isMagnetic = true;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerB_Magnetic")
        {
            isMagnetic = false;
        }
    }
    private void Awake()
    {

    }
    UnityEngine.Color newColor;
    void Start()
    {
        targetPlayer = GameObject.FindWithTag("Player");
        targetRigid = targetPlayer.GetComponent<Rigidbody2D>();
        isHitPlayerBFourSkill = false;
        Speed = saveSpeed;
        Hp = maxHp;
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
        newColor = spriternRenderer.color;
        /* newColor.r = 1 - color.r;
         newColor.g = 1 - color.g;
         newColor.b = 1 - color.b;*/
    }

    bool isStart = false;
    private void OnEnable()
    {
        isHitPlayerBFourSkill = false;
        Speed = saveSpeed;
        ones = false;
        showHitEffect = false;
        hitTime = 0f;
        knockbackTime = 0f;
        isHit = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        isMove = true;
        delayDieTime = 0f;
        isStart = true;
        Hp = maxHp; 
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
    float checkSpeed;
    bool isSlowed = false;   
    void OnSlow()
    {
        if (!isSlowed )
        {
            checkSpeed = Speed;
            Debug.Log("checkSpeed : " + checkSpeed);
            Speed = 0.4f;

            isSlowed = true;
        }
    }
    void OutSlow()
    {
        isSlowed = false;
        Speed = checkSpeed;
        Debug.Log("speedOut : " + Speed);
    }
    bool isOnes = false;

    void Update()
    {
      //  Debug.Log("hp : " + Hp);
        // Debug.Log("monsSpeed : " + Speed);
        //  DamageText.transform.position = DamagePos.position;
        if (WeaponDataManager.playerAFourbool)
        {
            animator.SetBool("MonsterTimeStop", true);
        }
        else
            animator.SetBool("MonsterTimeStop", false);

        if (WeaponDataManager.playerBFourbool)
        {
            if(!isOnes)
            {
                Speed /= 2f;
                isOnes = true;
            }
            circleCollider2D.isTrigger = true;
            Transform monsterTransform = this.transform;
            Transform child = monsterTransform.GetChild(1);
            child.gameObject.SetActive(false);
        }
        else if(!WeaponDataManager.playerBFourbool)
        {
            isOnes = false;
            newColor.a = 1f;
            spriternRenderer.color = newColor;
            //    spriternRenderer.color = color;
            Speed = saveSpeed;
            circleCollider2D.isTrigger = false;
            if (isHitPlayerBFourSkill)
            {
                Transform monsterTransform = this.transform;
                Transform child = monsterTransform.GetChild(1);
                child.gameObject.SetActive(true);
                isHitPlayerBFourSkill = false;
            }

        }


        if (!PlayerHpBar.isDie) // 플레이어가 살아있을때 움직이기
        {
            if (!isDead && Hp <= 0) // 몬스터가 죽지 않았고 HP가 0 이하인 경우
            {
                int dieSound = Random.Range(1, 7);
                switch(dieSound)
                {
                    case 1:
                      //  Debug.Log("sound1");

                        SoundManager.Instance.PlaySFXSound("monsterDie1");
                        break;

                    case 2:
                       // Debug.Log("sound2");
                        SoundManager.Instance.PlaySFXSound("monsterDie2");
                        break;

                    case 3:
                      //  Debug.Log("sound3");
                        SoundManager.Instance.PlaySFXSound("monsterDie3");
                        break;

                    case 4:
                      //  Debug.Log("sound4");
                        SoundManager.Instance.PlaySFXSound("monsterDie4");
                        break;

                    case 5:
                       // Debug.Log("sound5");
                        SoundManager.Instance.PlaySFXSound("monsterDie5");
                        break;

                    case 6:
                       // Debug.Log("sound6");
                        SoundManager.Instance.PlaySFXSound("monsterDie6");
                        break;

                }
                monsterManager.SpawnMonsterItem(this.transform.position.x, this.transform.position.y);
                isMove = false;
                isDead = true; // 몬스터를 죽은 상태로 표시
                MonsterManager.huntMonsterCnt++;
            }
            if (isDead)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                knockPos = this.transform.position;
                animator.SetBool("MonsterDie", true);
                delayDieTime += Time.deltaTime;
                if (delayDieTime > 1.0f)
                    this.gameObject.SetActive(false);

            }

            if (!WeaponDataManager.playerAFourbool)
            {
                if (isMove)
                {
                    /*   Vector2 direction = (playerTransform.position - transform.position).normalized;
                       transform.Translate(direction * Speed * Time.deltaTime);*/
                    Vector2 dirV = targetRigid.position - rigidbody2D.position;
                    Vector2 nextV = dirV.normalized * Speed * Time.deltaTime;
                    rigidbody2D.MovePosition(rigidbody2D.position + nextV);
                    rigidbody2D.velocity = Vector2.zero;

                    if(WeaponDataManager.playerBTwobool)
                    {
                        if (isMagnetic)
                        {
                            GameObject magnetic = GameObject.Find("magneticField");
                            transform.position = Vector3.MoveTowards(transform.position, magnetic.transform.position, 1f * Time.deltaTime);
                        }
                    }  
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
