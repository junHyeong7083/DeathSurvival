using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMove : MonoBehaviour
{
    void Update()
    {
        this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, -10);
    }
}
