using UnityEngine;

public class EnemyChooseActionScript : MonoBehaviour, ICanChooseUnit
{
    private float searchInterval = 1f;

    private EnemyScript enemy;
    private IDamageable currentTarget;
    
    private void Start()
    {
        enemy = GetComponent<EnemyScript>();
        // Запускаем цикл размышлений раз в секунду, чтобы не грузить процессор
        InvokeRepeating(nameof(Think), 0f, searchInterval);
    }

    public void Think()
    {
        // Если цель уже есть и она жива, ничего не делаем
        if (currentTarget != null) return;

        currentTarget = ChooseUnit();

        if (currentTarget != null)
        {
            // Берем позицию цели и отдаем команду модулю движения
            Vector3 targetPosition = ((MonoBehaviour)currentTarget).transform.position;
            enemy.movement.MoveTo(targetPosition);
        }
    }


    public IDamageable ChooseUnit()
    {
        Debug.Log("ChooseUnit() called from EnemyChooseActionScript");

        StructureScript target = Object.FindAnyObjectByType<StructureScript>();
        return target;
    }
}
