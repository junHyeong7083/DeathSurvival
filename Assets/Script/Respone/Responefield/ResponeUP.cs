using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponeUP : MonoBehaviour
{
    public GameObject TestMon;


    private void Start()
    {
        StartCoroutine(Respone());
    }

    IEnumerator Respone()
    {
            float startTime = Time.time;
            int randomPosX = Random.Range(-1, 2); // -1 0 1
            while(Time.time - startTime > 1.5f)
            {
                yield return null;
            }
        
    }

}
