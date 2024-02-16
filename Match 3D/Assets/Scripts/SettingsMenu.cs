using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public Dropdown skyboxDropdown;

    public Dropdown graphicsDropdown;

    public Slider volumeSlider;

    Resolution[] resolutions;

    [SerializeField] SavedSettings savedSettings;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        skyboxDropdown.value = savedSettings.skyboxIndex;
        skyboxDropdown.RefreshShownValue();
        graphicsDropdown.value = savedSettings.qualityIndex;
        graphicsDropdown.RefreshShownValue();
        volumeSlider.value = savedSettings.volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        savedSettings.resolutionIndex = resolutionIndex;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        savedSettings.volume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        savedSettings.qualityIndex = qualityIndex;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        savedSettings.isFullscreen = isFullscreen;
    }

    public void ChangeSkybox(int skyboxIndex)
    {
        savedSettings.skyboxIndex = skyboxIndex;
        RenderSettings.skybox = savedSettings.skyboxes[skyboxIndex];
    }

    public void ResetSettings()
    {
        savedSettings.skyboxIndex = 1;
        savedSettings.volume = 0;
        savedSettings.qualityIndex = 2;
        savedSettings.isFullscreen = false;
        savedSettings.resolutionIndex = 16;
    }
}
