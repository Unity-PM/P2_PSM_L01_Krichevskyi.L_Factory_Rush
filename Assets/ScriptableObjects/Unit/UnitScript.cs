using System;
using UnityEngine;

public class UnitScript : MonoBehaviour, IDamageable
{
    [SerializeField] protected int currHp;

    public event Action OnDeath;
    public virtual void TakeDamage(int amount)
    {
        currHp -= amount;
        Debug.Log($"{gameObject.name} just got {amount} damage and now has {currHp}hp");

        if (currHp <= 0)
            Die();
    }
    protected virtual void Die()
    {
        Debug.Log("Die() called from UnitScript");
    }
    public void OnDeathInvoke()
    {
        OnDeath?.Invoke();
    }

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }

}

