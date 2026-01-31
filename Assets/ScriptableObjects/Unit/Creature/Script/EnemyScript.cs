using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int currHp;
    
    [SerializeField] private EnemyData data;

    void Start()
    {
        currHp = data.maxHp;
    }

    EnemyChooseActionScript chooseAction;
    EnemyMovementScript movement;
    EnemyAttackScript attack;
    EnemyAnimationScript animation;

}
