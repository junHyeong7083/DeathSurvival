
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
        if (collision.gameObject.tag == "ItemDetect")
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance <= PlayerState.detectRange) // ������ Ž��
            isAttracted = true;
        else
            isAttracted = false;


        if (isAttracted)
        {
            // �÷��̾� ��ġ�� ������ �̵�
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 15f * Time.deltaTime);
        }
    }

}
