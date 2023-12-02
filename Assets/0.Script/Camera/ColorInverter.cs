using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorInverter : MonoBehaviour
{
    public bool invertColors = false; // true일 경우 색상 반전

    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGradingLayer;

    void Start()
    {
        // 카메라에 Post Process Volume 추가
        postProcessVolume = gameObject.AddComponent<PostProcessVolume>();

        // Post Process Profile 생성
        PostProcessProfile postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();

        // Post Process Layer 설정
        colorGradingLayer = postProcessProfile.AddSettings<ColorGrading>();

        // Post Process Volume에 Profile 할당
        postProcessVolume.profile = postProcessProfile;
    }

    void Update()
    {
        // bool 값에 따라 색상 반전 설정
        colorGradingLayer.enabled.value = invertColors;
    }
}
