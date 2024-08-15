using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minCameraPos; // Minimum camera position, should match map bounds
    public Vector2 maxCameraPos; // Maximum camera position, should match map bounds
    public float edgeThreshold = 50f; // Sensitivity for detecting mouse at the edge

    public float minZoom = 5f; // Minimum zoom level
    public float maxZoom = 20f; // Maximum zoom level
    public float zoomSpeed = 0.5f; // Speed of zooming in and out

    private Camera cam; // Reference to the camera

    void Start()
    {
        cam = Camera.main; // Ensure there's a Camera component attached to the same GameObject
        AdjustCameraToBounds(); // Initial adjustment
    }

    void Update()
    {
        PanCamera();
        ZoomCamera();
        AdjustCameraToBounds(); // Ensure boundaries are always adjusted
    }

    void PanCamera()
    {
        Vector3 newPosition = transform.position;

        // Get mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Check horizontal movement
        if (mousePosition.x < edgeThreshold) // Mouse is near the left edge
        {
            newPosition.x -= Time.deltaTime;
        }
        else if (mousePosition.x > Screen.width - edgeThreshold) // Mouse is near the right edge
        {
            newPosition.x += Time.deltaTime;
        }

        // Check vertical movement
        if (mousePosition.y < edgeThreshold) // Mouse is near the bottom edge
        {
            newPosition.y -= Time.deltaTime;
        }
        else if (mousePosition.y > Screen.height - edgeThreshold) // Mouse is near the top edge
        {
            newPosition.y += Time.deltaTime;
        }

        transform.position = newPosition; // Update position
    }

    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }

    void AdjustCameraToBounds()
    {
        // Calculate the limits based on the zoom level
        float verticalExtent = cam.orthographicSize;
        float horizontalExtent = verticalExtent * cam.aspect;

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minCameraPos.x + horizontalExtent, maxCameraPos.x - horizontalExtent);
        newPosition.y = Mathf.Clamp(newPosition.y, minCameraPos.y + verticalExtent, maxCameraPos.y - verticalExtent);

        transform.position = newPosition;
    }
}
