using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    private bool isFullscreen = true;

    public void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;

        if (!isFullscreen)
        {
            Screen.SetResolution(Screen.width, Screen.height, false);
        }
        else
        {
            Screen.SetResolution(1366, 768, true); 
        }
    }
}
