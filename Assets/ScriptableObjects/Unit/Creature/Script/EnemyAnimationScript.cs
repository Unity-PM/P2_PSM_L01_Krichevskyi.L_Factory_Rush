using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    private Animator animator;
    private AttackScript attackModule;
    private EnemyMovementScript moveModule;

    void Awake()
    {
        animator = GetComponent<Animator>();
        attackModule = GetComponent<AttackScript>();

        attackModule.OnAttackPerformed += PlayAttack;
    }

    private void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void SetMoveSpeed(float speed)
    {
        // Меняем скорость в аниматоре (0 - стоит, >0 - бежит)
        animator.SetFloat("Speed", speed);
    }

}
