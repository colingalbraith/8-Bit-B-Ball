using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    private Vector3 offset;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: Target is not assigned!");
            return;
        }

        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
