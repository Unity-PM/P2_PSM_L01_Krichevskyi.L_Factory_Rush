using UnityEngine;

public class CreatureScript : UnitScript, ICanMove, IDamageable
{
    public void Move()
    {
        Debug.Log("Move() called from CreatureScript");
    }
    public void ChoosePlaceToMove()
    {
        Debug.Log("Move() called from CreatureScript");
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage() called from CreatureScript");
    }
}
