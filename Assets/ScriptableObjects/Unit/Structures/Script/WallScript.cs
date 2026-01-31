using UnityEngine;

public class WallScript : InteractiveObjectScript, IFindNeighbour
{
    [SerializeField] private WallData data;

    private void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }

    public void FindNeighbour()
    {
        Debug.Log("FindNeighbour() called from WallScript");
    }
}
