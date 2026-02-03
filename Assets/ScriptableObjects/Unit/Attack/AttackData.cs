using UnityEngine;

[System.Serializable]
public class AttackData
{
    [Header("General")]
    public float damage = 10f;
    public float cooldown = 1f;
    public float range = 1.5f;
}
