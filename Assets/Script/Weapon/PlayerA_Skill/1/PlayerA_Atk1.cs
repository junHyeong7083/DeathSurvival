using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA_Atk1 : MonoBehaviour
{
    public float speed;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
        // animator.speed = speed;
        animator.speed = TestPattern.testValue;
    }
}
