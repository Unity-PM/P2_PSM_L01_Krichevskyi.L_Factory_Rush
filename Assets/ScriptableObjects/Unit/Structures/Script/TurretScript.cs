using System.Collections.Generic;
using UnityEngine;

public class TurretScript : InteractiveObjectScript, ICanAttack, IConsumeElectricity
{
    [SerializeField] private TurretData data;

    private EnemyScript enemy;

    private void Start()
    {
        currHp = data.maxHp;

        enemy = null;
    }

    public void AttackUnit(IDamageable target)
    {
        Debug.Log("AttackUnit() called from TurretScript");
    }
    public void ChooseUnit()
    {
        Debug.Log("ChooseUnit() called from TurretScript");
    }

    public void ConsumeElectricity()
    {
        Debug.Log("ConsumeElectricity() called from TurretScript");
    }
}
