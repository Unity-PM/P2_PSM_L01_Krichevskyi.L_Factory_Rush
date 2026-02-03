using System.Collections.Generic;
using UnityEngine;
using System;

public class StructureScript : UnitScript, IDamageable, ICanSelect
{
    [SerializeField] protected int direction = 1;
    [SerializeField] protected List<Vector2Int> occupiedPositions = new List<Vector2Int>();

    public event Action OnDeath;

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

    protected override void Die()
    {
        OnDeath?.Invoke();
        BuildManager.Instance.RemoveObject(occupiedPositions[0]);
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
