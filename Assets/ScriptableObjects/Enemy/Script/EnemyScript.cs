using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IEnCanMove, IEnCanAttack
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
    public void AttackStructure()
    {
        Debug.Log("AttackStructure() called from EnemyScript");
    }
}
