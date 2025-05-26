using UnityEngine;

public class PlayerDiego : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    public Transform playerCamera;
    private float cameraPitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or ←/→
        float moveZ = Input.GetAxis("Vertical");   // W/S or ↑/↓

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * speed * Time.deltaTime;
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseX);
    }
}
