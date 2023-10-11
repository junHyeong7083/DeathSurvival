using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meet : MonoBehaviour
{


    GameObject Player;
    bool isAttracted = false; 
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance <= PlayerState.detectRange)
        {
            isAttracted = true;
        }
        else
        {
            isAttracted = false;
        }
        if (isAttracted)
        {
            // 플레이어 위치로 아이템을 부드럽게 이동시킴
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, detectItem.attractionSpeed * Time.deltaTime);
        }
    }

}
