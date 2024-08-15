using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize;

    private void Start()
    {
        // Initialize cells or other setup code here
    }

    public Vector3 CalculateWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, y * cellSize, 0) + transform.position;
    }

    // Other methods...
}
