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

    [SerializeField] Saves saves;

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
        skyboxDropdown.value = saves.skyboxIndex;
        skyboxDropdown.RefreshShownValue();
        graphicsDropdown.value = saves.qualityIndex;
        graphicsDropdown.RefreshShownValue();
        volumeSlider.value = saves.volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        saves.resolutionIndex = resolutionIndex;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        saves.volume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        saves.qualityIndex = qualityIndex;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        saves.isFullscreen = isFullscreen;
    }

    public void ChangeSkybox(int skyboxIndex)
    {
        saves.skyboxIndex = skyboxIndex;
        RenderSettings.skybox = saves.skyboxes[skyboxIndex];
    }

    public void ResetSettings()
    {
        saves.skyboxIndex = 1;
        saves.volume = 0;
        saves.qualityIndex = 2;
        saves.isFullscreen = false;
        saves.resolutionIndex = 16;
    }

    public void ResetScore()
    {
        saves.HighScore = 0;
    }
}
