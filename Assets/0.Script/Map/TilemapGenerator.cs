using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public int width = 10;  // 인스펙터에서 설정할 가로 크기
    public int height = 10; // 인스펙터에서 설정할 세로 크기

    [Header("Index[0] : Ground / Index[1~] : Object ")]
    public Tilemap[] layerIndex;
    [Header("바닥 타일")]
    public TileBase groundTile;   // 인스펙터에서 설정할 타일
    [Header("오브젝트 타일")]
    public TileBase[] objectTile;


    [Header("오브젝트 생성 확률")]
    [SerializeField]
    [Range(0f,100f)]
    float spawnPercentage;

    [Header("오브젝트간의 최소 거리")]
    [SerializeField]
    float spawndistance;
    void Start()
    {
        GenerateRandomObject();
    }

  
    void GenerateRandomObject()
    {
        // 초기화
        int[][] checkPos = new int[width][];
        for (int i = 0; i < width; i++)
        {
            checkPos[i] = new int[height];
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // 이미 사용된 위치라면 다음 위치로 넘어감
                if (checkPos[x][y] == 1)
                    continue;

                // 오브젝트 등장확률
                if (Random.Range(0f, 100f) < spawnPercentage)
                {
                    // 3*3 범위 확인
                    bool isValidPosition = true;
                    for (int i = x; i < x + spawndistance; i++)
                    {
                        for (int j = y; j < y + spawndistance; j++)
                        {
                            if (i >= 0 && i < width && j >= 0 && j < height)
                            {
                                if (checkPos[i][j] == 1)
                                {
                                    isValidPosition = false;
                                    break;
                                }
                            }
                        }
                        if (!isValidPosition)
                            break;
                    }

                    if (isValidPosition)
                    {
                        int len = objectTile.Length;
                        int pickIndex = Random.Range(0, len);

                        layerIndex[1].SetTile(new Vector3Int(x, y, 0), objectTile[pickIndex]);

                        // 해당 위치 및 3*3 범위를 사용된 것으로 표시
                        for (int i = x; i < x + spawndistance; i++)
                        {
                            for (int j = y; j < y + spawndistance; j++)
                            {
                                if (i >= 0 && i < width && j >= 0 && j < height)
                                {
                                    checkPos[i][j] = 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
