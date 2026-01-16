using UnityEngine;

public class StructureScript : MonoBehaviour, ICanSelect
{
    protected int currHp = 50;
    protected int direction = 1;
    [SerializeField] protected Vector2Int position = new Vector2Int(-1,-1);

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }
    public void SetPosition(Vector2Int pos)
    {
        position = pos;
    }
    public int GetX()
    {
        return position.x;
    }
    public int GetZ()
    {
        return position.y;
    }


    public void OnSelected()
    {
        //Debug.Log("OnSelected() called from StructureScript");
    }

    public void OnDeselected()
    {
        //Debug.Log("OnDeselected() called from StructureScript");
    }

}
