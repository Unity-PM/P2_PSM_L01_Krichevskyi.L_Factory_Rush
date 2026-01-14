using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridBuildingSystem : MonoBehaviour
{
    public GameObject beltPrefab;
    public GameObject factoryPrefab;

    [SerializeField] private HeatMapVisual heatMapVisual;
    private Grid grid;
    char keySelectedInstrument;
    void Start()
    {
        grid = new Grid(8,12,1f, new Vector3(0,0,0));
        heatMapVisual.SetGrid(grid);
        keySelectedInstrument = ' ';
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

            GameObject prefabObject = null;
            if (keySelectedInstrument == '1')
            {
                prefabObject = beltPrefab;
            }
            if (keySelectedInstrument == '2')
            {
                prefabObject = factoryPrefab;
            }
            /*if (keySelectedInstrument == 'E')
            {
                prefabObject = factoryPrefab;
            }*/

            if (prefabObject != null)
            {
                prefabObject.GetComponent<InteractiveObjectScript>().Build(prefabObject, clickedPlace, grid);
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (keySelectedInstrument != '2') { keySelectedInstrument = '2'; }
            else { keySelectedInstrument = ' '; }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (keySelectedInstrument != 'E') { keySelectedInstrument = 'E'; }
            else { keySelectedInstrument = ' '; }
        }

    }
}