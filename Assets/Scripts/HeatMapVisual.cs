using UnityEditor;
using UnityEngine;
using CodeMonkey.Utils;
using System.Security;

public class HeatMapVisual : MonoBehaviour
{
    private Grid grid;
    private Mesh mesh;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(Grid grid)
    {
        this.grid = grid;
        UpdateHeatMapVisual();
    }

    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangels);

        Vector3 gridOffset = new Vector3(grid.GetCellSize() * 0.5f, 0f, grid.GetCellSize() * 0.5f);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int z = 0; z < grid.GetHeight(); z++)
            {
                int index = x * grid.GetHeight() + z;

                Vector3 quadSize = new Vector3(1, 1, 1) * grid.GetCellSize();
                MeshUtils.AddToMeshArrays(vertices, uv, triangels, index,
                    grid.GetWorldPosition(x, z) + gridOffset, 0f, quadSize, Vector2.zero, Vector2.zero);
                    
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangels;
        }
    }

    
}
