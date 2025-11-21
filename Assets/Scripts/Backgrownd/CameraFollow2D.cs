using UnityEngine;

/**
 * Camera follow for 2D games.
 */
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] Transform target;      // Player to follow
    [SerializeField] Vector3 offset;        // Distance from the player
    [SerializeField] float smoothTime = 0.2f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = target.position + offset;
        targetPos.z = transform.position.z; // Maintain camera's z position

        transform.position = Vector3.SmoothDamp(
            transform.position, targetPos,
            ref velocity, smoothTime);
    }
}
