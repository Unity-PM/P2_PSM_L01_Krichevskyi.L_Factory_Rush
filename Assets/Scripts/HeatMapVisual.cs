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

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;

                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();
                MeshUtils.AddToMeshArrays(vertices, uv, triangels, index, grid.GetWorldPosition(x, y), 0f, quadSize, Vector2.zero, Vector2.zero);
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangels;
        }
    }

    
}
