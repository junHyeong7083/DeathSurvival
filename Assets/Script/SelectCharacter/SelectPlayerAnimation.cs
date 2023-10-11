using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerAnimation : MonoBehaviour
{
    public int SelectNum;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (SelectNum == SelectCharacter.selectNum)
            animator.SetBool("isSelect", true);
        else
            animator.SetBool("isSelect", false);
    }
}
