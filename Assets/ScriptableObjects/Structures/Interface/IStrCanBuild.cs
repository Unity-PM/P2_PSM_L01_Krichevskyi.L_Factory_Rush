using UnityEngine;

public interface IStrCanBuild
{
    public void Build(GameObject prefab, Vector3 clickedPlace, GridScript grid);
    public bool CheckPlace(GameObject prefab, Vector3 clickedPlace, GridScript grid, Vector2Int prefabSize, out int clickedX, out int clickedZ);
}
