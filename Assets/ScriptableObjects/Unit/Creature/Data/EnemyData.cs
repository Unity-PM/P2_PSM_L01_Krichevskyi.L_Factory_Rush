using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy/Enemy")]
public class EnemyData : ScriptableObject
{
    public string title = "unknown enemy";
    public int maxHp;
    public float moveSpeed;
    List<PriorityGroupData> priorities;
}
