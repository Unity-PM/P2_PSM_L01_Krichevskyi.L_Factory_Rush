using UnityEngine;

public class StructureScript : ScriptableObject, ICanBuild, ICanRemove
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected int currHp;

    [SerializeField] protected int direction;
    [SerializeField] protected Vector2 space;
    [SerializeField] protected Vector2 position;

    public void Build()
    {

    }
    public void Remove()
    {

    }

}
