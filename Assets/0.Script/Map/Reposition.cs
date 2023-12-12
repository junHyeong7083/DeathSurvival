using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Reposition : MonoBehaviour
{
    Vector3 prePos;
    Vector3 currentPos;


    public int width = 10;  // �ν����Ϳ��� ������ ���� ũ��
    public int height = 10; // �ν����Ϳ��� ������ ���� ũ��

    [Header("������ƮŸ�ϸ�")]
    public Tilemap objTilemap;

    [Header("������Ʈ Ÿ��")]
    public TileBase[] objectTile;

    [Header("������Ʈ ���� Ȯ��")]
    [SerializeField]
    [Range(0f, 100f)]
    float spawnPercentage;

    [Header("������Ʈ���� �ּ� �Ÿ�")]
    [SerializeField]
    float spawndistance;

    private void Start()
    {
        prePos = PlayerController.PlayerPos;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        Vector3 playerPos = PlayerController.PlayerPos;
        Vector3 myPos = transform.position;

        float diffX =Mathf.Abs( playerPos.x - myPos.x);
        float diffY =Mathf.Abs( playerPos.y - myPos.y);

        switch(transform.tag)
        {
            case "Ground":
                currentPos = playerPos;
                int dirX = prePos.x < currentPos.x ? 1 : -1;
                int dirY = prePos.y < currentPos.y ? 1 : -1;
                Debug.Log("change!!!");
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * 57* dirX);
                    prePos = currentPos;
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * 60 * dirY);
                    prePos = currentPos;
                }
                break;

        }
    }
}
