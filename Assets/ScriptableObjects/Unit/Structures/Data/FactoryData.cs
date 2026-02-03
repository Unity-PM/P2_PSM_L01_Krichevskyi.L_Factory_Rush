using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Factory", menuName = "Scriptable Objects/Structure/Factory")]
public class FactoryData : InteractiveObjectData
{
    public float productionSpeedScale;

    public List<ItemData> inputItemList;
    public List<RecipeData> recipeList;
    public float consumeElectricityAmount;
}
