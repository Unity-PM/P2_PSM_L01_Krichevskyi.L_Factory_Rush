using UnityEngine;

public class TurretChooseActionScript : MonoBehaviour, ICanChooseUnit
{
    private float searchInterval = 0.25f;

    private TurretScript turret;
    [SerializeField] private IDamageable currentTarget;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private float distanceToTarget;

    private void Awake()
    {
        turret = GetComponent<TurretScript>();
        InvokeRepeating(nameof(Think), 0f, searchInterval);
    }

    private void Update()
    {
        if (currentTarget == null) return;

        Collider targetCollider = ((MonoBehaviour)currentTarget).GetComponent<Collider>();
        float distanceToTarget = Vector3.Distance(transform.position, targetCollider.ClosestPoint(transform.position));

        if (distanceToTarget <= turret.attack.attackData.range)
        {
            turret.attack.AttackUnit(currentTarget);
        }
        else
        {
            currentTarget = null;
        }
    }

    private void Think()
    {
        if (currentTarget == null)
        {
            currentTarget = ChooseUnit();
        }
    }

    public IDamageable ChooseUnit()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, turret.attack.attackData.range, targetMask);
        IDamageable bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (var col in hitColliders)
        {
            IDamageable potential = col.GetComponent<IDamageable>();
            if (potential != null)
            {
                float dSqr = (col.transform.position - transform.position).sqrMagnitude;
                if (dSqr < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqr;
                    bestTarget = potential;
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