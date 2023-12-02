using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorInverter : MonoBehaviour
{
    public bool invertColors = false; // true�� ��� ���� ����

    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGradingLayer;

    void Start()
    {
        // ī�޶� Post Process Volume �߰�
        postProcessVolume = gameObject.AddComponent<PostProcessVolume>();

        // Post Process Profile ����
        PostProcessProfile postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();

        // Post Process Layer ����
        colorGradingLayer = postProcessProfile.AddSettings<ColorGrading>();

        // Post Process Volume�� Profile �Ҵ�
        postProcessVolume.profile = postProcessProfile;
    }

    void Update()
    {
        // bool ���� ���� ���� ���� ����
        colorGradingLayer.enabled.value = invertColors;
    }
}
