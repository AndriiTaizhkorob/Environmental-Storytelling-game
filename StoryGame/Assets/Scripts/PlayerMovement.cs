using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float gMult = 1.0f;

    private CharacterController controller;
    private Vector2 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Movement with player controller.
        moveDirection = move.action.ReadValue<Vector2>();
        Vector3 movement;

        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - (GetComponent<CharacterController>().height / 2) - 0.01f, transform.position.z), Color.red, 1f);

        if (!Physics.Raycast(transform.position, Vector3.down, GetComponent<CharacterController>().height / 2 + 0.01f))
        {
            movement = transform.right * moveDirection.x + transform.forward * moveDirection.y + transform.up * Gravitation();
        }
        else
        {
            movement = transform.right * moveDirection.x + transform.forward * moveDirection.y;
        }

        controller.Move(speed * Time.deltaTime * movement);
    }

    private float Gravitation()
    {
        return 9.81f * gMult * Time.deltaTime;
    }
}
