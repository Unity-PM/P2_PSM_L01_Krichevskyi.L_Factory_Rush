using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    private Animator animator;
    private EnemyAttackScript attackModule;
    private EnemyMovementScript moveModule;

    void Awake()
    {
        animator = GetComponent<Animator>();
        attackModule = GetComponent<EnemyAttackScript>();

        // Подписка на ивент атаки
        attackModule.OnAttackPerformed += PlayAttack;
    }

    private void PlayAttack()
    {
        // Триггер сам сработает и вернётся в Idle/Move
        animator.SetTrigger("Attack");
    }

    public void SetMoveSpeed(float speed)
    {
        // Меняем скорость в аниматоре (0 - стоит, >0 - бежит)
        animator.SetFloat("Speed", speed);
    }

}
