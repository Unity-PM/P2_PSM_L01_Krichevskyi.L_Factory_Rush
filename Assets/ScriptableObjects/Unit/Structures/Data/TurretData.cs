using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "Scriptable Objects/Structure/Turret")]
public class TurretData : ScriptableObject
{
    public int maxHp = 900;
    public Vector2Int sizeInCells = new Vector2Int(3, 3);
    public float damageScale = 1.0f;

    public List<ItemData> inputItemList;
    public int consumeElectricityAmount = 3000;
}
