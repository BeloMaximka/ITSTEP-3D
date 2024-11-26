using Assets.Scripts;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour
{
    [SerializeField]
    AudioSource wallHitSound;


    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        GameSettings.EffectsVolumeChanged += UpdateVolume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallHitSound.pitch = Random.Range(0.5f, 1.2f);
            wallHitSound.volume = GameSettings.EffectsVolume * (playerRb.linearVelocity.magnitude / 8f);
            wallHitSound.Play();
        }
    }

    private void UpdateVolume(float volume)
    {
        wallHitSound.volume = volume * playerRb.linearVelocity.magnitude / 10;
    }

    private void OnDestroy()
    {
        GameSettings.EffectsVolumeChanged -= UpdateVolume;
    }
}
