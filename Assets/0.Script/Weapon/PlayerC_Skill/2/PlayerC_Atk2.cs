using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerC_Atk2 : MonoBehaviour
{
    public GameObject atkRangeObj;

    Image atk2Icon;
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;
    private void Start()
    {
        GameObject atk2IconObj = GameObject.Find("CameraCanvas/ShowSkillIcon/PlayerC/BG2/SkillB");
        if (atk2IconObj != null)
        {
            atk2Icon = atk2IconObj.GetComponent<Image>();
            atk2Icon.fillAmount = 1f;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        StartCoroutine(Atk());
    }

    IEnumerator Atk()
    {
        while (true)
        {
            atk2Icon.fillAmount = 0f;
            Instantiate(atkRangeObj, new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, 0), Quaternion.identity);
            float startTime = Time.time;
            color.a = 0f;
            spriteRenderer.color = color;
            while (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = alpha;
                spriteRenderer.color = color;

                yield return null;
            }
            Instantiate(atkRangeObj, new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y,0), Quaternion.identity);
            startTime = Time.time;
            while (Time.time - startTime < 1)
            {
                yield return null;
            }
            Instantiate(atkRangeObj, new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, 0), Quaternion.identity);
            startTime = Time.time;
            while (Time.time - startTime <1)
            {
                yield return null;
            }

            startTime = Time.time;
            while(Time.time - startTime < 0.5f)
            {
                float alpha = (Time.time - startTime) / 0.5f;
                color.a = 1 - alpha;
                spriteRenderer.color = color;
                yield return null;
            }

            startTime = Time.time;
            while (Time.time - startTime < WeaponDataManager.playerCTwoCoolTime)
            {
                float t = (Time.time - startTime) / WeaponDataManager.playerCTwoCoolTime;

                float fillAmount = Mathf.Clamp(t / WeaponDataManager.playerAFourCoolTime, 0, 1);
                atk2Icon.fillAmount = fillAmount;

                yield return null;
            }
        }


    }

    private void Update()
    {
        this.gameObject.transform.position = PlayerController.PlayerPos;
    }
}
