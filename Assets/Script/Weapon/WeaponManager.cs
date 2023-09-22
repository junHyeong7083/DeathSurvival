using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] SkillPrefabs;
    GameObject[] WeaponPrefab;

    private Transform skillParent;
    private void Start()
    {
        // "SkillParent" 빈 오브젝트 생성
        GameObject parentObject = new GameObject("Skill Data");
        skillParent = parentObject.transform;

        // "SkillParent" 빈 오브젝트를 "WeaponManager"의 자식으로 설정
        skillParent.parent = this.transform;

        for(int e = 0; e < SkillPrefabs.Length; ++e)
        {
            Instantiate(SkillPrefabs[e], skillParent);
            SkillPrefabs[e].SetActive(false);
            Debug.Log("e : " + e);
        }
    }

    public void SkillA()
    {
        Debug.Log("씨발라ㅏ아리어히ㅏㄴ어라ㅣㄴ허ㅣㄴㅇㄹ");
        SkillPrefabs[0].SetActive(true);
        TestAtk.isTestAtk1 = true;
    }


    public void SkillB()
    {
         StartCoroutine(SkillBpattern());
    }
    bool startInit = false;
    IEnumerator SkillBpattern()
    {
        SpriteRenderer spriteRenderer = SkillPrefabs[1].GetComponent<SpriteRenderer>();
        UnityEngine.Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;

        SkillPrefabs[1].SetActive(true);

        float startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime ) /1f;

            color.a = alpha;
            spriteRenderer.color = color;

            yield return null;
        }
    }


    private void Update()
    {
    }

}
