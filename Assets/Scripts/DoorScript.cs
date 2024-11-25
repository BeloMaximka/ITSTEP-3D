using Assets.Scripts;
using System;
using System.Collections;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private string keyName = string.Empty;

    [SerializeField]
    AudioSource lockedSound;

    [SerializeField]
    AudioSource slowOpenSound;

    [SerializeField]
    AudioSource quickOpenSound;

    [SerializeField]
    GameObject door;

    private bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened)
        {
            return;
        }

        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (GameState.CollectedKeys.TryGetValue(keyName, out KeyInfo info) && info.IsPicked)
        {
            isOpened = true;
            if (info.IsStale)
            {
                StartCoroutine(DestroyDoor(1f));
                slowOpenSound.Play();
            }
            else
            {
                StartCoroutine(DestroyDoor(0.4f));
                quickOpenSound.Play();
            }
        }
        else
        {
            lockedSound.Play();
        }
    }

    private IEnumerator DestroyDoor(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(door);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
