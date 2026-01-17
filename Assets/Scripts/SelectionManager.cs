using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    [SerializeField] private List<StructureScript> selected = new List<StructureScript>();

    void Awake()
    {
        Instance = this;
    }

    public void Select(StructureScript s)
    {
        if (selected.Contains(s)) return;
        selected.Add(s);
        Debug.Log($"{selected[selected.Count-1].GetDisplayName()} just got selected");
        s.OnSelected();
    }

    public void Deselect(StructureScript s)
    {
        if (!selected.Contains(s) || selected.Count == 0) return;
        Debug.Log($"{s.GetDisplayName()} just got deselected");
        s.OnDeselected();
        selected.Remove(s);
    }

    public void DeselectAll()
    {
        if (selected.Count == 0)
            return;

        var copy = new List<StructureScript>(selected);

        foreach (var s in copy)
        {
            s.OnDeselected();
            selected.Remove(s);
        }
    }

    public int GetSelectedCount()
    {
        return selected.Count; 
    }
    public List<Vector2Int> GetAllPosition()
    {
        List<Vector2Int> returnSelectPos = new List<Vector2Int>();

        if (selected.Count == 0)
            return returnSelectPos;

        foreach (var s in selected)
        {
            returnSelectPos.Add(s.GetPositions()[0]);
        }

        return returnSelectPos;
    }

    public IReadOnlyList<StructureScript> GetSelected() => selected;
}