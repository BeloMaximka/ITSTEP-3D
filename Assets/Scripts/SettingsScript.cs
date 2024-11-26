using Assets.Scripts;
using System;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    private GameObject content;
    void Start()
    {
        content = transform.Find("Content").gameObject;
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
}
