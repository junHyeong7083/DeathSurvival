using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationSpeed : MonoBehaviour
{
    Animator animator;
    public float animationSpeed;
    public string animationName;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;
    }
}
