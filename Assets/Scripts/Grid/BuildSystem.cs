using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour, IStrCanBuild, IStrCanMove
{
    public static BuildManager Instance;
    public GridManager gridManager;
    private GridScript grid;

    private GameObject ghostObject;
    private CardData activeCard;
    private bool isBuilding = false;

    private void Awake()
    {
        GridManager.GridManagerLoaded += Load;
    }

    private void Load()
    {
        Instance = this;

        Debug.Log("Hi from BuildSystem.Load() function!");
        grid = gridManager.GetGrid();
    }

    public bool IsBuilding() => isBuilding;

    // Начало перетягивания карты
    public void StartBuild(CardData card)
    {
        activeCard = card;
        isBuilding = true;
        CreateGhost(card);
    }

    // Отмена строительства (отпустили вне сетки)
    public void CancelBuild()
    {
        if (!isBuilding) return;

        DestroyGhost();
        activeCard = null;
        isBuilding = false;
    }

    // Завершение строительства (отпустили над допустимой зоной)
    public void ConfirmBuild(Vector3 worldPosition)
    {
        if (!isBuilding) return;

        PlaceObject(activeCard, worldPosition);
        DestroyGhost();
        activeCard = null;
        isBuilding = false;
    }

    // Создать Ghost объекта
    private void CreateGhost(CardData card)
    {
        // ghostObject = Instantiate(card.prefab); и т.д.
    }

    // Удалить Ghost
    private void DestroyGhost()
    {
        if (ghostObject != null)
        {
            GameObject.Destroy(ghostObject);
            ghostObject = null;
        }
    }

    // Сама постройка объекта на карте
    public bool PlaceObject(CardData card, Vector3 worldPosition)
    {
        GameObject prefab = card.structurePrefab;
        StructureScript structure = prefab.GetComponent<StructureScript>();

        Vector2Int size = structure.GetSizeInCells();

        if (!CheckPlace(worldPosition, size, out List<Vector2Int> cells))
        {
            Debug.LogWarning("You can't build here!");
            return false;
        }

        GameObject obj = Instantiate(prefab, grid.GetWorldPositionToBuild(cells[0].x, cells[0].y, size), Quaternion.identity);

        StructureScript instance = obj.GetComponent<StructureScript>();
        instance.SetPositions(cells);

        foreach (var cell in cells)
            grid.PlaceObject(cell, instance);

        return true;
    }
    public bool CheckPlace(Vector3 worldPosition, Vector2Int size, out List<Vector2Int> resultCells)
    {
        resultCells = new List<Vector2Int>();

        if (!grid.GetXY(worldPosition, out int startX, out int startZ))
            return false;

        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.y; z++)
            {
                Vector2Int cell = new Vector2Int(startX + x, startZ + z);

                if (cell.x < 0 || cell.y < 0 ||
                    cell.x >= grid.GetWidth() ||
                    cell.y >= grid.GetHeight())
                    return false;

                if (!grid.IsCellEmpty(cell))
                    return false;

                resultCells.Add(cell);
            }
        }

        return true;
    }
    public void MoveObject()
    {

    }

    // Обновление позиции Ghost (вызывать из Update)
    public void UpdateGhostPosition(Vector3 worldPosition)
    {
        if (!isBuilding || ghostObject == null) return;

        ghostObject.transform.position = worldPosition;
    }

    
}
