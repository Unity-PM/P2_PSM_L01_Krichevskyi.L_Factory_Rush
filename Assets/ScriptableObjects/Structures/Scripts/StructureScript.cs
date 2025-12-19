using UnityEngine;

public class StructureScript : MonoBehaviour, ICanBuild, ICanRemove
{
    [SerializeField] private StructureData structureData;

    public void Build()
    {
        Debug.Log("I'm in the Build() inside StructureScript");
        Debug.Log($"{structureData.direction} is maxHp of StructureData");
    }
    public void Remove()
    {
        Debug.Log("I'm in the Remove() inside StructureScript");
    }

}
