using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;

    [SerializeField]
    float showTime;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        StartCoroutine(FadeinOut());
    }

    IEnumerator FadeinOut()
    {
        color.a = 0f;
        spriteRenderer.color  = color;
        float startTime = Time.time;
        while(Time.time - startTime < showTime)
        {
            float alpha = (Time.time - startTime) / showTime;
            color.a = alpha;
            spriteRenderer.color = color;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < showTime)
        {
            float alpha = (Time.time - startTime) / showTime;
            color.a =1- alpha;
            spriteRenderer.color = color;

            yield return null;
        }
        SceneManager.LoadScene(1);
        
    }
}
