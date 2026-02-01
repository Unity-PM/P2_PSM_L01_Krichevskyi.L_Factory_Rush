using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : CreatureScript
{

    [SerializeField] private EnemyData data;

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

        currHp = data.maxHp;
    }


    void Start()
    {
        currHp = data.maxHp;
    }


}
