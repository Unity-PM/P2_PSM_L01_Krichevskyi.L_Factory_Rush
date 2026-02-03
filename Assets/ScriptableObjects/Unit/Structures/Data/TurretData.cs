using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "Scriptable Objects/Structure/Turret")]
public class TurretData : InteractiveObjectData
{
    public int consumeElectricityAmount = 3000;
}
