using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Animator[] allAnimators = FindObjectsOfType<Animator>();

        // �� Animator ������Ʈ���� ���� ��� ���� ��� �ִϸ��̼��� �����մϴ�.
        foreach (Animator animator in allAnimators)
        {
            animator.speed = 1f; // �ִϸ��̼� ��� �ӵ��� 0���� �����Ͽ� ����ϴ�.
        }
    }

    void Update()
    {

    }
}
