using UnityEngine;

public class CreatureScript : UnitScript, IDamageable
{
    

    public virtual void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage() called from CreatureScript");
    }
}
