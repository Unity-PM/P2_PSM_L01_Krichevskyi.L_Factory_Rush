using UnityEngine;

public class SpliterScript : InteractiveObjectScript, IStrFindSameNeighbour, IStrCanTransport
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
    public void FindSameNeighbour()
    {
        Debug.Log("FindSameNeighbour() called from SpliterScript");
    }

}
