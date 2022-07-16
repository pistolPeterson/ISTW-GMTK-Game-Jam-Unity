using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsObject", menuName = "SO/EnemyStats")]
public class EnemySO : ScriptableObject
{
    [SerializeField] [Range(0.25f, 5f)]  public float chaseSpeed;
    [SerializeField] [Range(0.1f, 2f)] public float idleSpeed;
    [SerializeField] [Range(50, 150)] public int health;
    [SerializeField] [Range(15, 75)] public int attackAmount;
    [SerializeField] [Range(1f, 10f)] public float attackSpeed;
    [SerializeField] [Range(5f, 25f)] public float chaseRadius;
}
