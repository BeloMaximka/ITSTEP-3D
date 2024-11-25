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
        float offset = maximumVertialOffset * Mathf.Sin(Time.frameCount / 100f);
        transform.position = new Vector3(initialPos.x, initialPos.y + offset, initialPos.z);
    }
}
