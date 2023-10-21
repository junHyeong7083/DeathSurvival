using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Animator[] allAnimators = FindObjectsOfType<Animator>();

        // 각 Animator 컴포넌트에서 현재 재생 중인 모든 애니메이션을 종료합니다.
        foreach (Animator animator in allAnimators)
        {
            animator.speed = 1f; // 애니메이션 재생 속도를 0으로 설정하여 멈춥니다.
        }
    }

    void Update()
    {

    }
}
