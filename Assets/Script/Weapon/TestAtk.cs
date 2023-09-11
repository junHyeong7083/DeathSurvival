using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk : MonoBehaviour
{
    public GameObject weaponPrefab; // 원운동할 오브젝트의 프리팹
    public Transform PlayerTransform;  // a 오브젝트의 Transform
    public float rotationSpeed = 10f; // 원운동의 속도
    public float distance;
    public int numberOfWeapon = 5; // 생성할 circle의 개수
    float[] angle; // 시작 각도


    GameObject[] circle;
    public static bool isTestWeapon = false;
    bool isStart = false; // 생성효과
    bool isInit = false;
    IEnumerator isSkillStart()
    {
        #region Setting
        SpriteRenderer[] spriteRenderers = new SpriteRenderer[numberOfWeapon]; ;
        Color[] colors =   new Color[numberOfWeapon]; ;
        for(int e = 0; e < numberOfWeapon; e++)
        {
            spriteRenderers[e] = circle[e].GetComponent<SpriteRenderer>();
            colors[e].a = 0f;
            spriteRenderers[e].color = colors[e];
        }
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 1f)
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

        if(isTestWeapon)
        {
            if(!isInit)
            {
                circle = new GameObject[numberOfWeapon]; // 배열 초기화
                angle = new float[numberOfWeapon];

                for (int i = 0; i < numberOfWeapon; i++)
                {
                    circle[i] = Instantiate(weaponPrefab, PlayerTransform.position, Quaternion.identity); // 프리팹을 인스턴스화하여 circle 배열에 할당
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
            }
            else if(isStart)
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
