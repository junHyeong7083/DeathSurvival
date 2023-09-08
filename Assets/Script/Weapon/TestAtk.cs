using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk : MonoBehaviour
{

    public Transform centerObject;  // a 오브젝트의 Transform
    public float rotationSpeed = 10f; // 원운동의 속도

    public float angle = 0f; // 시작 각도

    void Update()
    {
        // 각도를 업데이트
        angle += rotationSpeed * Time.deltaTime;

        // 원의 위치 계산
        float x = centerObject.position.x + Mathf.Cos(angle)*2.5f ;
        float y = centerObject.position.y + Mathf.Sin(angle) *2.5f ;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
