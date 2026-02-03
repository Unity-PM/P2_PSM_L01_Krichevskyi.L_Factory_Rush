using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class InteractiveObjectScript : StructureScript, ICanRotate, ICanRelocate
{
    public void RotateStructure()
    {
        Debug.Log("RotateStructure() called from InteractiveObjectScript");
    }
    public void RelocateStructure()
    {
        Debug.Log("RelocateStructure() called from InteractiveObjectScript");
    }
}
