using UnityEngine;

/*[CreateAssetMenu(fileName = "StructureData", menuName = "Scriptable Objects/StructureData")]*/
public class StructureData : ScriptableObject
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected Vector2 space;

    [SerializeField] public int direction;
    [SerializeField] protected Vector2 position;
}
