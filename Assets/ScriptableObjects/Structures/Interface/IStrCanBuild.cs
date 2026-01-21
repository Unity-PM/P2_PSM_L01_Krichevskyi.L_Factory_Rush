using System.Collections.Generic;
using UnityEngine;

public interface IStrCanBuild
{
    public bool PlaceObject(CardData card, Vector3 worldPosition);
    public bool CheckPlace(Vector3 worldPosition, Vector2Int size, out List<Vector2Int> resultCells);
}
