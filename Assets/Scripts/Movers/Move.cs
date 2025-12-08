using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Moves the player in a specified direction
 */

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 direction;
    [SerializeField] Animator animator;
    [SerializeField] InputAction startMove = new InputAction(type: InputActionType.Button); // Enter arrow key
    public bool isPressedUI = false; // Set to true by UI button
    private bool isPressed = false; 

    // Subscribe and unsubscribe to input action events
    void OnEnable()
    {
        startMove.Enable();
        startMove.performed += OnWalkPressed;
    }

    // Unsubscribe to input action events
    void OnDisable()
    {
        startMove.performed -= OnWalkPressed;
        startMove.Disable();
        isPressedUI = false;
        isPressed = false;
        animator.SetBool("isWalking", false);

        // Stop any residual movement
        if (GetComponent<Rigidbody2D>() != null)
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    private void OnWalkPressed(InputAction.CallbackContext ctx)
    {
        isPressed = true;
    }

    void Update()
    {
        //Move the player on direction while the key is held
        if (isPressed || isPressedUI)
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
