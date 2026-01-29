using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : InteractiveObjectScript, IStrCanProduce, IStrCanTake, IStrConsumeElectricity
{
    [SerializeField] public FactoryData data;

    private void Start()
    {
        currHp = data.maxHp;
    }

    public void ProduceItem()
    {
        Debug.Log("ProduceItem() called from FactoryScript");
    }
    public void TakeItem()
    {
        Debug.Log("TakeItem() called from FactoryScript");
    }
    public void ConsumeElectricity()
    {
        Debug.Log("ConsumeElectricity() called from FactoryScript");
    }

    public override string GetDisplayName()
    {
        return data.title;
    }
    public override Vector2Int GetSizeInCells()
    {
        return data.sizeInCells;
    }
}
