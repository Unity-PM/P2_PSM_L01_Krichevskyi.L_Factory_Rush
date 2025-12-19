using UnityEngine;

public class InteractiveObjectScript : StructureScript, IStrCanBuild, IStrCanMove
{
    public void Build()
    {
        Debug.Log("Build() called from InteractiveObjectScript");
    }
    public void CheckPlace()
    {
        Debug.Log("CheckPlace() called from InteractiveObjectScript");
    }

    public void Move()
    {
        Debug.Log("Move() called from InteractiveObjectScript");
    }
}
