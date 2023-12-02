using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerB_Atk2 : MonoBehaviour
{
    public ParticleSystem GhostEffect;
    GameObject DirPos;
    public GameObject magneticField;
    bool isRight = false;

    SpriteRenderer spriteRenderer;
    SpriteRenderer magneticspriteRenderer;
   UnityEngine.Color magneticcolor;
    UnityEngine.Color color;
    BoxCollider2D boxCollider2D;
    void Start()
    {
        magneticField.gameObject.SetActive(false);
        magneticspriteRenderer = magneticField.GetComponent<SpriteRenderer>();
        DirPos = GameObject.Find("Dir");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        color = spriteRenderer.color;
        magneticcolor = magneticspriteRenderer.color;

        StartCoroutine(Atk());
    }
    private void RotateObject(float rotationAmount)
    {
        this.transform.eulerAngles += new Vector3(0, 0, rotationAmount);
        GhostEffect.transform.eulerAngles += new Vector3(0, 0, rotationAmount);
    }


    float AttackDuration = 0.4f;
    float RotationSpeed = 720f;
    float MagnetDuration = 2.0f;

    IEnumerator Atk()
    {
        while(true)
        {
            if (Pixelate.showHpBar)
            {
                #region Logic
                color.a = 1f;
                magneticcolor.a = 1f;
                spriteRenderer.color = color;
                magneticspriteRenderer.color = magneticcolor;

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


                spriteRenderer.enabled = true; // 공격 시작할때 이미지, 충돌처리 가능
                boxCollider2D.enabled = true; // 공격 시작할때 이미지, 충돌처리 가능


                Vector3 originalPosition = this.transform.position;
                float playerY = originalPosition.y;
                startTime = Time.time;
                while (Time.time - startTime < AttackDuration)
                {
                    float t = (Time.time - startTime) / AttackDuration;
                    //RotationSpeed += upRotationSpeed * Time.deltaTime;
                    RotateObject((isRight ? 1 : -1) * RotationSpeed * Time.deltaTime);
                    float newX = originalPosition.x + ((isRight ? 1 : -1) * 6);
                    this.transform.position = Vector3.Lerp(originalPosition, new Vector3(newX, playerY, 0), t);
                    //    this.transform.localScale += new Vector3(changeSize, changeSize, changeSize) * Time.deltaTime;
                    yield return null;
                } // x축
                boxCollider2D.enabled = false;
                magneticField.gameObject.SetActive(true);
                startTime = Time.time;
                while(Time.time - startTime < MagnetDuration)
                {
                    WeaponDataManager.playerBTwobool = true;
                    yield return null;
                }
                startTime = Time.time;
                WeaponDataManager.playerBTwobool = false;
                while (Time.time - startTime < 0.3f)
                {
                    float alpha = (Time.time - startTime) / 0.3f;
                    color.a = 1 - alpha;
                    magneticcolor.a = 1 - alpha;
                    magneticspriteRenderer.color = magneticcolor;
                    spriteRenderer.color = color;

                    yield return null;
                }
                magneticField.gameObject.SetActive(false);
                #endregion
            }
        }
        }
    private void Update()
    {
        if (!WeaponDataManager.playerBFourbool)
            GhostEffect.gameObject.SetActive(false); // 4번스킬용
        else
        {
            GhostEffect.gameObject.SetActive(true); // 4번스킬용
        }
    }
}
