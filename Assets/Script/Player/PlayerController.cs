using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public static bool isMove = false;
    public static Vector3 PlayerPos;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        PlayerPos = this.transform.position;
        if (h != 0 || v != 0)
        {
            animator.SetBool("isInput", true);
            isMove = true;
        }
        else
        {
            animator.SetBool("isInput", false);
            isMove = false;
        }

        animator.SetFloat("InputX", h);
        animator.SetFloat("InputY", v); 

        PlayerPos.x += h * Time.deltaTime * PlayerState.Speed;
        PlayerPos.y += v * Time.deltaTime * PlayerState.Speed;

        this.transform.position = PlayerPos;
    }
}
