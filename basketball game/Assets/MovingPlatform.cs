using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float movementSpeed = 2f;

    private Transform currentTarget;

    private void Start()
    {
        currentTarget = endPoint;
    }

    private void Update()
    {
        // Move the platform towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, movementSpeed * Time.deltaTime);

        // Check if the platform has reached the current target
        if (transform.position == currentTarget.position)
        {
            Debug.Log("Platform reached  12312position.");
            // Switch the target destination
            if (currentTarget == startPoint)
            {
                currentTarget = endPoint;
                Debug.Log("Platform reached end position.");
            }
            else
                currentTarget = startPoint;
        }
    }
}
