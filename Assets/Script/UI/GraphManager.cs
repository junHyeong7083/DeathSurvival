using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    public RectTransform[] PlayerADamageBars; // �׷��� �ٸ� �迭�� ����
    public Text[] PlayerADamageTxt;
    float[] playerADamage = new float[3]; // �÷��̾� ������ �迭
    public float maxValue;
    void Start()
    {
        // ������ �׷��� ������Ʈ
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
        // �÷��̾� ������ ���� playerADamage �迭�� ���� ����
        playerADamage[0] = MonsterController.PlayerAOneDamage;
        playerADamage[1] = MonsterController.PlayerATwoDamage;
        playerADamage[2] = MonsterController.PlayerAThreeDamage;

        PlayerADamageTxt[0].text = MonsterController.PlayerAOneDamage.ToString();
        PlayerADamageTxt[1].text = MonsterController.PlayerATwoDamage.ToString();
        PlayerADamageTxt[2].text = MonsterController.PlayerAThreeDamage.ToString();

        // �ִ� ������ ���� ã��
        float maxDamage = Mathf.Max(playerADamage);

        for (int i = 0; i < PlayerADamageBars.Length; i++)
        {
            // �׷��� �� ������Ʈ
            float normalizedDamage = playerADamage[i] / maxDamage;
            PlayerADamageBars[i].sizeDelta = new Vector2(normalizedDamage * maxValue, PlayerADamageBars[i].sizeDelta.y); // 700�� �׷��� �ִ� ��

            float barWidth = normalizedDamage * maxValue; // 700�� �׷��� �ִ� ��
            PlayerADamageBars[i].sizeDelta = new Vector2(barWidth, PlayerADamageBars[i].sizeDelta.y);
            // �׷����� ������ �� ��ġ�� ���
            float rightEdgeX = PlayerADamageBars[i].anchoredPosition.x + barWidth;

            // Text ��ġ ����
            float textX = rightEdgeX;
            float textY = PlayerADamageBars[i].anchoredPosition.y + 20f;
            PlayerADamageTxt[i].rectTransform.anchoredPosition = new Vector2(textX, textY);
        }
    }
}
