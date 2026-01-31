using UnityEngine;

public class EnemyMovementScript : MonoBehaviour, ICanMove
{
    

    public void Move()
    {
        Debug.Log("Move() called from EnemyMovementScript");
    }
}
