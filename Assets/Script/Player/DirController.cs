using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirController : MonoBehaviour
{
    public static Vector3 DirPos;
    // Update is called once per frame
    void Update()
    {
        DirPos = this.transform.position;
    }
}
