using UnityEngine;

public class PROJECT_SETTINGS : MonoBehaviour
{
    [SerializeField] private const int FPSLIMIT = 60;

    public static void Initialize()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPSLIMIT;
    }
}
