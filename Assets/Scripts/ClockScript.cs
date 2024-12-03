using Assets.Scripts;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameState.ClocksPicked++;
            Destroy(gameObject);
        }
    }
}
