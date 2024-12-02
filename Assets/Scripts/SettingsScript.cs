using Assets.Scripts;
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
    void Start()
    {
        content = transform.Find("Content").gameObject;
        content.SetActive(false);

        OnSensitivitySeparateChanged(GameSettings.IsMouseSensitivityShared);
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
}
