using UnityEngine;

public class StructureScript : MonoBehaviour, ICanBuild, ICanRemove
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected int currHp;

    [SerializeField] protected int direction;
    [SerializeField] protected Vector2 space;
    [SerializeField] protected Vector2 position;

    public void Build()
    {
        Debug.Log("I'm in the Build() inside StructureScript");
    }
    public void Remove()
    {
        Debug.Log("I'm in the Remove() inside StructureScript");
    }

}
