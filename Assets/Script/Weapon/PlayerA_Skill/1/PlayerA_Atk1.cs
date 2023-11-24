using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA_Atk1 : MonoBehaviour
{
    public float speed;
    Animator animator;
    public static bool playerA_Atk1 = false;
    void Start()
    {
        playerA_Atk1 = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
        // animator.speed = speed;
        animator.speed = WeaponDataManager.playerAOneSpeed;
    }
}
