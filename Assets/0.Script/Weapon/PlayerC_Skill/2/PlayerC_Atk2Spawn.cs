using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_Atk2Spawn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        StartCoroutine(SpawnAtk());
    }

    [SerializeField]
    float alphaTime;
    [SerializeField]
    float scaleValue;
    [SerializeField]
    float rotateValue;
    IEnumerator SpawnAtk()
    {
        this.gameObject.SetActive(true);
        color.a = 0f;
        spriteRenderer.color = color;
        float startTime = Time.time;
        while(Time.time - startTime < alphaTime)
        {
            float alpha = (Time.time - startTime) / alphaTime;
            color.a = alpha;
            spriteRenderer.color = color;
            this.transform.eulerAngles += new Vector3(0, 0, rotateValue * Time.deltaTime);
            this.transform.localScale += new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, 0);
            yield return null;
        }

        startTime = Time.time; 
        while(Time.time - startTime < WeaponDataManager.playerCTwoAtkContinueTime)
        {
            this.transform.localScale += new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, 0);
            this.transform.eulerAngles += new Vector3(0, 0, rotateValue * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < alphaTime)
        {
            float alpha = (Time.time - startTime) / alphaTime;

            color.a = 1 - alpha;
            spriteRenderer.color = color;
            this.transform.eulerAngles += new Vector3(0, 0, rotateValue * Time.deltaTime);
            this.transform.localScale += new Vector3(-scaleValue * Time.deltaTime, -scaleValue * Time.deltaTime, 0);
            yield return null;
        }

        Destroy(this.gameObject);

    }
}
