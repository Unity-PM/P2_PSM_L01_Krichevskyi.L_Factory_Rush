using UnityEngine;

public class BeltScript : InteractiveObjectScript, IStrFindSameNeighbour, IStrCanTransport
{
    [SerializeField] private WallData data;

    void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void TransportItem()
    {
        Debug.Log("TransportItem() called from BeltScript");
    }
    public void FindSameNeighbour()
    {
        Debug.Log("FindSameNeighbour() called from BeltScript");
    }

}
