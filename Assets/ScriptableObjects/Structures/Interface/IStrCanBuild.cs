using UnityEngine;

public interface IStrCanBuild
{
    public void Build(GameObject prefab, Vector3 clickedPlace, Grid grid);
    public bool CheckPlace(GameObject prefab, Vector3 clickedPlace, Grid grid, Vector2Int prefabSize, out int clickedX, out int clickedZ);
}
