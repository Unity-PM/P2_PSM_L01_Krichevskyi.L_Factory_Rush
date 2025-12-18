using UnityEngine;
using UnityEngine.InputSystem;

public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] private HeatMapVisual heatMapVisual;
    private Grid grid;
    void Start()
    {
        grid = new Grid(10,10, 5f, new Vector3(0,0,0));
        heatMapVisual.SetGrid(grid);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData) && Input.GetMouseButtonDown(0))
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
        }



    }
}