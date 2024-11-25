using Assets.Scripts;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameState.FlashCharge += 0.75f + Random.value * 0.25f;
            if (GameState.FlashCharge > 2)
            {
                GameState.FlashCharge = 2;
            }
            Destroy(gameObject);
        }
    }
}
