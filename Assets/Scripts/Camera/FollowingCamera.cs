using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-6, 0, -10);
    public float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            Vector3 current = transform.position;
            Vector3 clampedTarget = new Vector3(targetPosition.x, current.y, current.z);

            transform.position = Vector3.SmoothDamp(
                current,
                clampedTarget,
                ref velocity,
                smoothTime
            );
        }
    }
}
