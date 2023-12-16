using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerA_Atk4 : MonoBehaviour
{
    bool isStart = true;
    float skillTime = 0f;
    public float alphaTime;

    Image atk4Icon;

    SpriteRenderer spriteRenderer;
    Color color;
    float coolTime = 0f;
    void Start()
    {
        GameObject atk4IconObj = GameObject.Find("CameraCanvas/ShowSkillIcon/PlayerA/BG4/SkillD");
        if (atk4IconObj != null)
        {
            atk4Icon = atk4IconObj.GetComponent<Image>();
            atk4Icon.fillAmount = 1f;
        }
            this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y + 1f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    IEnumerator StartPattern()
    {
        color.a = 0f;
        spriteRenderer.color = color;


        float startTime = Time.time;
        while (Time.time - startTime < alphaTime)
        {
            float alpha = (Time.time - startTime) / alphaTime;
            color.a = alpha;
            spriteRenderer.color = color;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < WeaponDataManager.playerAFourTime - (alphaTime * 2))
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
            coolTime = 0f;
            StartCoroutine(StartPattern());

            WeaponDataManager.playerAFourbool = true;
            skillTime += Time.deltaTime;

            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

            // 몬스터들이 이동을 못하게 하고싶음

            foreach (GameObject monster in monsters)
            {
                // 몬스터 오브젝트의 자식 오브젝트들을 활성화);
                Transform monsterTransform = monster.transform;
                Transform child = monsterTransform.GetChild(0);
                child.gameObject.SetActive(true);
                check++;
            }
            if (skillTime > WeaponDataManager.playerAFourTime)
            {
                foreach (GameObject monster in monsters)
                {
                    /*  // 몬스터 오브젝트의 자식 오브젝트들을 활성화
                      Transform monsterTransform = monster.transform;
                      Transform child = monsterTransform.GetChild(0);
                      child.gameObject.SetActive(false);*/
                    monster.SendMessage("OnSkillEnd", SendMessageOptions.DontRequireReceiver);
                    check--;
                }
            }
            if (skillTime > WeaponDataManager.playerAFourTime + 0.5f)
            {
                WeaponDataManager.playerAFourbool = false;
                isStart = false;
                atk4Icon.fillAmount = 0f;
                skillTime = 0f;
            }

        }
        if (!isStart)
        {
            coolTime += Time.deltaTime;
            float fillAmount = Mathf.Clamp(coolTime / WeaponDataManager.playerAFourCoolTime, 0, 1);
            atk4Icon.fillAmount = fillAmount;
        }

        if (coolTime >= WeaponDataManager.playerAFourCoolTime)
        {
            atk4Icon.fillAmount = 1;
           isStart = true;
            coolTime = 0f;
        }
    }



}
