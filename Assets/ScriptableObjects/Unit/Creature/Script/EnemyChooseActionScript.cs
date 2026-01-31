using UnityEngine;

public class EnemyChooseActionScript : MonoBehaviour, ICanChooseUnit
{
    
    public void ChooseUnit()
    {
        Debug.Log("ChooseUnit() called from EnemyChooseActionScript");
    }
}
