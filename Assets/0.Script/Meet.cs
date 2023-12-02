using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meet : MonoBehaviour
{
    GameObject Player;
    bool isAttracted = false;

    float Timer;
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
        Timer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance <= PlayerState.detectRange) // 아이템 탐지
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
         //   transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, PlayerState.attractionSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 15f * Time.deltaTime);
        }
    }

}
