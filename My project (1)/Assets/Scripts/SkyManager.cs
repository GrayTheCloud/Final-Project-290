using UnityEngine;
using UnityEngine.InputSystem;

public class SkyManager : MonoBehaviour
{
    // Sky and Night Materials
    [SerializeField] Material daySky;
    [SerializeField] Material nightSky;

    // Start with day
    bool isDay = true;

    // TEST
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Sky();
        }
    }

    // Changes to Day if night or night if day
    void Sky()
    {
        isDay = !isDay;
        RenderSettings.skybox = isDay ? daySky : nightSky;

        DynamicGI.UpdateEnvironment();
    }
}