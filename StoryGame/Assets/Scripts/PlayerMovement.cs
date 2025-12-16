using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference move;

    private CharacterController controller;

    private Vector2 moveDirection;

    public float speed = 1.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Movement with player controller.
        moveDirection = move.action.ReadValue<Vector2>();
        Vector3 movement = transform.right * moveDirection.x + transform.forward * moveDirection.y;

        controller.Move(speed * Time.deltaTime * movement);
    }
}
