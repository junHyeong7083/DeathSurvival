using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponefieldMoving : MonoBehaviour
{
    public GameObject FieldUp;
    public GameObject FieldDown;
    public GameObject FieldLeft;
    public GameObject FieldRight;

    [SerializeField]
    float responePosvalueX;
    [SerializeField]
    float responePosvalueY;
    private void Update()
    {
        FieldUp.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y + responePosvalueY, 0);

        FieldDown.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y - responePosvalueY, 0);

        FieldRight.transform.position = new Vector3(PlayerController.PlayerPos.x + responePosvalueX, PlayerController.PlayerPos.y, 0);

        FieldLeft.transform.position = new Vector3(PlayerController.PlayerPos.x - responePosvalueX, PlayerController.PlayerPos.y ,  0);
    }
}
