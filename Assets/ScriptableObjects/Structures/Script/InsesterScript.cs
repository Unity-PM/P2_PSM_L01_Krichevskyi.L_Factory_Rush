using UnityEngine;

public class InserterScript : InteractiveObjectScript, IStrFindSameNeighbour, IStrCanTransport
{
    [SerializeField] private InserterData data;

    void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void TransportItem()
    {
        Debug.Log("TransportItem() called from InserterScript");
    }
    public void FindSameNeighbour()
    {
        Debug.Log("FindSameNeighbour() called from InserterScript");
    }

}
