using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;

    private List<Light> nightLights;
    private List<Light> dayLights;
    
    private bool isNight;
    void Start()
    {
        nightLights = new List<Light>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("NightLight"))
        {
            nightLights.Add(g.GetComponent<Light>());
        }
        dayLights = new List<Light>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("DayLight"))
        {
            dayLights.Add(g.GetComponent<Light>());
        }
        SwitchDayNightCycle();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchDayNightCycle();
        }
    }

    private void SwitchDayNightCycle()
    {
        isNight = !isNight;
        RenderSettings.skybox = isNight ? nightSkybox : daySkybox;
        foreach (Light nightLight in nightLights)
        {
            nightLight.enabled = isNight;
        }
        foreach (Light dayLight in dayLights)
        {
            dayLight.enabled = !isNight;
        }
    }
}
