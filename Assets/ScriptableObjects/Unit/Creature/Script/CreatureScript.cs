using System;
using UnityEngine;

public class CreatureScript : UnitScript, IDamageable
{
    public event Action OnDeath;
    public virtual void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage() called from CreatureScript");
    }
}
