using UnityEngine;
using UnityEngine.InputSystem;

public class SkyManager : MonoBehaviour
{
    // Sky and Night Materials
    [SerializeField] Material daySky;
    [SerializeField] Material nightSky;

    bool isDay = true;

    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Sky();
        }
    }

    void Sky()
    {
        isDay = !isDay;
        RenderSettings.skybox = isDay ? daySky : nightSky;

        DynamicGI.UpdateEnvironment();
    }
}