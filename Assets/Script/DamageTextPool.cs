using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextPool : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public int poolSize = 10;
    private List<GameObject> damageTextPool = new List<GameObject>();

    float fontSize = 0;
    void Start()
    {
        fontSize = 2f;
        InitializeDamageTextPool();
    }
    void InitializeDamageTextPool()
    {
        GameObject parentObject = new GameObject("DamageTextPools");
        Transform parentObjectTrans = parentObject.transform;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject damageText = Instantiate(damageTextPrefab, parentObjectTrans);
            damageText.SetActive(false);
            damageTextPool.Add(damageText);
        }
    }

    public void ShowDamageText(Vector3 position, float damage, int check)
    {
        for (int i = 0; i < damageTextPool.Count; i++)
        {
            if (!damageTextPool[i].activeSelf)
            {
                damageTextPool[i].transform.position = position;
                TextMeshPro textMesh = damageTextPool[i].GetComponent<TextMeshPro>();
                switch (check)
                {
                    case -1:
                        //textMesh.color = new Color32(253, 255, 220, 255);
                        textMesh.fontSize = fontSize - 0.3f;
                        break;

                    case 0:
                        break;

                    case 1:
                        textMesh.fontStyle = FontStyles.Bold;
                        textMesh.fontSize = fontSize + 0.3f;
                        // textMesh.color = new Color32(255, 218, 218, 255);
                        break;
                }

                textMesh.text = damage.ToString();
                textMesh.alpha = 1.0f; // 초기 알파 값을 1로 설정

                damageTextPool[i].SetActive(true);
                StartCoroutine(FadeOutDamageText(damageTextPool[i]));
                break;
            }
        }
    }

    IEnumerator FadeOutDamageText(GameObject damageText)
    {
        TextMeshPro textMesh = damageText.GetComponent<TextMeshPro>();
        float duration = 1.0f; // 페이드 아웃 지속 시간
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / duration);
            textMesh.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        textMesh.fontSize = 2f;
        textMesh.fontStyle = FontStyles.Normal;
        damageText.SetActive(false);
    }
}
