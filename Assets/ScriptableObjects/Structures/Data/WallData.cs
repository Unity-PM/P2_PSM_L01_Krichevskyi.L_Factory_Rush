using UnityEngine;

[CreateAssetMenu(fileName = "Wall", menuName = "Scriptable Objects/Structure/Wall")]
public class WallData : ScriptableObject
{
    public int maxHp = 600;
    public Vector2Int sizeInCells = new Vector2Int(1, 1);
}
