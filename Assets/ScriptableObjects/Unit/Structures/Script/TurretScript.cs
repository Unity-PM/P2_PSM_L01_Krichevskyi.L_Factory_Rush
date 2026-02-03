using System.Collections.Generic;
using UnityEngine;

public class TurretScript : InteractiveObjectScript, IConsumeElectricity
{
    [SerializeField] private TurretData data;

    public TurretChooseActionScript chooseAction;
    public AttackScript attack;

    private EnemyScript enemy;

    private void Awake()
    {
        chooseAction = GetComponent<TurretChooseActionScript>();
        attack = GetComponent<AttackScript>();
    }

    private void Start()
    {
        currHp = data.maxHp;
    }



    public void ConsumeElectricity()
    {
        Debug.Log("ConsumeElectricity() called from TurretScript");
    }
}
