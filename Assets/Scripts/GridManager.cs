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

    [SerializeField] private HeatMapVisual heatMapVisual;
    private GridScript grid;
    char keySelectedInstrument;
    void Start()
    {
        grid = new GridScript(8,12,1f, new Vector3(0,0,0));
        heatMapVisual.SetGrid(grid);
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

        /*        if (Physics.Raycast(ray, out hitData) && Input.GetMouseButtonUp(0))
                {
                    int x, z;
                    grid.GetXY(new Vector3(hitData.point.x, 0, hitData.point.z), out x, out z);
                    int value = grid.GetValue(x, z);
                    grid.SetValue(x, z, value + 5);
                }
                else if (Physics.Raycast(ray, out hitData) && Input.GetMouseButtonDown(1))
                {
                    int x, z;
                    grid.GetXY(new Vector3(hitData.point.x, 0, hitData.point.z), out x, out z);
                    Debug.Log(grid.GetValue(x, z));
                }*/

        if (Physics.Raycast(ray, out hitData) && Input.GetMouseButtonUp(0))
        {
            Vector3 clickedPlace = new Vector3(hitData.point.x, 0, hitData.point.z);
            bool structureChoosed = false;

            int gridX = 0, gridZ = 0;
            if (grid.GetXY(clickedPlace, out gridX, out gridZ))
            {
                if (grid.IsCellEmpty(gridX, gridZ))
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
                        prefabObject.GetComponent<InteractiveObjectScript>().Build(prefabObject, clickedPlace, grid);
                    }
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
/*        if (Input.GetKeyDown(KeyCode.R))
        {
            if (keySelectedInstrument != 'R') { keySelectedInstrument = 'R'; }
            else { keySelectedInstrument = ' '; }
        }*/

        if (Input.GetKeyDown(KeyCode.D))
        {
            keySelectedInstrument = ' ';

            List<Vector2Int> copyXZ = SelectionManager.Instance.GetAllPosition();
            foreach (var xz in copyXZ)
            {
                grid.RemoveObject(xz);
            }
        }
    }

}