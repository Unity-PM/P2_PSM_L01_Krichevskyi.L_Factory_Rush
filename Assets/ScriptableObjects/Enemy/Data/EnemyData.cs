using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Item/Enemy")]
public class EnemyData : ScriptableObject
{
    public string title = "unknown enemy";
    public int maxHp = 600;
    public float moveSpeed;
    public float attackSpeed;
}
