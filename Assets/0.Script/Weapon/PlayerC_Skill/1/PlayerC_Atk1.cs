using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerC_Atk1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;

    CircleCollider2D circleCollider2D;
    Image atk1Icon;
    Vector3 originScale;
    [SerializeField]
    float sizeValue;
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        originScale = this.transform.localScale;
        GameObject atk1IconObj = GameObject.Find("CameraCanvas/ShowSkillIcon/PlayerC/BG1/SkillA");
        if (atk1IconObj != null)
        {
            atk1Icon = atk1IconObj.GetComponent<Image>();
            atk1Icon.fillAmount = 1f;
        }
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
            circleCollider2D.enabled = true;
            atk1Icon.fillAmount = 0f;
            while (Time.time - startTime < WeaponDataManager.playerCOneContinueTime)
            {
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = alpha;
                spriteRenderer.color = color;
                this.transform.localScale += new Vector3(sizeValue * Time.deltaTime, sizeValue * Time.deltaTime, 0);

                yield return null;
            }
            startTime = Time.time;
            circleCollider2D.enabled = false;   
            while (Time.time - startTime < WeaponDataManager.playerCOneCoolTime)
            {
                float t = (Time.time - startTime) / WeaponDataManager.playerCOneCoolTime;
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = 1 - alpha;
                spriteRenderer.color = color;
                float fillAmount = Mathf.Clamp(t / WeaponDataManager.playerAFourCoolTime, 0, 1);
                atk1Icon.fillAmount = fillAmount;
                yield return null;
            }
        }

    }

    private void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
    }
}
