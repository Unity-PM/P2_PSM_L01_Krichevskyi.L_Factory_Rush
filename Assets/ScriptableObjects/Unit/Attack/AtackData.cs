using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack/Attack")]
public class AtackData : ScriptableObject
{
    [Header("General")]
    public float damage = 10f;
    public float cooldown = 1f;
    public float range = 1.5f;
}
