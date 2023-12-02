using UnityEngine;

[RequireComponent(typeof(Camera))]
public class NoiseEffect : MonoBehaviour
{
    public Material noiseMaterial; // 노이즈 효과를 적용할 재질(Material)

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // 후처리 이펙트를 적용하기 위해 노이즈 효과를 사용하는 재질과 함께 이미지를 처리합니다.
        Graphics.Blit(source, destination, noiseMaterial);
    }
}
