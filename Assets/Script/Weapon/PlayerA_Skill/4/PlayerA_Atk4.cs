using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerA_Atk4 : MonoBehaviour
{
    bool isStart = true;
    float skillTime = 0f;
    public float alphaTime;

    SpriteRenderer spriteRenderer;
    Color color;

    void Start()
    {
        this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y + 1f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void OnEnable()
    {
        isStart = true;
        skillTime = 0f;
    }


    IEnumerator StartPattern()
    {
        color.a = 0f;
        spriteRenderer.color = color;


        float startTime = Time.time;
        while(Time.time - startTime < alphaTime)
        {
            float alpha = (Time.time - startTime) / alphaTime;
            color.a = alpha;
            spriteRenderer.color = color;

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < WeaponDataManager.playerAFourTime-(alphaTime *2))
        {
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < alphaTime)
        {
            float alpha = (Time.time - startTime) / alphaTime;
            color.a = 1 - alpha;
            spriteRenderer.color = color;

            yield return null;
        }
    }

    int check = 0;
    void Update()
    {
        this.transform.eulerAngles += new Vector3(0, 0, -45) * Time.deltaTime * 10;
        this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y + 1f, 0);


        if (isStart)
        {
            StartCoroutine(StartPattern());

            WeaponDataManager.playerAFourbool = true;
            skillTime += Time.deltaTime;

            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

            // 몬스터들이 이동을 못하게 하고싶음

            foreach (GameObject monster in monsters)
            {
                // 몬스터 오브젝트의 자식 오브젝트들을 활성화
                Transform monsterTransform = monster.transform;
                Transform child = monsterTransform.GetChild(0);
                child.gameObject.SetActive(true);
                check++;
            }
            if (skillTime > WeaponDataManager.playerAFourTime)
            {
                foreach (GameObject monster in monsters)
                {
                    // 몬스터 오브젝트의 자식 오브젝트들을 활성화
                    Transform monsterTransform = monster.transform;
                    Transform child = monsterTransform.GetChild(0);
                    child.gameObject.SetActive(false);
                    check--;
                }
                WeaponDataManager.playerAFourbool = false;
            }
            if (skillTime > WeaponDataManager.playerAFourTime + 1.5f)
                isStart = false;

        }

        if (!isStart)
        {
            /* this.gameObject.SetActive(false);*/ // 나중에 스킬트리에 넣으면 이런식으로 사용할듯
            Destroy(this.gameObject);
        }
    }

}
