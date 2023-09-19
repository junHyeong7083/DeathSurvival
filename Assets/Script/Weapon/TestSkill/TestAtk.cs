using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestAtk : MonoBehaviour
{
    GameObject SkillData;
    public GameObject weaponPrefab; // 원운동할 오브젝트의 프리팹
    Transform PlayerTransform;  // a 오브젝트의 Transform
    public float rotationSpeed = 10f; // 원운동의 속도
    public float distance;
    public int numberOfWeapon = 5; // 생성할 circle의 개수
    float[] angle; // 시작 각도

    GameObject skillParentA; // 빈 오브젝트를 저장할 변수
    GameObject[] circle;
    public static bool isTestAtk1 = false;
    bool isStart = false; // 생성효과
    bool isInit = false;

    GameObject Player;

    void Start()
    {
        SkillData = GameObject.Find("WeaponManager/Skill Data");
        Player = GameObject.Find("Player");
        PlayerTransform = Player.transform;
        // 스킬을 넣을 빈 오브젝트 생성
        skillParentA = new GameObject("Skill ParentA");

        skillParentA.transform.parent = SkillData.transform;
    }

    IEnumerator isSkillStart()
    {
        #region Setting
        SpriteRenderer[] spriteRenderers = new SpriteRenderer[numberOfWeapon];
        Color[] colors = new Color[numberOfWeapon];
        for (int e = 0; e < numberOfWeapon; e++)
        {
            spriteRenderers[e] = circle[e].GetComponent<SpriteRenderer>();
            colors[e].a = 0f;
            spriteRenderers[e].color = colors[e];
        }
        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;

            for (int e = 0; e < numberOfWeapon; e++)
            {
                colors[e].a = alpha;
                spriteRenderers[e].color = colors[e];
            }
            yield return null;
        }
        isStart = true;
    }


    void Update()
    {

        if (isTestAtk1)
        {
            if (!isInit)
            {
                circle = new GameObject[numberOfWeapon]; // 배열 초기화
                angle = new float[numberOfWeapon];

                for (int i = 0; i < numberOfWeapon; i++)
                {
                    circle[i] = Instantiate(weaponPrefab, skillParentA.transform); // 빈 오브젝트를 부모로 사용
                    angle[i] = (2 * Mathf.PI / numberOfWeapon) * i; // 각도를 균등하게 분배

                    float x = PlayerTransform.position.x + Mathf.Cos(angle[i]) * distance;
                    float y = PlayerTransform.position.y + Mathf.Sin(angle[i]) * distance;

                    circle[i].transform.position = new Vector3(x, y, circle[i].transform.position.z);
                }
                isInit = true;
            }

            if (!isStart)
            {
                StartCoroutine(isSkillStart());

                for(int e = 0; e< numberOfWeapon; e++)
                {
                    float x = PlayerTransform.position.x + Mathf.Cos(angle[e]) * distance;
                    float y = PlayerTransform.position.y + Mathf.Sin(angle[e]) * distance;
                    circle[e].transform.position = new Vector3(x, y, circle[e].transform.position.z);
                }
            }
            else if (isStart)
            {
                for (int e = 0; e < angle.Length; ++e)
                {
                    angle[e] += rotationSpeed * Time.deltaTime;

                    float x = PlayerTransform.position.x + Mathf.Cos(angle[e]) * distance;
                    float y = PlayerTransform.position.y + Mathf.Sin(angle[e]) * distance;

                    circle[e].transform.position = new Vector3(x, y, circle[e].transform.position.z);
                }
            }
        }
    }
}
