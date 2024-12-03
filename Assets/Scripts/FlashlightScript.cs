using Assets.Scripts;
using Assets.Scripts.Enums;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Rigidbody playerRb;
    private Light spotLight;

    private float chargeTimeout = 10.0f;

    void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        spotLight = GetComponent<Light>();
        GameState.FlashCharge = 1.0f;

        ChangeChargeTimeout(GameSettings.Difficulty);
        GameSettings.DifficultyChanged += ChangeChargeTimeout;
    }
    void Update()
    {
        transform.position = playerRb.position;
        if (GameState.FlashCharge > 0)
        {
            GameState.FlashCharge -= Time.deltaTime / chargeTimeout;
            if (GameState.FlashCharge < 0)
            {
                GameState.FlashCharge = 0;
            }
            spotLight.intensity = GameState.FlashCharge * 2;
        }
        if (GameState.IsFpv)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        else if (playerRb.linearVelocity.magnitude > 0.01f)
        {
            transform.forward = playerRb.linearVelocity.normalized;
        }
    }

    private void ChangeChargeTimeout(DifficultyType difficulty)
    {
        chargeTimeout = difficulty switch
        {
            DifficultyType.Easy => 20f,
            DifficultyType.Medium => 10f,
            DifficultyType.Hard => 5f,
            _ => 10f,
        };
    }

    private void OnDestroy()
    {
        GameSettings.DifficultyChanged -= ChangeChargeTimeout;
    }

}
