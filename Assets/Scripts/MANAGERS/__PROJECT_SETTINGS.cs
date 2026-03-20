using UnityEngine;

public static class __PROJECT_SETTINGS
{
    private const int FPSLIMIT = 60;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPSLIMIT;
    }
}
