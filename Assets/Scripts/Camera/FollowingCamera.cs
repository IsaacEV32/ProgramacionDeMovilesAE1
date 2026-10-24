using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothTime;
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
