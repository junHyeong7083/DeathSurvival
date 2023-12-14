using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_Atk2 : MonoBehaviour
{
    public GameObject atkRangeObj;


    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        StartCoroutine(Atk());
    }

    IEnumerator Atk()
    {
        while (true)
        {
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



                yield return null;
            }
        }


    }

    private void Update()
    {
        this.gameObject.transform.position = PlayerController.PlayerPos;
    }
}
