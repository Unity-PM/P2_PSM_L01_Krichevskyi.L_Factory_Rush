using UnityEngine;

public class SpliterScript : InteractiveObjectScript, IFindNeighbour, ICanTransport
{
    [SerializeField] private SpliterData data;

    void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void TransportItem()
    {
        Debug.Log("TransportItem() called from SpliterScript");
    }
    public void FindNeighbour()
    {
        Debug.Log("FindNeighbour() called from SpliterScript");
    }

}
