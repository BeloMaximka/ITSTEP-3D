using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 5.0f;

    private Rigidbody rb;
    private InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 forceValue = forceFactor * new Vector3(moveValue.x, 0f, moveValue.y);
        rb.AddForce(forceValue);
    }
}
