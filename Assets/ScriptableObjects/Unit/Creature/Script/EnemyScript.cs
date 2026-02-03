using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CreatureScript
{

    [SerializeField] public EnemyData data;

    public EnemyChooseActionScript chooseAction;
    public EnemyMovementScript movement;
    public EnemyAttackScript attack;
    public EnemyAnimationScript animation;


    private void Awake()
    {
        movement = GetComponent<EnemyMovementScript>();
        attack = GetComponent<EnemyAttackScript>();
        chooseAction = GetComponent<EnemyChooseActionScript>();
        animation = GetComponent<EnemyAnimationScript>();
    }


    void Start()
    {
        currHp = data.maxHp;
    }


}
