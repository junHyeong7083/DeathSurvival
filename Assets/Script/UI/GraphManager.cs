using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    public RectTransform[] PlayerADamageBars; // 그래프 바를 배열로 저장
    public Text[] PlayerADamageTxt;
    float[] playerADamage = new float[3]; // 플레이어 데미지 배열
    public float maxValue;
    void Start()
    {
        // 데미지 그래프 업데이트
        UpdateDamageGraph();
    }

    private void Update()
    {

        if (Pixelate.showDiePanel)
        {
            UpdateDamageGraph();
        }
    }

    void UpdateDamageGraph()
    {
        // 플레이어 데미지 값을 playerADamage 배열에 직접 대입
        playerADamage[0] = MonsterController.PlayerAOneDamage;
        playerADamage[1] = MonsterController.PlayerATwoDamage;
        playerADamage[2] = MonsterController.PlayerAThreeDamage;

        PlayerADamageTxt[0].text = MonsterController.PlayerAOneDamage.ToString();
        PlayerADamageTxt[1].text = MonsterController.PlayerATwoDamage.ToString();
        PlayerADamageTxt[2].text = MonsterController.PlayerAThreeDamage.ToString();

        // 최대 데미지 값을 찾음
        float maxDamage = Mathf.Max(playerADamage);

        for (int i = 0; i < PlayerADamageBars.Length; i++)
        {
            // 그래프 바 업데이트
            float normalizedDamage = playerADamage[i] / maxDamage;
            PlayerADamageBars[i].sizeDelta = new Vector2(normalizedDamage * maxValue, PlayerADamageBars[i].sizeDelta.y); // 700은 그래프 최대 폭

            float barWidth = normalizedDamage * maxValue; // 700은 그래프 최대 폭
            PlayerADamageBars[i].sizeDelta = new Vector2(barWidth, PlayerADamageBars[i].sizeDelta.y);
            // 그래프의 오른쪽 끝 위치를 계산
            float rightEdgeX = PlayerADamageBars[i].anchoredPosition.x + barWidth;

            // Text 위치 설정
            float textX = rightEdgeX;
            float textY = PlayerADamageBars[i].anchoredPosition.y + 20f;
            PlayerADamageTxt[i].rectTransform.anchoredPosition = new Vector2(textX, textY);
        }
    }
}
