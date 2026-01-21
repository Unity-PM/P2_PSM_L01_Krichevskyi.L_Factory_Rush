using UnityEngine;
using System;

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

    

}
