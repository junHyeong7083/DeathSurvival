using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{

    float Timer = 0f;

    private void OnEnable()
    {
        Timer = 0f;
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1.7f) // 블러드 애니메이션의 마지막 지점 1.5f
        {
            this.gameObject.SetActive(false);
        }
    }
}
