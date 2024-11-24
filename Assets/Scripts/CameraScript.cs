using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform fpvTransform;
    private InputAction lookAction;

    private Vector3 c;
    private float mX, mY;
    private readonly float sensitivityH = 10.0f;
    private readonly float sensitivityV = 5.0f;
    private readonly float sensitivityW = 0.1f;
    private readonly float fpvRange = 0.6f;

    void Start()
    {
        c = transform.position - player.transform.position;
        mX = transform.eulerAngles.y;
        mY = transform.eulerAngles.x;
        lookAction = InputSystem.actions.FindAction("Look");
        transform.SetPositionAndRotation(fpvTransform.position, fpvTransform.rotation);
    }

    private void Update()
    {
        if (GameState.IsFpv)
        {
            Vector2 mouseWheel = Input.mouseScrollDelta;
            if (mouseWheel.y != 0)
            {
                if (c.magnitude > fpvRange)
                {
                    c *= (1 - mouseWheel.y * sensitivityW);
                    if (c.magnitude < fpvRange)
                    {
                        c *= 0.01f;
                    }
                }
                else if (mouseWheel.y < 0)
                {
                    c /= c.magnitude * fpvRange * 1.01f;
                }
            }
            Vector2 lookValue = lookAction.ReadValue<Vector2>() * Time.deltaTime;
            mX += lookValue.x * sensitivityH;

            float verticalAngleRestriction = GradualSqrt(c.magnitude, 0.4f);
            mY += -lookValue.y * sensitivityV;
            mY = Mathf.Clamp(mY, verticalAngleRestriction, 75);

            transform.eulerAngles = new Vector3(mY, mX, 0);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameState.IsFpv = !GameState.IsFpv;
            Cursor.lockState = GameState.IsFpv ? CursorLockMode.Locked : CursorLockMode.None;
            if (!GameState.IsFpv)
            {
                transform.SetPositionAndRotation(fpvTransform.position, fpvTransform.rotation);
            }
        }
    }

    void LateUpdate()
    {
        if (GameState.IsFpv)
        {
            transform.position = Quaternion.Euler(0, mX, 0) * c +
                player.transform.position;
        }
    }

    // Graph: https://www.desmos.com/calculator/vrjvwlddfc
    private static float GradualSqrt(float x, float k)
    {
        return 75f * (1f - Mathf.Exp(-k * Mathf.Sqrt(x)));
    }
}
