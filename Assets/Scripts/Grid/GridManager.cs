using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public GameObject beltPrefab;
    public GameObject factoryPrefab;

    private GridScript grid;
    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private GridDebugViewer gridDebugViewer;
    char keySelectedInstrument;
    void Start()
    {
        grid = new GridScript(8,12,1f, new Vector3(0,0,0));
        heatMapVisual.SetGrid(grid);
        gridDebugViewer.SetGrid(grid);
        keySelectedInstrument = ' '; //active "key" on the keyboard
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyPressed();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData) && Input.GetMouseButtonUp(0))
        {
            Vector3 clickedPlace = new Vector3(hitData.point.x, 0, hitData.point.z);

            int gridX = 0, gridZ = 0;
            if (grid.GetXY(clickedPlace, out gridX, out gridZ))
            {
                if (grid.IsCellEmpty(gridX, gridZ))
                {
                    SelectionManager.Instance.DeselectAll();
                    PlaceStructure(clickedPlace);
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

    void KeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (keySelectedInstrument != '1') { keySelectedInstrument = '1'; }
            else { keySelectedInstrument = ' '; }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (keySelectedInstrument != '2') { keySelectedInstrument = '2'; }
            else { keySelectedInstrument = ' '; }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SelectionManager.Instance.GetSelectedCount() == 0)
                return;

            List<Vector2Int> copyXZ = SelectionManager.Instance.GetAllPosition();
            foreach (var xz in copyXZ)
            {
                grid.RemoveObject(xz);
            }
        }
    }

    public void PlaceStructure(Vector3 worldPosition)
    {
        GameObject prefabObject = null;

        if (keySelectedInstrument == '1')
        {
            prefabObject = beltPrefab;
        }
        else if (keySelectedInstrument == '2')
        {
            prefabObject = factoryPrefab;
        }

        if (prefabObject != null)
        {
            prefabObject.GetComponent<InteractiveObjectScript>().Build(prefabObject, worldPosition, grid);
        }
    }
    public void SelectStructure()
    {
        
    }
}
