using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BackgroundScript : MonoBehaviour {
    public Material backgroundMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (backgroundMaterial != null) {
            Graphics.Blit(src, dest, backgroundMaterial);
        } else {
            Graphics.Blit(src, dest);
        }
    }
}
