using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private GameObject content;

    [SerializeField]
    private Slider sensitivityXSlider;

    [SerializeField]
    private Slider sensitivityYSlider;

    [SerializeField]
    private Toggle sharedSensitivityToggle;

    [SerializeField]
    private Slider effectSoundsSlider;

    [SerializeField]
    private Slider musicSoundsSlider;

    [SerializeField]
    private Toggle muteSoundsToggle;

    void Start()
    {
        content = transform.Find("Content").gameObject;
        content.SetActive(false);

        OnSensitivitySeparateChanged(GameSettings.IsMouseSensitivityShared);
        OnCancel();
        SaveSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            content.SetActive(!content.activeInHierarchy);
        }
    }

    public void OnEffectsVolumeChanged(float value)
    {
        GameSettings.EffectsVolume = value;
    }

    public void OnMusicVolumeChanged(float value)
    {
        GameSettings.MusicVolume = value;
    }

    public void OnMuteSoundsChanged(bool value)
    {
        GameSettings.IsMuted = value;
    }

    public void OnSensitivityXChanged(float value)
    {
        GameSettings.MouseSensitivityX = value;
        if (GameSettings.IsMouseSensitivityShared)
        {
            sensitivityYSlider.value = value;
        }
    }

    public void OnSensitivityYChanged(float value)
    {
        GameSettings.MouseSensitivityY = value;
    }

    public void OnSensitivitySeparateChanged(bool value)
    {
        GameSettings.IsMouseSensitivityShared = value;
        sensitivityYSlider.enabled = !value;
        sensitivityYSlider.interactable = !value;
        if (GameSettings.IsMouseSensitivityShared)
        {
            sensitivityYSlider.value = sensitivityXSlider.value;
        }
    }

    public void OnCancel()
    {
        LoadSettings();

        effectSoundsSlider.value = GameSettings.EffectsVolume;
        musicSoundsSlider.value = GameSettings.MusicVolume;
        muteSoundsToggle.isOn = GameSettings.IsMuted;
        sensitivityXSlider.value = GameSettings.MouseSensitivityX;
        sensitivityYSlider.value = GameSettings.MouseSensitivityY;
        sharedSensitivityToggle.isOn = GameSettings.IsMouseSensitivityShared;
    }

    public void OnSave()
    {
        SaveSettings();
    }

    public void OnClose()
    {
        content.SetActive(false);
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat(SettingKey.EffectsVolume, GameSettings.EffectsVolume);
        PlayerPrefs.SetFloat(SettingKey.MusicVolume, GameSettings.MusicVolume);
        PlayerPrefs.SetInt(SettingKey.IsMuted, Convert.ToInt32(GameSettings.IsMuted));
        PlayerPrefs.SetFloat(SettingKey.MouseSensitivityX, GameSettings.MouseSensitivityX);
        PlayerPrefs.SetFloat(SettingKey.MouseSensitivityY, GameSettings.MouseSensitivityY);
        PlayerPrefs.SetInt(SettingKey.IsMouseSensitivityShared, Convert.ToInt32(GameSettings.IsMouseSensitivityShared));
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(SettingKey.EffectsVolume))
        {
            GameSettings.EffectsVolume = PlayerPrefs.GetFloat(SettingKey.EffectsVolume);
        }

        if (PlayerPrefs.HasKey(SettingKey.MusicVolume))
        {
            GameSettings.MusicVolume = PlayerPrefs.GetFloat(SettingKey.MusicVolume);
        }

        if (PlayerPrefs.HasKey(SettingKey.IsMuted))
        {
            GameSettings.IsMuted = PlayerPrefs.GetInt(SettingKey.IsMuted) == 1;
        }

        if (PlayerPrefs.HasKey(SettingKey.MouseSensitivityX))
        {
            GameSettings.MouseSensitivityX = PlayerPrefs.GetFloat(SettingKey.MouseSensitivityX);
        }

        if (PlayerPrefs.HasKey(SettingKey.MouseSensitivityY))
        {
            GameSettings.MouseSensitivityY = PlayerPrefs.GetFloat(SettingKey.MouseSensitivityY);
        }

        if (PlayerPrefs.HasKey(SettingKey.IsMouseSensitivityShared))
        {
            GameSettings.IsMouseSensitivityShared = PlayerPrefs.GetInt(SettingKey.IsMouseSensitivityShared) == 1;
        }
    }
}
