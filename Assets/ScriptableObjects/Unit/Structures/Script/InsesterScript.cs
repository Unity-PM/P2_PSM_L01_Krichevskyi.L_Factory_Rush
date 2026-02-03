using UnityEngine;

public class InserterScript : InteractiveObjectScript, IFindNeighbour, ICanTransport
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
    public void FindNeighbour()
    {
        Debug.Log("FindNeighbour() called from InserterScript");
    }

}
