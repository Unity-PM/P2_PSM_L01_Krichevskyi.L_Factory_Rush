using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;      // Перетащи игрока сюда в инспекторе
    public float detectRange = 0.01f; // Дистанция обнаружения
    private NavMeshAgent agent;

    void Start() => agent = GetComponent<NavMeshAgent>();

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            if (distance <= 1)
            {
                Destroy(player.gameObject);
                Debug.Log("Game Over: Player Destroyed!");
            }
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}