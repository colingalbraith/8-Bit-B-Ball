using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public float zoomSpeed = 1f;
    public float maxZoomOut = 10f;
    public float minZoomIn = 1f;

    private float initialSize;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogError("CameraZoom: Camera component not found!");
                return;
            }
        }

        initialSize = cam.orthographicSize;
    }

    private void Update()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        float newSize = cam.orthographicSize - zoomInput * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoomIn, maxZoomOut);
        cam.orthographicSize = newSize;
    }
}
