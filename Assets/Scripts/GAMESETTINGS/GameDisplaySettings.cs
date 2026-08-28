using UnityEngine;

public class GameDisplaySettings : MonoBehaviour
{
    private const int TargetWidth = 1920;
    private const int TargetHeight = 1080;

    private void Awake()
    {
        Screen.SetResolution(TargetWidth, TargetHeight, FullScreenMode.FullScreenWindow);
        Cursor.lockState = CursorLockMode.Confined;
    }
}