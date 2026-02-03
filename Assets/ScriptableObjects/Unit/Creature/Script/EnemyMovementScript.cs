using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovementScript : MonoBehaviour, ICanMove
{
    private NavMeshAgent agent;
    private EnemyScript enemy;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<EnemyScript>();
    }

    void Start()
    {
        agent.speed = enemy.data.moveSpeed;
    }

    public void MoveTo(Vector3 position)
    {
        Debug.Log("Move() called from EnemyMovementScript");

        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
}
