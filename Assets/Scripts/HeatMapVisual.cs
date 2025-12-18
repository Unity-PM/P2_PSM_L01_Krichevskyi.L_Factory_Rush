using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class HeatMapVisual : MonoBehaviour
{
    private Grid grid;
    private Mesh mesh;

    [SerializeField] private Texture2D heatMapTexture; // сюда drag & drop текстуру Black_Red_Yellow_Green
    private Material material;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        material = new Material(Shader.Find("Unlit/Texture")); // простой шейдер для UV
        material.mainTexture = heatMapTexture;
        GetComponent<MeshRenderer>().material = material;
    }

    public void SetGrid(Grid grid)
    {
        this.grid = grid;
        UpdateHeatMapVisual();
        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, Grid.OnGridValueChangedEventArgs e)
    {
        UpdateHeatMapVisual();
    }

    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        Vector3 gridOffset = new Vector3(grid.GetCellSize() * 0.5f, 0f, grid.GetCellSize() * 0.5f);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int z = 0; z < grid.GetHeight(); z++)
            {
                int gridValue = grid.GetValue(x, z);
                float gridValueNormalized = (float)gridValue / Grid.HEAT_MAP_MAX_VALUE;
                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f); // X координата UV по текстуре

                int index = x * grid.GetHeight() + z;
                Vector3 quadSize = new Vector3(1, 1, 1) * grid.GetCellSize();
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index,
                    grid.GetWorldPosition(x, z) + gridOffset, 0f, quadSize, gridValueUV, gridValueUV);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
