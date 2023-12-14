using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_Atk1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;

    CircleCollider2D circleCollider2D;

    Vector3 originScale;
    [SerializeField]
    float sizeValue;
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        originScale = this.transform.localScale;

        StartCoroutine(Atk());
    }

   IEnumerator Atk()
    {
        while (true)
        {
            this.gameObject.SetActive(true);
            this.transform.localScale = originScale;
            color.a = 0f;
            spriteRenderer.color = color;


            float startTime = Time.time;
            while (Time.time - startTime < WeaponDataManager.playerCOneContinueTime)
            {
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = alpha;
                spriteRenderer.color = color;
                this.transform.localScale += new Vector3(sizeValue * Time.deltaTime, sizeValue * Time.deltaTime, 0);

                yield return null;
            }
            startTime = Time.time;
            while (Time.time - startTime < WeaponDataManager.playerCOneCoolTime)
            {
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = 1 - alpha;
                spriteRenderer.color = color;

                yield return null;
            }
        }

    }

    private void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
    }
}
