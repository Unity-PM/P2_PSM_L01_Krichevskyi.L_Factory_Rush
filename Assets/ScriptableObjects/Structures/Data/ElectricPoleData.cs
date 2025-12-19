using UnityEngine;

[CreateAssetMenu(fileName = "ElectricPole", menuName = "Scriptable Objects/Structure/ElectricPole")]
public class ElectricPoleData : ScriptableObject
{
    public int maxHp = 200;
    public Vector2Int sizeInCells = new Vector2Int(1, 1);
    public Vector2Int coverageArea;
}
