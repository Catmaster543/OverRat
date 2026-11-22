using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    private Material previousMaterial;
    private Light sun;

    private void Start()
    {
        previousMaterial = RenderSettings.skybox;
        sun = RenderSettings.sun;
    }

    public void DarkenTheSky()
    {
        Debug.Log("Darkening the sky");
        Material darkMat = new Material(RenderSettings.skybox);
        darkMat.color = Color.red;
        RenderSettings.skybox = darkMat;
        RenderSettings.sun = null;
    }

    public void ResetSky()
    {
        Debug.Log("Reseting the sky");
        RenderSettings.skybox = previousMaterial;
        RenderSettings.sun = sun;
    }
}
