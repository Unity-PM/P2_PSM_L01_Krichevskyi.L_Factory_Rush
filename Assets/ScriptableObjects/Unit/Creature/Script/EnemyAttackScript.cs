using UnityEngine;

public class EnemyAttackScript : MonoBehaviour, ICanAttack
{


    public void AttackUnit()
    {
        Debug.Log("AttackUnit() called from EnemyAttackScript");
    }
}
