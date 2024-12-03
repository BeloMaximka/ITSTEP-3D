using Assets.Scripts;
using Assets.Scripts.Enums;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    private float difficultyMultiplier = 1f;


    private void Start()
    {
        GameSettings.DifficultyChanged += ChangeDifficultyMultiplier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameState.FlashCharge += (0.75f + Random.value * 0.25f) * difficultyMultiplier;
            if (GameState.FlashCharge > 2)
            {
                GameState.FlashCharge = 2;
            }
            Destroy(gameObject);
        }
    }

    private void ChangeDifficultyMultiplier(DifficultyType difficulty)
    {
        difficultyMultiplier = difficulty switch
        {
            DifficultyType.Easy => 2f,
            DifficultyType.Medium => 1f,
            DifficultyType.Hard => 0.5f,
            _ => 1f,
        };
    }

    private void OnDestroy()
    {
        GameSettings.DifficultyChanged -= ChangeDifficultyMultiplier;
    }
}
