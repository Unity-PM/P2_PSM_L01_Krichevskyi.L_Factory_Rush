using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour, ICanAttack
{
    [SerializeField] private EnemyData data;

    private int currHp;

    void Start()
    {
        currHp = data.maxHp;
    }

    public void Move()
    {
        Debug.Log("Move() called from EnemyScript");
    }
    public void ChoosePlaceToMove()
    {
        Debug.Log("ChoosePlaceToMove() called from EnemyScript");
    }
    public void AttackUnit()
    {
        Debug.Log("AttackUnit() called from EnemyScript");
    }
    public void ChooseUnit()
    {
        Debug.Log("ChooseUnit() called from EnemyScript");
    }
}
