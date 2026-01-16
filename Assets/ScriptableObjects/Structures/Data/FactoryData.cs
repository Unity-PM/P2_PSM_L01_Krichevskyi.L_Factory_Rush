using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Factory", menuName = "Scriptable Objects/Structure/Factory")]
public class FactoryData : ScriptableObject
{
    public string title = "Factory";
    public int maxHp = 700;
    public Vector2Int sizeInCells = new Vector2Int(3, 3);
    public float productionSpeedScale = 1.0f;

    public List<ItemData> inputItemList;
    public List<RecipeData> recipeList;
    public float consumeElectricityAmount = 4500;
}
