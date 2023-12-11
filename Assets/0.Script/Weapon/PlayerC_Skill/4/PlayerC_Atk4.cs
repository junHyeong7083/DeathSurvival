// PlayerC_Atk4 ��ũ��Ʈ
using System.Collections;
using UnityEngine;

public class PlayerC_Atk4 : MonoBehaviour
{
    [SerializeField]
    int currentSkillIndex;
    bool isOnes = false;
    bool isDetect = false;

    void Start()
    {
        StartCoroutine(Atk());
    }

    GameObject targetObj;

    float detectionRadius = 3;
    float lastDetectionTime = 0f;
    int check = 0;

    IEnumerator Atk()
    {
        while (true)
        {
                if (!WeaponDataManager.playerCFourbool)
                {
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerController.PlayerPos, detectionRadius);

                    // �߰�: ������Ʈ���� �ٸ� ��� ���͸� ã���� ����
                    if (targetObj == null)
                    {
                        foreach (Collider2D collider in colliders)
                        {
                            yield return null;
                            // ������ Ȯ��
                            if (collider.CompareTag("Monster"))
                            {
                                if (currentSkillIndex == check)
                                {
                                    lastDetectionTime = 0f;
                                    targetObj = collider.gameObject;
                                    isDetect = true;
                                WeaponDataManager.playerCFourbool = true;
                                    break; // ù ��° ���� Ž���ϰ� ���� ����
                                }
                                else
                                {
                                    check++;
                                }

                            }
                        }
                    }
                }
            if (WeaponDataManager.playerCFourbool)
            {
                    this.gameObject.SetActive(true);
                    float startTime = Time.time;
                    while (Time.time - startTime < WeaponDataManager.playerCFourAtkTime)
                    {
                        // ����: �� ������Ʈ�� �ڽ��� ��� ���͸� ���󰡵��� ����
                        if (targetObj != null && targetObj.activeSelf)
                            this.transform.position = targetObj.transform.position;

                        yield return null;
                    }
                    this.gameObject.SetActive(false);
                    startTime = Time.time;
                    while (Time.time - startTime < WeaponDataManager.playerCFourCoolTime)
                    {
                        yield return null;
                    }

                    isDetect = false;
                    check = 0;
                    targetObj = null;
                WeaponDataManager.playerCFourbool = false;

                }


            }

            
        }

    void Update()
    {
        // ��Ÿ ������Ʈ ����...
    }
}
