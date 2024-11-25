using Assets.Scripts;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private string keyName = string.Empty;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameState.SetKeyPicked(keyName);
            Destroy(gameObject);
        }
    }
}
