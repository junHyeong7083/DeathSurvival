using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk : MonoBehaviour
{

    public Transform centerObject;  // a ������Ʈ�� Transform
    public float rotationSpeed = 10f; // ����� �ӵ�

    public float angle = 0f; // ���� ����

    void Update()
    {
        // ������ ������Ʈ
        angle += rotationSpeed * Time.deltaTime;

        // ���� ��ġ ���
        float x = centerObject.position.x + Mathf.Cos(angle)*2.5f ;
        float y = centerObject.position.y + Mathf.Sin(angle) *2.5f ;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
