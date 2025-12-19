using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Scriptable Objects/Structure/Obstacle")]
public class ObstacleData : ScriptableObject
{
    public int maxHp = 400;
    public Vector2Int sizeInCells = new Vector2Int(1,1);
}
