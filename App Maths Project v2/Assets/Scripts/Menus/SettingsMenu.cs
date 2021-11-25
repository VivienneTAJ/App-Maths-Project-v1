using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour //Original script by: B00394780
                                          //Refined script by: B00381904
{
    Resolution[] resolutions;

    public GameObject fullScreenToggle;
    public TMP_Dropdown resolutionDropdown, graphicsDropDown;
    public Slider BGMVolumeSlider, SFXVolumeSlider;
    public AudioMixer audioMixer;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        DisplayCurrentSettings();
    }
    public void GetCurrentSettings()
    {
        SetBGMVolume(PlayerPrefs.GetFloat("BGMVolume"));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
        SetQuality(PlayerPrefs.GetInt("QualityIndex"));
        if (PlayerPrefs.GetInt("IsFullScreen") == 0)
        {
            SetFullScreen(true);
        }
        else if (PlayerPrefs.GetInt("IsFullScreen") == 1)
        {
            SetFullScreen(false);
        }
        //SetResolution(PlayerPrefs.GetInt("ResolutionIndex"));
    }
    public void DisplayCurrentSettings()
    {
        if (PlayerPrefs.GetInt("IsFullScreen") == 0)
        {
            fullScreenToggle.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("IsFullScreen") == 1)
        {
            fullScreenToggle.GetComponent<Toggle>().isOn = false;
        }
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
        graphicsDropDown.value = PlayerPrefs.GetInt("QualityIndex");
        BGMVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    //public void SetMasterVolume(float volume)
    //{
    //    PlayerPrefs.SetFloat("MasterVolume", volume);
    //    audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
    //}
    public void SetBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("BGMVolume", volume);
        audioMixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
    }
    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }
    public void SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
    }
    public void SetFullScreen(bool isFullScreen)
    {
        if (isFullScreen)
        {
            PlayerPrefs.SetInt("IsFullScreen", 0);
        }
        else
        {
            PlayerPrefs.SetInt("IsFullScreen", 1);
        }

        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        Resolution resolution = resolutions[PlayerPrefs.GetInt("ResolutionIndex")];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
