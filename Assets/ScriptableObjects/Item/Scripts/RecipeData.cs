using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Item/Recipe")]
public class RecipeData : ScriptableObject
{
    [Header("Input Items")]
    public List<ItemData> inputItemList;
    public List<int> inputCount;

    [Header("Output Items")]
    public List<ItemData> outputItemList;
    public List<int> outputCount;

    [Header("Production Parameters")]
    public string title = "empty recipe";
    public float productionTime = 1f;
    public float electricityCost = 1f;

    //[Header("Optional")]
    //public Sprite icon;
}
