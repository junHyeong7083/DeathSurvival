using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Reposition : MonoBehaviour
{
    Vector3 prePos;
    Vector3 currentPos;

    public int width = 10;
    public int height = 10;
    Tilemap tilemap;
    CompositeCollider2D compositeCollider2D;

    [Header("Objects")]
    public GameObject[] obj;

    [Header("Minimum Distance Between Objects")]
    [SerializeField]
    float spawndistance;

    private Dictionary<Tilemap, List<GameObject>> tilemapObjects = new Dictionary<Tilemap, List<GameObject>>();

    private void Start()
    {
        compositeCollider2D = GetComponent<CompositeCollider2D>();
        tilemap = GetComponent<Tilemap>();
        prePos = PlayerController.PlayerPos;

        // �� Ÿ�ϸʿ� ���� �ڽ� ������Ʈ ����Ʈ �ʱ�ȭ
        tilemapObjects.Add(tilemap, new List<GameObject>());

        for(int e = 0; e <100; ++e )
        {
            SpawnRandomObject(tilemap);
        }
    }

    Vector2 GetTilemapSize(CompositeCollider2D collider)
    {
        Bounds bounds = collider.bounds;
        return new Vector2(bounds.size.x, bounds.size.y);
    }

    void SpawnRandomObject(Tilemap currentTilemap)
    {
        // Ÿ�ϸ� ���� ���� ���� ��ġ�� �ִ��� Ȯ��
        Vector2 tilemapSize = GetTilemapSize(compositeCollider2D);
        Bounds tilemapBounds = new Bounds(transform.position, new Vector3(tilemapSize.x-10, tilemapSize.y-10 , 0f));

        // ���� ���� ������ ������ ��ġ ����
        Vector2 randomOffset = Random.insideUnitCircle * spawndistance ;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

        if (tilemapBounds.Contains(spawnPosition))
        {
            // obj �迭���� �����ϰ� ������Ʈ ����
            GameObject randomObject = obj[Random.Range(0, obj.Length)];
            int randomRotate = Random.Range(0,361);
            // ���õ� ������Ʈ�� ������ ��ġ�� ����
            GameObject spawnedObject = Instantiate(randomObject, spawnPosition, Quaternion.identity);
            spawnedObject.transform.eulerAngles = new Vector3(0, 0, randomRotate);
            // ���� Ÿ�ϸ��� �ڽ� ������Ʈ ����Ʈ�� �߰�
            tilemapObjects[currentTilemap].Add(spawnedObject);
        }
    }


    void DestroyPreviousObjects(Tilemap currentTilemap)
    {
        // ������ ������ ���� Ÿ�ϸ��� �ڽ� ������Ʈ�� ����
        foreach (GameObject obj in tilemapObjects[currentTilemap])
        {
            Destroy(obj);
        }

        // ����Ʈ ����
        tilemapObjects[currentTilemap].Clear();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = PlayerController.PlayerPos;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        DestroyPreviousObjects(tilemap);
        switch (transform.tag)
        {
            case "Ground":
                currentPos = playerPos;
                int dirX = prePos.x < currentPos.x ? 1 : -1;
                int dirY = prePos.y < currentPos.y ? 1 : -1;

                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * 57 * dirX);
                    prePos = currentPos;
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * 60 * dirY);
                    prePos = currentPos;
                }

                // ���� Ÿ�ϸ��� �̵��� ���� ������Ʈ ���� �� ���� ������Ʈ ����
                for (int e = 0; e < 100; ++e)
                {
                    SpawnRandomObject(tilemap);
                }
                break;
        }
    }
}
