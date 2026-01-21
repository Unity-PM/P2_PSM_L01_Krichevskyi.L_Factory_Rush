using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridScript : IStrCanRemove
{

    public const int HEAT_MAP_MAX_VALUE = 100;
    public const int HEAT_MAP_MIN_VALUE = 0;

    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int z;
    }

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private Vector2 maxCoordinates;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    private Dictionary<Vector2Int, StructureScript> objectGrid;

    public GridScript(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        maxCoordinates = new Vector2(Convert.ToSingle(width) * cellSize + originPosition.x, Convert.ToSingle(height) * cellSize + originPosition.z);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                /*UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 30, Color.white, TextAnchor.MiddleCenter);*/
                debugTextArray[x, z] = CreateWorldObject(null, gridArray[x, z].ToString(), GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * 0.5f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);


        objectGrid = new Dictionary<Vector2Int, StructureScript>();


        SetValue(6, 7, 67);
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }
    public Vector3 GetWorldPositionToBuild(int x, int z, Vector2Int prefabSize)
    {
        Vector3 returnVector = new Vector3(x, 0, z) * cellSize + originPosition;

        returnVector.x += (cellSize * prefabSize.x) / 2;
        returnVector.z += (cellSize * prefabSize.y) / 2;

        return returnVector;
    }

    private TextMesh CreateWorldObject(Transform parent, string text, Vector3 localPosition /*float cellSize*/)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);/*
        localPosition.y -= cellSize + 0.01f;*/
        transform.localPosition = localPosition;
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        //
        textMesh.anchor = TextAnchor.MiddleCenter;
        TextAlignment textAlignment = TextAlignment.Left;
        textMesh.text = text;
        textMesh.fontSize = 5;
        textMesh.color = Color.white;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = 5000;
        return textMesh;
    }

    public bool GetXY(Vector3 worldPosition, out int x, out int z)
    {
        if (worldPosition.x > maxCoordinates.x || worldPosition.x < originPosition.x ||
            worldPosition.z > maxCoordinates.y || worldPosition.z < originPosition.y)
        {
            x = z = -1;
            return false;
        }
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
        return true;
    }

    public void SetValue(int x, int z, int value) {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = Mathf.Clamp(value, HEAT_MAP_MIN_VALUE, HEAT_MAP_MAX_VALUE);
            debugTextArray[x,z].text = gridArray[x,z].ToString();
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, z = z });
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, z;
        GetXY(worldPosition, out x, out z);
        SetValue(x, z, value);
    }
    public int GetValue(int x, int z) {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            return 0;
        }
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x, z;
        GetXY(worldPosition, out x, out z);
        return GetValue(x, z);
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
    public float GetCellSize()
    {
        return cellSize;
    }
    public Vector2 GetMaxCoordinates()
    {
        return maxCoordinates;
    }
    public bool PlaceObject(Vector2Int pos, StructureScript structure)
    {
        if (objectGrid.ContainsKey(pos)) return false;

        
        objectGrid[pos] = structure;
        return true;
    }
    public void RemoveObject(Vector2Int pos)
    {
        Debug.Log("Remove() called from GridScript");

        if (!objectGrid.TryGetValue(pos, out StructureScript s))
            return;

        SelectionManager.Instance.Deselect(s);
        objectGrid.Remove(pos);
        GameObject.Destroy(s.gameObject);

    }

    public StructureScript GetObject(Vector2Int pos)
    {
        objectGrid.TryGetValue(pos, out StructureScript s);
        return s;
    }
    public StructureScript GetObject(int gridX, int gridY)
    {
        Vector2Int gridVec = new Vector2Int(gridX, gridY);
        return GetObject(gridVec);
    }
    public bool IsCellEmpty(Vector2Int pos)
    {
        return !objectGrid.ContainsKey(pos);
    }
    public bool IsCellEmpty(int gridX, int gridY)
    {
        Vector2Int gridVec = new Vector2Int (gridX, gridY);
        return IsCellEmpty(gridVec);
    }
}
