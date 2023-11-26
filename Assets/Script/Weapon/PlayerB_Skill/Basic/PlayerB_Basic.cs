using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerB_Basic : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    UnityEngine.Color color;

    bool isRight = true;
     float checkTime;
    bool canAtk = true;

    GameObject dirPos;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dirPos = GameObject.Find("Dir");
        PlayerPrefs.SetFloat("BBasicSpeed", 2);
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        checkTime = 0f;
        canAtk = true;
        isRight = false;
    }
    bool isShowAxe = true;
    // Update is called once per frame


    void Update()
    {
        if (isShowAxe)
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
        else if (!isShowAxe)
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }

        if (Pixelate.showHpBar)
        {
            if(canAtk)
            {
                if(dirPos.transform.position.x  > PlayerController.PlayerPos.x )
                {
                    Debug.Log("오");
                    spriteRenderer.flipX = false;
                    StartCoroutine( ThrowAxe(1));
                    canAtk = false;
                  //  isRight = false;
                }
                else if(dirPos.transform.position.x  < PlayerController.PlayerPos.x )
                {
                    Debug.Log("왼");
                    //  spriteRenderer.flipX = true;
                    StartCoroutine(ThrowAxe(0));
                 //   isRight = true;
                    canAtk = false;
                }

            }
           else if(!canAtk)
            {
                checkTime += Time.deltaTime;
                if (checkTime > PlayerPrefs.GetFloat("BBasicSpeed"))
                {
                    checkTime = 0f;
                    canAtk = true;
                }
            }
        }
    }
    Vector3 startPos;
    IEnumerator ThrowAxe(int flip)
    {
        isShowAxe = true;
        UnityEngine.Color color = spriteRenderer.color;
        color.a = 0f;
        switch(flip)
        {
            case 0: // 왼
                spriteRenderer.flipX = true;
                this.transform.position = new Vector3(PlayerController.PlayerPos.x -0.05f,PlayerController.PlayerPos.y -0.05f, 0);
                startPos = this.transform.position;
                break;

            case 1: // 오
                spriteRenderer.flipX = false;
                this.transform.position = new Vector3(PlayerController.PlayerPos.x+ 0.05f, PlayerController.PlayerPos.y + 0.05f, 0);
                startPos = this.transform.position;
                break;
        }
        float startTime = Time.time; 
        while (Time.time - startTime < 0.6f)
        {
            switch(flip)
            {
                case 0:
                    this.transform.eulerAngles += new Vector3(0, 0, 360*4 * Time.deltaTime);
                    this.transform.position += new Vector3(-8* Time.deltaTime,0, 0); // 날아가는 속도
                    this.transform.position = new Vector3(this.transform.position.x, startPos.y, 0); // y축을 startPos.y로 설정
                    yield return null;
                    break;

                case 1:
                    this.transform.eulerAngles += new Vector3(0, 0, -360*4 * Time.deltaTime);
                    this.transform.position += new Vector3(8 * Time.deltaTime, startPos.y, 0);
                    this.transform.position = new Vector3(this.transform.position.x, startPos.y, 0); // y축을 startPos.y로 설정

                    yield return null;
                    break;

            }
        }
        isShowAxe = false;


    }
}
