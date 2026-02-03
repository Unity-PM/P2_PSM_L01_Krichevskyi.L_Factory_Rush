using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChooseActionScript : MonoBehaviour, ICanChooseUnit
{
    private float searchInterval = 0.25f;

    private EnemyScript enemy;
    [SerializeField] private IDamageable currentTarget;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private float distanceToTarget;


    private void Start()
    {
        enemy = GetComponent<EnemyScript>();
        // Запускаем цикл размышлений раз в секунду, чтобы не грузить процессор
        InvokeRepeating(nameof(Think), 0f, searchInterval);
    }

    private void Update()
    {
        if (currentTarget == null) return;

        Collider targetCollider = ((MonoBehaviour)currentTarget).GetComponent<Collider>();
        Vector3 closestPoint = targetCollider.ClosestPoint(transform.position);

        distanceToTarget = Vector3.Distance(transform.position, closestPoint);

        if (distanceToTarget <= enemy.attack.attackData.range)
        {
            enemy.movement.Stop();
        }
        else
        {
            enemy.movement.MoveTo(((MonoBehaviour)currentTarget).transform.position);
        }
    }

    public void Think()
    {
        SetCurrentTarget(ChooseUnit());

        if (currentTarget == null)
            return;

        if (distanceToTarget <= enemy.attack.attackData.range)
        {
            enemy.attack.AttackUnit(currentTarget);
        }
    }

    public IDamageable ChooseUnit()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50f, targetMask);
        IDamageable bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            IDamageable potentialTarget = hitCollider.GetComponent<IDamageable>();
            if (potentialTarget != null)
            {
                float dSqrToTarget = (hitCollider.transform.position - transform.position).sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }

        if (bestTarget != null)
        {
            bestTarget.OnDeath += SetCurrentTargetNull;
        }

        return bestTarget;
    }
    private void SetCurrentTarget(IDamageable target)
    {
        currentTarget = target;
    }
    private void SetCurrentTargetNull()
    {
        SetCurrentTarget(null);
    }

}
