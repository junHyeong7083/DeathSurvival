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

        // 각 타일맵에 대한 자식 오브젝트 리스트 초기화
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
        // 타일맵 영역 내에 스폰 위치가 있는지 확인
        Vector2 tilemapSize = GetTilemapSize(compositeCollider2D);
        Bounds tilemapBounds = new Bounds(transform.position, new Vector3(tilemapSize.x-10, tilemapSize.y-10 , 0f));

        // 원형 영역 내에서 랜덤한 위치 선택
        Vector2 randomOffset = Random.insideUnitCircle * spawndistance ;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

        if (tilemapBounds.Contains(spawnPosition))
        {
            // obj 배열에서 랜덤하게 오브젝트 선택
            GameObject randomObject = obj[Random.Range(0, obj.Length)];
            int randomRotate = Random.Range(0,361);
            // 선택된 오브젝트를 랜덤한 위치에 스폰
            GameObject spawnedObject = Instantiate(randomObject, spawnPosition, Quaternion.identity);
            spawnedObject.transform.eulerAngles = new Vector3(0, 0, randomRotate);
            // 현재 타일맵의 자식 오브젝트 리스트에 추가
            tilemapObjects[currentTilemap].Add(spawnedObject);
        }
    }


    void DestroyPreviousObjects(Tilemap currentTilemap)
    {
        // 이전에 생성된 현재 타일맵의 자식 오브젝트들 제거
        foreach (GameObject obj in tilemapObjects[currentTilemap])
        {
            Destroy(obj);
        }

        // 리스트 비우기
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

                // 현재 타일맵의 이동에 따라 오브젝트 스폰 및 이전 오브젝트 삭제
                for (int e = 0; e < 100; ++e)
                {
                    SpawnRandomObject(tilemap);
                }
                break;
        }
    }
}
