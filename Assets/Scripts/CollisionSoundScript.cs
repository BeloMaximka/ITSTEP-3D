using UnityEngine;

public class CollisionSoundScript : MonoBehaviour
{
    [SerializeField]
    AudioSource wallHitSound;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallHitSound.pitch = Random.Range(0.5f, 1.2f);
            wallHitSound.volume = playerRb.linearVelocity.magnitude / 10;
            wallHitSound.Play();
        }
    }
}
