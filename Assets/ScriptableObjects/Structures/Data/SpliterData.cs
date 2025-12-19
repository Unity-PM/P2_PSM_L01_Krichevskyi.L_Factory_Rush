using UnityEngine;

[CreateAssetMenu(fileName = "Spliter", menuName = "Scriptable Objects/Structure/Spliter")]
public class SpliterData : ScriptableObject
{
    public int maxHp = 250;
    public Vector2Int sizeInCells = new Vector2Int(1, 1);
    public float transportSpeed = 5;
}
