using UnityEngine;

public class WallScript : StructureScript
{
    [SerializeField] private WallData wallData;
    private void Start()
    {
        writeText();
        Remove();
        Build();
    }
    void writeText()
    {
        Debug.Log("Function inside WallScript");
    }
}
