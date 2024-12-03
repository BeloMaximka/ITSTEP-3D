using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private string keyName = string.Empty;

    [SerializeField]
    GameObject keyObject;

    [SerializeField]
    AudioSource keyPickupSound;

    [SerializeField]
    AudioSource stalePickupSound;

    private void Start()
    {
        GameSettings.EffectsVolumeChanged += UpdateVolume;
        UpdateVolume(GameSettings.EffectsVolume);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameState.ClocksPicked > 0)
            {
                GameState.ClocksPicked--;
                GameState.SetKeyStale(keyName, false);
            }
            GameState.OnKeyPickup(keyName);

            KeyInfo info = GameState.CollectedKeys[keyName];
            if (info.IsStale)
            {
                stalePickupSound.Play();
            }
            else
            {
                keyPickupSound.Play();
            }
            StartCoroutine(DestroyKey());
        }
    }

    private void UpdateVolume(float volume)
    {
        keyPickupSound.volume = volume;
        stalePickupSound.volume = volume;
    }

    private void OnDestroy()
    {
        GameSettings.EffectsVolumeChanged -= UpdateVolume;
    }

    private IEnumerator DestroyKey()
    {
        Destroy(keyObject);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
