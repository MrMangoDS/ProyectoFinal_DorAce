using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;
    private bool jumpPressed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);

        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpPressed = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // INPUT SYSTEM CALLBACKS
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpPressed = true;
    }
}