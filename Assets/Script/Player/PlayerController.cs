using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public static bool isMove = false;
    public static Vector3 PlayerPos;
    GameObject DirObj;
    void Start()
    {
        DirObj = GameObject.Find("Dir");
        animator = GetComponent<Animator>();
        animator.SetBool("isDie", false);
    }
    void Update()
    {
        if (!UIManager.isPause)
        {
            if(!PlayerHpBar.isDie)
            {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                PlayerPos = this.transform.position;
                if (h != 0 || v != 0)
                {
                    animator.SetBool("isInput", true);
                    isMove = true;

                    if (h > 0)
                    {

                        animator.SetBool("isRight", true);
                        DirObj.transform.position = new Vector3(PlayerPos.x + 1f, PlayerPos.y, 0);
                    }
                    else if (h < 0)
                    {
                        animator.SetBool("isRight", false);
                        DirObj.transform.position = new Vector3(PlayerPos.x - 1f, PlayerPos.y, 0);
                    }
                }
                else
                {
                    animator.SetBool("isInput", false);
                    isMove = false;
                }
                // animator.SetFloat("InputX", h);
                // animator.SetFloat("InputY", v); 

                PlayerPos.x += h * Time.deltaTime * PlayerState.Speed;
                PlayerPos.y += v * Time.deltaTime * PlayerState.Speed;

                this.transform.position = PlayerPos;
            }

        }
        if (PlayerHpBar.isDie)
            animator.SetBool("isDie",true);
     
    }
}
