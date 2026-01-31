using UnityEngine;

public class BeltScript : InteractiveObjectScript, IFindNeighbour, ICanTransport
{
    [SerializeField] public BeltData data;

    void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void TransportItem()
    {
        Debug.Log("TransportItem() called from BeltScript");
    }
    public void FindNeighbour()
    {
        Debug.Log("FindNeighbour() called from BeltScript");
    }


    public override string GetDisplayName()
    {
        return data.title;
    }
    public override Vector2Int GetSizeInCells()
    {
        return data.sizeInCells;
    }

}
