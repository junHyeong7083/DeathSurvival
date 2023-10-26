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

            // ���͵��� �̵��� ���ϰ� �ϰ����

            foreach (GameObject monster in monsters)
            {
                // ���� ������Ʈ�� �ڽ� ������Ʈ���� Ȱ��ȭ
                Transform monsterTransform = monster.transform;
                Transform child = monsterTransform.GetChild(0);
                child.gameObject.SetActive(true);
                check++;
            }
            if (skillTime > WeaponDataManager.playerAFourTime)
            {
                foreach (GameObject monster in monsters)
                {
                    // ���� ������Ʈ�� �ڽ� ������Ʈ���� Ȱ��ȭ
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
            /* this.gameObject.SetActive(false);*/ // ���߿� ��ųƮ���� ������ �̷������� ����ҵ�
            Destroy(this.gameObject);
        }
    }

}
