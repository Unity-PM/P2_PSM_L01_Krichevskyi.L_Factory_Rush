using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager : MonoBehaviour
{
    private GridScript grid;
    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private GridDebugViewer gridDebugViewer;

    [SerializeField] private GridData gridData;

    public static event Action GridManagerLoaded;

    void Start()
    {
        grid = new GridScript(gridData.width, gridData.height, gridData.cellSize, gridData.originPosition);
        /*Debug.Log("Hi from GridManager file!");*/
        heatMapVisual.SetGrid(grid);
        gridDebugViewer.SetGrid(grid);

        GridManagerLoaded?.Invoke();

    }

    public GridScript GetGrid() { return grid; }
}
