using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectItem : MonoBehaviour
{
    CircleCollider2D collider2D;
    public float Radius;
    // �����۰��� �Ÿ��� ���� �ӵ� ����
    public float attachSpeed;
    public static float attractionSpeed;

    private bool isAttracted = false;

    void Start()
    {
        attractionSpeed = attachSpeed;
        collider2D = GetComponent<CircleCollider2D>();
        collider2D.radius = Radius;
    }
}
