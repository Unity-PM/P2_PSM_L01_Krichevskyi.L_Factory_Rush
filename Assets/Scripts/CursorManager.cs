using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public GridScript grid;
    public GridManager gridManager;

    public static CursorManager Instance;

    public static event Action CursorManagerLoaded;

    private void Start()
    {
        Instance = this;
        grid = gridManager.GetGrid();

        CursorManagerLoaded?.Invoke();
        Debug.Log("I'm inside of Start() of CursorManager");
    }

    public Vector3 GetCursorWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (
        Physics.Raycast(ray, out hitData))
            return new Vector3(hitData.point.x, 0, hitData.point.z);

        return Vector3.zero;
    }
    public List<RaycastResult> GetUIComponentsList()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results;
    }

    private void Update()
    {
        if (BuildManager.Instance.IsBuilding())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = GetCursorWorldPosition();
            if (grid.GetXY(worldPosition, out int gridX, out int gridZ))
            {
                if (grid.IsCellEmpty(gridX, gridZ))
                {
                    SelectionManager.Instance.DeselectAll();
                }
                else
                {
                    if (!Input.GetKey(KeyCode.LeftControl)) { SelectionManager.Instance.DeselectAll(); }

                    StructureScript structure = grid.GetObject(gridX, gridZ);
                    SelectionManager.Instance.Select(structure);
                }

            }

        }
    }

}
