using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB_Atk1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    public ParticleSystem GhostEffect;
    ParticleSystem.MainModule mainModule;

    bool isRight = true;
    bool isAxeThrowingA = false;
    float axeThrowTime = 0f;
    bool canAtk = true;

    GameObject dirPos;

    float playerY;
    bool isShowAxe = true;
    float delayTime = 0f;
    float coolTime = 3f;
    float rotateTime = 0f;
    bool isAxeThrowingB = false;
    bool isAxeThrowingC = false;

    // Start is called before the first frame update
    void Start()
    {
        GhostEffect.gameObject.SetActive(false);
        mainModule = GhostEffect.main;
        boxCollider = GetComponent<BoxCollider2D>();
        dirPos = GameObject.Find("Dir");
        PlayerPrefs.SetFloat("BBasicSpeed", 2);
        spriteRenderer = GetComponent<SpriteRenderer>();
        canAtk = true;
        isRight = false;
    }

    bool check = false;
    // Update is called once per frame
    void Update()
    {
        #region 버그가 왜생기는지모르겠는데 해결안돼서 임시로 막아둠;
        if (!check)
        {
            if (WeaponDataManager.playerBFourbool)
                GhostEffect.gameObject.SetActive(false);
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
        else if(check)
        {
            if (WeaponDataManager.playerBFourbool)
                GhostEffect.gameObject.SetActive(true);
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
        #endregion
        if (!WeaponDataManager.playerBFourbool)
            GhostEffect.gameObject.SetActive(false);
        if (Pixelate.showHpBar)
        {
            Debug.Log("!!");
            if (canAtk)
            {
                isRight = dirPos.transform.position.x > PlayerController.PlayerPos.x;

                if (isRight)
                {
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x + 0.05f, PlayerController.PlayerPos.y - 0.05f, 0);
                    spriteRenderer.flipX = false;
                    isAxeThrowingA = true;
                }
                else // 왼
                {
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x - 0.05f, PlayerController.PlayerPos.y - 0.05f, 0);
                    spriteRenderer.flipX = true;
                    isAxeThrowingA = true;
                }
                playerY = this.transform.position.y;

                if (isAxeThrowingA)
                {
                    Debug.Log("isAxeThrowingA");
                    AxeThrowingAUpdate();
                }
                else if (isAxeThrowingB)
                {
                    AxeThrowingBUpdate();
                }
                else if (isAxeThrowingC )
                {
                    AxeThrowingCUpdate();
                }
            }
            else if(!canAtk)
            {
                delayTime += Time.deltaTime;
                if (delayTime >= coolTime)
                {
                    delayTime = 0f;
                    canAtk = true;
                }
            }
        }
    }

    void AxeThrowingAUpdate()
    {
        float rotationSpeed = 360 * 4;
        float movementSpeed = 10;

        this.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);
        GhostEffect.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);

        float horizontalMovement = (isRight ? 1 : -1) * movementSpeed * Time.deltaTime;
        this.transform.position += new Vector3(horizontalMovement, 0, 0);
        this.transform.position = new Vector3(this.transform.position.x, playerY, this.transform.position.z);

        axeThrowTime += Time.deltaTime;

        if (axeThrowTime >= 0.5f)
        {
            isAxeThrowingA = false;
            axeThrowTime = 0f;
            isAxeThrowingB = true;
        }
    }

    void AxeThrowingBUpdate()
    {
       // Debug.Log("aaaaaaaaaaaaaa");
        float rotationSpeed = 360 * 4;

        this.transform.eulerAngles += new Vector3(0, 0, (isRight ? 1 : -1) * rotationSpeed * Time.deltaTime);
        GhostEffect.transform.eulerAngles += new Vector3(0, 0, (isRight ? 1 : -1) * rotationSpeed * Time.deltaTime);
        this.transform.localScale = new Vector3(7, 7, 7);
        rotateTime += Time.deltaTime;
        if (rotateTime >= 2f)
        {
            rotateTime = 0f;
            isAxeThrowingB = false;
            isAxeThrowingC = true;

        }
    }

    void AxeThrowingCUpdate()
    {
        this.transform.localScale = new Vector3(5, 5, 5);
        float rotationSpeed = 360 * 4;
        this.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);
        GhostEffect.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);

        float lerpSpeed = 3f;
        this.transform.position = Vector3.Lerp(this.transform.position, PlayerController.PlayerPos, lerpSpeed * Time.deltaTime);


        // 목표 지점에 도달하면 이동을 멈추도록 추가
        float distanceToTarget = Vector3.Distance(this.transform.position, PlayerController.PlayerPos);
        Debug.Log("distance : " + distanceToTarget);
        if (distanceToTarget <= 0.3f)
        {
            canAtk = false;
            isAxeThrowingC = false;
            check = true;
            // 추가적인 로직이나 변수 초기화를 필요에 따라 수행
        }
    }

}
