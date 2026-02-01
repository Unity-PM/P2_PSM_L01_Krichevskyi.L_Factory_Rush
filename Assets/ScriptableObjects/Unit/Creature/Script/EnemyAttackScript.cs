using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttackScript : MonoBehaviour, ICanAttack
{
    public AttackData attackData;
    public Action OnAttackPerformed;

    private float lastAttackTime;

    public void AttackUnit(IDamageable target)
    {
        Debug.Log("AttackUnit() called from EnemyAttackScript");

        if (target == null) return;

        if (Time.time >= lastAttackTime + attackData.cooldown)
        {
            target.TakeDamage((int)attackData.damage);
            lastAttackTime = Time.time;
            OnAttackPerformed?.Invoke();
        }
    }
}
