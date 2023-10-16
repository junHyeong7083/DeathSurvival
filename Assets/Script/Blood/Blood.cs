using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    float Timer = 0f;
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1.5f)
        {
            this.gameObject.SetActive(false);
            Timer = 0f;
        }
    }
}
