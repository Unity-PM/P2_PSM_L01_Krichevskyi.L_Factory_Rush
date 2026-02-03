using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GridDebugViewer : Timer
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;

    [SerializeField] private List<StructureScript> objectGridFirstRow;
    [SerializeField] private List<StructureScript> objectGridSecondRow;
    [SerializeField] private List<StructureScript> objectGridThirdRow;
    [SerializeField] private List<StructureScript> objectGridFourthRow;
    private List<bool> gridHeight;

    private GridScript grid;

    public void SetGrid(GridScript grid)
    {
        this.grid = grid;
        width = grid.GetWidth();
        height = grid.GetHeight();
        cellSize = grid.GetCellSize();

        gridHeight = new List<bool>();
        for (int i = 0; i < 4; i++)
        {
            if (grid.GetHeight() > i)
                gridHeight.Add(true);
            else
                gridHeight.Add(false);
        }

    }

    void Update()
    {
        base.Update();
        if (grid == null) return;

        objectGridFirstRow.Clear();
        objectGridSecondRow.Clear();
        objectGridThirdRow.Clear();
        objectGridFourthRow.Clear();
        for (int x = 0; x < width; x++)
        {
            if (gridHeight[0]) { objectGridFirstRow.Add(grid.GetObject(x, 0)); }
            if (gridHeight[1]) { objectGridSecondRow.Add(grid.GetObject(x, 1)); }
            if (gridHeight[2]) { objectGridThirdRow.Add(grid.GetObject(x, 2)); }
            if (gridHeight[3]) { objectGridFourthRow.Add(grid.GetObject(x, 3)); }
        }

    }
}
