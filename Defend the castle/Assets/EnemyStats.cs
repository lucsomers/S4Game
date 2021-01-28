using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyStats", menuName = "New EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string enemyName;

    [Header("Stats")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float min_offset;
    [SerializeField] private float max_offset;

    [Header("Attack")]
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private float attackSpeed;
    [SerializeField] private ProjectileStats projectileStats;
    [SerializeField] private EnemyAbility enemyAbility;

    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public int MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public string EnemyName { get => enemyName; private set => enemyName = value; }
    public float AttackSpeed { get => attackSpeed; private set => attackSpeed = value; }
    public ProjectileStats ProjectileStats { get => projectileStats; set => projectileStats = value; }
    public string TargetTag { get => targetTag; private set => targetTag = value; }
    public EnemyAbility EnemyAbility { get => enemyAbility; private set => enemyAbility = value; }
    public float Min_offset { get => min_offset; set => min_offset = value; }
    public float Max_offset { get => max_offset; set => max_offset = value; }
}
