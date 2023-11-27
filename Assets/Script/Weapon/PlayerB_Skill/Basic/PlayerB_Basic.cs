using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerB_Basic : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    UnityEngine.Color color;

    public ParticleSystem GhostEffect;
    ParticleSystem.MainModule mainModule;

    bool isRight = true;
    bool isAxeThrowing = false;
    float axeThrowTime = 0f;
    bool canAtk = true;

    GameObject dirPos;

    // Start is called before the first frame update
    void Start()
    {
        GhostEffect.gameObject.SetActive(false);
        mainModule = GhostEffect.main;
        boxCollider = GetComponent<BoxCollider2D>();
        dirPos = GameObject.Find("Dir");
        PlayerPrefs.SetFloat("BBasicSpeed", 2);
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        canAtk = true;
        isRight = false;
    }

    bool isShowAxe = true;
    float delayTime = 0f;
    float coolTime = 3f;
    float playerY;
    // Update is called once per frame
    void Update()
    {
        if (Pixelate.showHpBar)
        {
            if (isShowAxe)
            {
                if (WeaponDataManager.playerBFourbool)
                    GhostEffect.gameObject.SetActive(true);
                spriteRenderer.enabled = true;
                boxCollider.enabled = true;
            }
            else
            {
                GhostEffect.gameObject.SetActive(false);
                spriteRenderer.enabled = false;
                boxCollider.enabled = false;
            }

            if (canAtk)
            {
                isShowAxe = true;
                if (dirPos.transform.position.x > PlayerController.PlayerPos.x)
                {
                    isRight = true;
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x +0.05f, PlayerController.PlayerPos.y - 0.05f, 0);
                    Debug.Log("오");
                    spriteRenderer.flipX = false;
                    isAxeThrowing = true;
                    canAtk = false;
                }
                else if (dirPos.transform.position.x < PlayerController.PlayerPos.x)
                {
                    isRight = false;
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x -0.05f, PlayerController.PlayerPos.y - 0.05f, 0);
                    Debug.Log("왼");
                    spriteRenderer.flipX = true;
                    isAxeThrowing = true;
                    canAtk = false;
                }
                playerY = this.transform.position.y;
            }
            else if (!canAtk)
            {
                delayTime += Time.deltaTime;
                if (delayTime >= coolTime)
                {
                    delayTime = 0f;
                    canAtk = true;
                }
            }
            if (isAxeThrowing)
            {
                float rotationSpeed = 360 * 4;
                float movementSpeed = 10;
                this.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);
                GhostEffect.transform.eulerAngles += new Vector3(0, 0, (isRight ? -1 : 1) * rotationSpeed * Time.deltaTime);
                // 이동
                float horizontalMovement = (isRight ? 1 : -1) * movementSpeed * Time.deltaTime;
                this.transform.position += new Vector3(horizontalMovement, 0, 0);
                this.transform.position = new Vector3(this.transform.position.x, playerY, this.transform.position.z);

                // 날아가는 시간 체크
                axeThrowTime += Time.deltaTime;

                if (axeThrowTime >= 0.6f)
                {
                    isAxeThrowing = false;
                    axeThrowTime = 0f;
                    // = true
                    isShowAxe = false;
                }
            }
        }
    }
}
