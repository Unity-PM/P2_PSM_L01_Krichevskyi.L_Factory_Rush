using System.Collections.Generic;
using UnityEngine;

public class TurretScript : InteractiveObjectScript, IStrCanShoot, IStrCanTake, IStrConsumeElectricity
{
    [SerializeField] private TurretData data;

    private EnemyScript enemy;

    private void Start()
    {
        currHp = data.maxHp;

        enemy = null;
    }

    public void WatchEnemy()
    {
        Debug.Log("WatchEnemy() called from TurretScript");
    }
    public void ShootEnemy()
    {
        Debug.Log("ShootEnemy() called from TurretScript");
    }
    public void TakeItem()
    {
        Debug.Log("TakeItem() called from TurretScript");
    }
    public void ConsumeElectricity()
    {
        Debug.Log("ConsumeElectricity() called from TurretScript");
    }
}
