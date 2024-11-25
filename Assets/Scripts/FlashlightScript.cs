using Assets.Scripts;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Rigidbody playerRb;
    private Light spotLight;

    private readonly float chargeTimeout = 10.0f;

    void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        spotLight = GetComponent<Light>();
        GameState.FlashCharge = 1.0f;
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
}
