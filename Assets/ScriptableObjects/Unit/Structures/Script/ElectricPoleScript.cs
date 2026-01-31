using System.Collections.Generic;
using UnityEngine;

public class ElectricPoleScript : InteractiveObjectScript, IFindNeighbour
{
    [SerializeField] private ElectricPoleData data;

    private List<StructureScript> structuresNear;

    public void FindNeighbour()
    {
        Debug.Log("FindNeighbour() called from ElectricPoleScript");
    }

    void GiveElectricity()
    {
        Debug.Log("GiveElectricity() called from ElectricPoleScript");
    }
    void ConnectToStructures()
    {
        Debug.Log("ConnectToStructures() called from ElectricPoleScript");
    }

}
