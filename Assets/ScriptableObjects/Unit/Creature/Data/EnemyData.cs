using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemies/Enemy")]
public class EnemyData : ScriptableObject
{
    public string title = "unknown enemy";
    public int maxHp = 600;
    public float moveSpeed;
    public float attackSpeed;
}
