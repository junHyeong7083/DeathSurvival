using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public int width = 10;  // �ν����Ϳ��� ������ ���� ũ��
    public int height = 10; // �ν����Ϳ��� ������ ���� ũ��

    [Header("Index[0] : Ground / Index[1~] : Object ")]
    public Tilemap[] layerIndex;
    [Header("�ٴ� Ÿ��")]
    public TileBase groundTile;   // �ν����Ϳ��� ������ Ÿ��
    [Header("������Ʈ Ÿ��")]
    public TileBase[] objectTile;


    [Header("������Ʈ ���� Ȯ��")]
    [SerializeField]
    [Range(0f,100f)]
    float spawnPercentage;

    [Header("������Ʈ���� �ּ� �Ÿ�")]
    [SerializeField]
    float spawndistance;
    void Start()
    {
        GenerateRandomObject();
    }

  
    void GenerateRandomObject()
    {
        // �ʱ�ȭ
        int[][] checkPos = new int[width][];
        for (int i = 0; i < width; i++)
        {
            checkPos[i] = new int[height];
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // �̹� ���� ��ġ��� ���� ��ġ�� �Ѿ
                if (checkPos[x][y] == 1)
                    continue;

                // ������Ʈ ����Ȯ��
                if (Random.Range(0f, 100f) < spawnPercentage)
                {
                    // 3*3 ���� Ȯ��
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

                        // �ش� ��ġ �� 3*3 ������ ���� ������ ǥ��
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
