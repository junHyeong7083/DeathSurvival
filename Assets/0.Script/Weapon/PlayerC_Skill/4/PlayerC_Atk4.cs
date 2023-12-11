// PlayerC_Atk4 스크립트
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

                    // 추가: 오브젝트마다 다른 대상 몬스터를 찾도록 수정
                    if (targetObj == null)
                    {
                        foreach (Collider2D collider in colliders)
                        {
                            yield return null;
                            // 적인지 확인
                            if (collider.CompareTag("Monster"))
                            {
                                if (currentSkillIndex == check)
                                {
                                    lastDetectionTime = 0f;
                                    targetObj = collider.gameObject;
                                    isDetect = true;
                                WeaponDataManager.playerCFourbool = true;
                                    break; // 첫 번째 적만 탐지하고 루프 종료
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
                        // 수정: 각 오브젝트가 자신의 대상 몬스터를 따라가도록 변경
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
        // 기타 업데이트 로직...
    }
}
