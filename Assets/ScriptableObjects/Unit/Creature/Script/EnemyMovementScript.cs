using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovementScript : MonoBehaviour, ICanMove
{
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
