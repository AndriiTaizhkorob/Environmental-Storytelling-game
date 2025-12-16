using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    private Camera mCamera;

    public InputActionReference look;

    public float mouseSensitivity = 0.0001f;

    public Transform playerBody;

    float xRotation = 0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform;
        mCamera = Camera.main;
    }

    void FixedUpdate()
    {
        float horizontal = look.action.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        float vertical = look.action.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;

        xRotation -= vertical;
        xRotation = Mathf.Clamp(xRotation, -90f, 70f);
        

        //transform.localRotation = Quaternion.Euler(0f, horizontal, 0f);
        playerBody.transform.Rotate(Vector3.up * horizontal);

        mCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
