using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meet : MonoBehaviour
{
    GameObject Player;
    bool isAttracted = false; 
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "detectField")
        {
            isAttracted = true;
        }
    }

    void Update()
    {
        if (isAttracted)
        {
            // 플레이어 위치로 아이템을 부드럽게 이동시킴
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, detectItem.attractionSpeed * Time.deltaTime);
        }
    }

}
