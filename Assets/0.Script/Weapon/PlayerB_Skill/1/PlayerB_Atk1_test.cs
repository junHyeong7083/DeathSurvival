using System.Collections;
using UnityEngine;

public class PlayerB_Atk1_test : MonoBehaviour
{
    public ParticleSystem GhostEffect;
    GameObject DirPos;
    bool isRight = false;

    private float RotationSpeed = 360;
    private float AttackDuration = 0.7f;
    private float ReturnDuration = 0.7f; // 변경
    private float turnDuration = 1.0f; // 변경
    float changeSize = 0.1f;
    float saveRotationSpeed;
    float upRotationSpeed = 360 * 4f;
                                             // private const float ReturnDuration = 4f; // 변경
    SpriteRenderer sprieRenderer;
    BoxCollider2D boxCollider2D;
    private void Start()
    {
        saveRotationSpeed = RotationSpeed;
        boxCollider2D = GetComponent<BoxCollider2D>();
        sprieRenderer = GetComponent<SpriteRenderer>();
        DirPos = GameObject.Find("Dir");

        StartCoroutine(Atk());
    }
    IEnumerator Atk()
    {
        while (true)
        {
            RotationSpeed = saveRotationSpeed;
            if (Pixelate.showHpBar)
            {
                #region Logic
                if (DirPos.transform.position.x < this.transform.position.x)
                {
                    isRight = false;
                    this.transform.Rotate(0, 180, 0);
                }
                else
                {
                    isRight = true; 
                    this.transform.Rotate(0, 0, 270);
                }
                float startTime = Time.time;
                while (Time.time - startTime < 0.1f)
                {
                    this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, 0);
                    yield return null;
                } // Delay
                if (DirPos.transform.position.x < this.transform.position.x)
                    isRight = false;
                else
                    isRight = true;
                
                sprieRenderer.enabled = true; // 공격 시작할때 이미지, 충돌처리 가능
                boxCollider2D.enabled = true; // 공격 시작할때 이미지, 충돌처리 가능


                Vector3 originalPosition = this.transform.position;
                float playerY = originalPosition.y;
                startTime = Time.time;
                while (Time.time - startTime < AttackDuration)
                {
                    float t = (Time.time - startTime) / AttackDuration;
                    RotationSpeed += upRotationSpeed * Time.deltaTime;
                    RotateObject((isRight ? 1 : -1) * RotationSpeed * Time.deltaTime);
                    float newX = originalPosition.x + ((isRight ? 1 : -1) * 9);
                    this.transform.position = Vector3.Lerp(originalPosition, new Vector3(newX, playerY, 0), t);
                //    this.transform.localScale += new Vector3(changeSize, changeSize, changeSize) * Time.deltaTime;
                    yield return null;
                } // x축

                startTime = Time.time;
                while (Time.time - startTime < turnDuration)
                {
                    RotateObject((isRight ? 1 : -1) * RotationSpeed * Time.deltaTime);
                    yield return null;
                } // 제자리 회전


                Vector3 turnPos = this.transform.position;
                startTime = Time.time;
                while (Time.time - startTime < ReturnDuration)
                {
                    float t = (Time.time - startTime) / ReturnDuration;
                    RotationSpeed -= upRotationSpeed * Time.deltaTime;
                    RotateObject((isRight ? -1 : 1) * RotationSpeed * Time.deltaTime);
                    this.transform.position = Vector3.Lerp(turnPos, PlayerController.PlayerPos, t);
                    //this.transform.localScale -= new Vector3(changeSize, changeSize, changeSize) * Time.deltaTime;
                    yield return null;
                } // 돌아오기
                startTime = Time.time;
                while (Time.time - startTime < 0.1f)
                {
                    sprieRenderer.enabled = false;
                    boxCollider2D.enabled = false;
                    yield return null;
                };
            }
            #endregion
        }


    }

    // 회전 로직을 함수로 분리
    private void RotateObject(float rotationAmount)
    {
        this.transform.eulerAngles += new Vector3(0, 0, rotationAmount);
        GhostEffect.transform.eulerAngles += new Vector3(0, 0, rotationAmount);
    }
    private void Update()
    {
        if (!WeaponDataManager.playerBFourbool)
            GhostEffect.gameObject.SetActive(false); // 4번스킬용
        else
        {
            GhostEffect.gameObject.SetActive(true); // 4번스킬용
        }
        if (Pixelate.showHpBar)
        {
        }
    }
}
