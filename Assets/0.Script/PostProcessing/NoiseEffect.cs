using UnityEngine;

[RequireComponent(typeof(Camera))]
public class NoiseEffect : MonoBehaviour
{
    public Material noiseMaterial; // ������ ȿ���� ������ ����(Material)

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // ��ó�� ����Ʈ�� �����ϱ� ���� ������ ȿ���� ����ϴ� ������ �Բ� �̹����� ó���մϴ�.
        Graphics.Blit(source, destination, noiseMaterial);
    }
}
