using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public GridSystem gridSystem;
    public Material lineMaterial;

    private Mesh gridMesh;
    private Vector3[] vertices;
    private int[] lines;

    void Start()
    {
        GenerateGridMesh();
    }

    void GenerateGridMesh()
    {
        gridMesh = new Mesh();
        List<Vector3> vertList = new List<Vector3>();
        List<int> lineList = new List<int>();

        for (int x = 0; x <= gridSystem.width; x++)
        {
            for (int y = 0; y <= gridSystem.height; y++)
            {
                vertList.Add(new Vector3(x * gridSystem.cellSize, y * gridSystem.cellSize, 0)); // Create vertex at each grid point
                if (x < gridSystem.width) // Add line indices for horizontal lines
                {
                    lineList.Add(vertList.Count - 1);
                    lineList.Add(vertList.Count);
                }
                if (y < gridSystem.height) // Add line indices for vertical lines
                {
                    lineList.Add(vertList.Count - 1);
                    lineList.Add(vertList.Count + gridSystem.width);
                }
            }
        }

        gridMesh.vertices = vertList.ToArray();
        gridMesh.SetIndices(lineList.ToArray(), MeshTopology.Lines, 0);
        gridMesh.RecalculateBounds();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gridMesh.Clear();
            GenerateGridMesh();
        }
    }

    void OnRenderObject()
    {
        lineMaterial.SetPass(0);
        Graphics.DrawMeshNow(gridMesh, Vector3.zero, Quaternion.identity);
    }
}
