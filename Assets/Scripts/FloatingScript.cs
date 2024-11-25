using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    [SerializeField]
    float maximumVertialOffset = 0.1f;

    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        float offset = maximumVertialOffset * Mathf.Sin(Time.time * 1.5f);
        transform.position = new Vector3(initialPos.x, initialPos.y + offset, initialPos.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.LerpUnclamped(0f, 90f, Time.time), transform.eulerAngles.z);
    }
}
