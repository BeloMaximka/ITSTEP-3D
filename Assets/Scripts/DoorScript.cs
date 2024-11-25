using Assets.Scripts;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private string keyName = string.Empty;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameState.CollectedKeys.TryGetValue(keyName, out KeyInfo info) && info.IsPicked)
        {
            Destroy(gameObject);
        }
    }
}
