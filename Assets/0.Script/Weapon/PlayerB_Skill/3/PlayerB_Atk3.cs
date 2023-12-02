using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

public class PlayerB_Atk3 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;

    SpriteRenderer axespriteRenderer;
    UnityEngine.Color axecolor;

    SpriteRenderer AxeEffectspriteRenderer;
    UnityEngine.Color AxeEffectcolor;

    Vector3 originTargetScale;
    GameObject targetObj;
    public GameObject Axe;
    public GameObject AxeEffect;

     float detectionRadius = 3;
    public float coolTime = 3f;
    float lastDetectionTime = 0f;

    Camera cam;
    Vector3 cameraOriginalPos;

    BoxCollider2D axeCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        axespriteRenderer = Axe.GetComponent<SpriteRenderer>();
        AxeEffectspriteRenderer = AxeEffect.GetComponent<SpriteRenderer>();

        AxeEffectcolor = AxeEffectspriteRenderer.color;
        axecolor = axespriteRenderer.color;
        color = spriteRenderer.color;

        axeCollider = Axe.GetComponent<BoxCollider2D>();

        originTargetScale = this.transform.localScale;

        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;

        StartCoroutine(Atk());
    }

    bool isDetect = false;
    IEnumerator Atk()
    {
        while (true)
        {
            this.transform.localScale = originTargetScale;

            color.a = 1f;
            axecolor.a = 1f;
            AxeEffectcolor.a = 1f;

            axespriteRenderer.color = axecolor;
            AxeEffectspriteRenderer.color = AxeEffectcolor;

            Axe.gameObject.SetActive(false);
            AxeEffect.gameObject.SetActive(false);

            this.gameObject.SetActive(true);

            float startTime = Time.time;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerController.PlayerPos, detectionRadius);
            if(targetObj == null)
            {
                foreach (Collider2D collider in colliders)
                {
                    yield return null;
                    // 적인지 확인
                    if (collider.CompareTag("Monster"))
                    {
                        // 쿨다운 리셋
                        lastDetectionTime = 0f;
                        targetObj = collider.gameObject;
                        isDetect = true;
                        break; // 첫 번째 적만 탐지하고 루프 종료

                    }
                }  
            }
            if (isDetect)
            {
                spriteRenderer.color = color;
                while (Time.time - startTime < 2f)
                {
                    float alpha = (Time.time - startTime) / 2f;
                    color.a = 1 - alpha;
                    spriteRenderer.color = color;
                    this.transform.position = new Vector3(targetObj.transform.position.x, targetObj.transform.position.y - 0.1f, 0);

                    yield return null;
                }

                AxeEffect.gameObject.SetActive(true);
                Axe.gameObject.SetActive(true);
                startTime = Time.time;
                Axe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 15f, 0);
                Vector3 targetAxe = new Vector3(this.transform.position.x, this.transform.position.y + 30f, 0);
                while (Time.time - startTime < 0.5f)
                {
                    this.transform.position = targetObj.transform.position;
                    float t = (Time.time - startTime) / 0.5f;
                    Axe.transform.position = Vector3.Lerp(targetAxe, this.transform.position, t);

                    yield return null;
                }
                axeCollider.enabled = true;

                startTime = Time.time;
                while (Time.time - startTime < 1.5f)
                {
                    yield return null;
                }

                startTime = Time.time;
                axeCollider.enabled = false;
                while (Time.time - startTime < 0.5f)
                {
                    float alpha = (Time.time - startTime) / 0.5f;
                    axecolor.a = 1 - alpha;
                    AxeEffectcolor.a = 1 - alpha;

                    AxeEffectspriteRenderer.color = AxeEffectcolor;
                    axespriteRenderer.color = axecolor;

                    yield return null;
                }
                isDetect = false;
                targetObj = null;
            }
        }
    }

    IEnumerator CameraShaking(float duration, float magnitude)
    {
        float timer = 0;
        while (timer <= duration)
        {
            cam.transform.localPosition = Random.insideUnitSphere * magnitude + cameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = cameraOriginalPos;

    } // 카메라 쉐이킹

    // Update is called once per frame
    void Update()
        {
            lastDetectionTime += Time.deltaTime;
            if (lastDetectionTime > coolTime)
            {
                //DetectAndAttackEnemy();
            }

        }

    
}

