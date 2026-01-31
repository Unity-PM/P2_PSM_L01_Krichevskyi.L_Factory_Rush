using System.Collections.Generic;
using UnityEngine;

public class StructureScript : UnitScript, ICanSelect, IDamageable
{
    [SerializeField] protected int direction = 1;
    [SerializeField] protected List<Vector2Int> occupiedPositions = new List<Vector2Int>();


    public virtual Vector2Int GetSizeInCells()
    {
        Vector2Int vec = new Vector2Int(1, 1);
        return vec;
    }
    public void SetPositions(List<Vector2Int> positions)
    {
        occupiedPositions = positions;
    }
    public List<Vector2Int> GetPositions()
    {
        return occupiedPositions;
    }


    public void OnSelected()
    {
        //Debug.Log("OnSelected() called from StructureScript");
    }
    public void OnDeselected()
    {
        //Debug.Log("OnDeselected() called from StructureScript");
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage() called from StructureScript");
    }

}
