using UnityEngine;

public class StructureScript : MonoBehaviour, IStrCanRemove
{
    protected int currHp = 50;
    protected int direction = 1;
    protected Vector2Int position;

    public void Remove()
    {
        Debug.Log("Remove() called from StructureScript");
    }
}
