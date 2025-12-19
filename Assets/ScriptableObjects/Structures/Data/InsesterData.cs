using UnityEngine;

[CreateAssetMenu(fileName = "Inserter", menuName = "Scriptable Objects/Structure/Inserter")]
public class InserterData : ScriptableObject
{
    public int maxHp = 150;
    public Vector2Int sizeInCells = new Vector2Int(1, 1);
    public float transportSpeed = 5;
}
