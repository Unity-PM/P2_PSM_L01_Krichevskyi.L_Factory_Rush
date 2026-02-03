using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CreatureScript
{

    [SerializeField] private EnemyData data;

    public EnemyChooseActionScript chooseAction;
    public EnemyMovementScript movement;
    public AttackScript attack;
    public EnemyAnimationScript animation;


    private void Awake()
    {
        chooseAction = GetComponent<EnemyChooseActionScript>();
        movement = GetComponent<EnemyMovementScript>();
        attack = GetComponent<AttackScript>();
        animation = GetComponent<EnemyAnimationScript>();
    }


    void Start()
    {
        currHp = data.maxHp;
    }


    public float GetMoveSpeed()
    {
        return data.moveSpeed;
    }
    


}
