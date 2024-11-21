using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform cameraPosition;

    private Vector3 fixedCameraPosition;
    private Vector3 attachedCameraAnchor;
    private bool isCameraAttached = true;


    void Start()
    {
        fixedCameraPosition = transform.position;
        attachedCameraAnchor = cameraPosition.position - player.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCameraAttached = !isCameraAttached;
        }
        transform.position = isCameraAttached ? attachedCameraAnchor + player.transform.position : fixedCameraPosition;
    }
}
