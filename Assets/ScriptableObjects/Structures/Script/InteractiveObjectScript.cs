using System.Drawing;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class InteractiveObjectScript : StructureScript, IStrCanBuild, IStrCanMove
{
    public virtual void Build(GameObject prefab, Vector3 clickedPlace, GridScript grid)
    {
        //Debug.Log("Build() called from InteractiveObjectScript");

        Vector2Int prefabSize;
        if (prefab.name.StartsWith("Belt")) { prefabSize = prefab.GetComponent<BeltScript>().data.sizeInCells; }
        else if (prefab.name.StartsWith("Factory")) { prefabSize = prefab.GetComponent<FactoryScript>().data.sizeInCells; }
        else { prefabSize = new Vector2Int(1, 1); }

        int clickedX = 0;
        int clickedZ = 0;
        if (CheckPlace(prefab, clickedPlace, grid, prefabSize, out clickedX, out clickedZ))
        {
            GameObject obj = GameObject.Instantiate(prefab, grid.GetWorldPositionToBuild(clickedX, clickedZ, prefabSize), Quaternion.identity);
            StructureScript structure = obj.GetComponent<StructureScript>();
            for (int x = 0; x < prefabSize.x; x++)
            {
                for (int z = 0; z < prefabSize.y; z++)
                {
                    Vector2Int pos = new Vector2Int(clickedX + x, clickedZ + z);
                    grid.PlaceObject(pos, structure);
                }
            }

        }
        else
        {
            Debug.LogWarning("You can't build here!");
        }
    }
    public bool CheckPlace(GameObject prefab, Vector3 clickedPlace, GridScript grid, Vector2Int prefabSize, out int clickedX, out int clickedZ)
    {
        //Debug.Log("CheckPlace() called from InteractiveObjectScript");

        bool isInGrid = grid.GetXY(clickedPlace, out clickedX, out clickedZ);
        Vector2Int inVectorPosition = new Vector2Int(clickedX, clickedZ);
        if (!isInGrid)
        {
            return false;
        }


        if (clickedX >= grid.GetWidth() || clickedX < 0 ||
            clickedZ >= grid.GetHeight() || clickedZ < 0) { return false; }
        for (int x = 0; x < prefabSize.x; x++)
        {
            for (int z = 0; z < prefabSize.y; z++)
            {
                Vector2Int checkPos = inVectorPosition + new Vector2Int(x, z);
                if (checkPos.x < 0 || checkPos.y < 0 || checkPos.x >= grid.GetWidth() ||
                    checkPos.y >= grid.GetHeight()) { return false; }

                if (!grid.IsCellEmpty(checkPos)) { return false; }
            }
        }

        return true;
    }

    public void Move()
    {
        Debug.Log("Move() called from InteractiveObjectScript");
    }
}
