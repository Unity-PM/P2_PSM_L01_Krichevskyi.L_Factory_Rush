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

    public virtual void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage() called from CreatureScript");
        currHp -= amount;
        Debug.Log($"StructureScript object got {amount} damage");

        if (currHp <= 0)
            Die();
    }
    protected override void Die()
    {
        BuildManager.Instance.RemoveObject(occupiedPositions[0]);
    }
    public void OnDeathInvoke()
    {
        OnDeath?.Invoke();
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
