using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Makes the player rise while the jump key is held.
 */
public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;

    // Vertical speed while the key is held
    [SerializeField] float riseSpeed = 4f;

    [SerializeField] InputAction jumpButton = new InputAction(type: InputActionType.Button);

    // true while the key is pressed
    private bool isHeld = false;

    void OnEnable()
    {
        jumpButton.Enable();
        jumpButton.performed += OnJumpPressed;
        jumpButton.canceled += OnJumpReleased;
    }

    void OnDisable()
    {
        jumpButton.performed -= OnJumpPressed;
        jumpButton.canceled -= OnJumpReleased;
        jumpButton.Disable();
    }

    private void OnJumpPressed(InputAction.CallbackContext ctx)
    {
        // key is now held
        isHeld = true;
    }

    private void OnJumpReleased(InputAction.CallbackContext ctx)
    {
        // key was released
        isHeld = false;
    }

    void FixedUpdate()
    {
        Vector2 v = rigidBody.linearVelocity;

        if (isHeld)
        {
            // While the key is held, move the player up at a constant speed
            v.y = riseSpeed;
            animator.SetBool("isJumping", true);
        }
        else
        {
            // When the key is not held we let gravity control vertical motion
            animator.SetBool("isJumping", false);
        }

        rigidBody.linearVelocity = v;
    }
}
