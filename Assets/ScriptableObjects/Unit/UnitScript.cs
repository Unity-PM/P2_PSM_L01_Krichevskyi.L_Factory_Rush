using System;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] protected int currHp;

    public Action deathEvent;

    protected virtual void Die()
    {
        Debug.Log("Die() called from UnitScript");
    }

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }

}

