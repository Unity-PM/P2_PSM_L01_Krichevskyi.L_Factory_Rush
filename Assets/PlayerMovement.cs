using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    void Start() => agent = GetComponent<NavMeshAgent>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // Клик левой кнопкой
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}