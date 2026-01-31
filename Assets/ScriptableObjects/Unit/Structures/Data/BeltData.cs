using UnityEngine;

[CreateAssetMenu(fileName = "Belt", menuName = "Scriptable Objects/Structure/Belt")]
public class BeltData : ScriptableObject
{
    public string title = "Belt";
    public int maxHp = 100;
    public Vector2Int sizeInCells = new Vector2Int(1, 1);
    public float transportSpeed = 5;
}
