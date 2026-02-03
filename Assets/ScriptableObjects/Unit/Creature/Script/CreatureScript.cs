using System;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreatureScript : UnitScript, IDamageable
{
    public event Action OnDeath;

    protected override void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
