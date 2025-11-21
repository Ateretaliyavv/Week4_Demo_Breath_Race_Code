using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Moves the player forward while the right arrow key is held.
 */

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 direction;
    [SerializeField] Animator animator;
    [SerializeField] InputAction moveRight = new InputAction(type: InputActionType.Button); // Right arrow key
    private bool isPressed = false;

    // Subscribe and unsubscribe to input action events
    void OnEnable()
    {
        moveRight.Enable();
        moveRight.performed += OnWalkPressed;
    }

    void OnDisable()
    {
        moveRight.performed -= OnWalkPressed;
        moveRight.Disable();
    }

    private void OnWalkPressed(InputAction.CallbackContext ctx)
    {
        isPressed = true;
    }

    void Update()
    {
        //Move the player on direction while the key is held
        if (isPressed)
        {
            animator.SetBool("isWalking", true);
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
