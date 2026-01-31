using UnityEngine;

public class WallScript : InteractiveObjectScript, IStrFindSameNeighbour
{
    [SerializeField] private WallData data;

    private void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void FindSameNeighbour()
    {
        Debug.Log("FindSameNeighbour() called from WallScript");
    }
}
