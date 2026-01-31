using UnityEngine;

public class UnitScript : MonoBehaviour, IDamageable
{
    [SerializeField] protected int currHp = 1;

    public virtual void TakeDamage(int amount)
    {
        currHp -= amount;
        if (currHp <= 0) Die();
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }

}

