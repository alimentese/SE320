using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settingsmenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

        }

        resolutionDropdown.AddOptions(options);
    }
    public void SetQuality(int qualityIndex) {
            QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreeen)
    {
        Screen.fullScreen = isFullscreeen;
    }

    public void SetResolution()
    {
        Screen.SetResolution(640, 480, true, 60);
    }
}
