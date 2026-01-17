using UnityEngine;

public class BeltScript : InteractiveObjectScript, IStrFindSameNeighbour, IStrCanTransport, ICanRotate
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
    public void FindSameNeighbour()
    {
        Debug.Log("FindSameNeighbour() called from BeltScript");
    }
    
    public void Rotate()
    {
        Debug.Log("Rotate() called from BeltScript");
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
