using System;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int amount);
    event Action OnDeath;
}
