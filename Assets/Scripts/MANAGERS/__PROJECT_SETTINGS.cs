using UnityEngine;

public class __PROJECT_SETTINGS : MonoBehaviour
{
    public int FPSLIMIT = 60;

    void Awake()
    {

        Resolution currentResolution = Screen.currentResolution;


        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPSLIMIT;
    }

}
