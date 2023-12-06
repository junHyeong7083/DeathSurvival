using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Update()
    {
      //  this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, -10);
        this.transform.position = Vector3.Lerp(this.transform.position, PlayerController.PlayerPos, Time.deltaTime * speed);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);
    }
}
