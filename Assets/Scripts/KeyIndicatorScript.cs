using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class KeyIndicatorScript : MonoBehaviour
{
    [SerializeField]
    private float durationSeconds = 10f;

    [SerializeField]
    private string keyName = string.Empty;

    private float timeStamp = -1f;
    private Image indicator;

    void Start()
    {
        indicator = gameObject.GetComponentInChildren<Image>();
    }

    void Update()
    {
        if (timeStamp >= 0)
        {
            if (Time.time > timeStamp + durationSeconds)
            {
                GameState.SetKeyStale(keyName);
                Destroy(gameObject);
            }
            indicator.fillAmount = 1 - ((Time.time - timeStamp) / durationSeconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timeStamp < 0 && other.gameObject.CompareTag("Player"))
        {
            timeStamp = Time.time;
        }
    }
}
