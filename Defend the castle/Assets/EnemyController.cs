using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    private EnemyTargeting enemyTargeting;
    private EnemyAttackRange enemyAttackRange;
    private EnemyAttack enemyAttack;

    private Animator animator;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyTargeting = GetComponentInChildren<EnemyTargeting>();
        enemyAttackRange = GetComponentInChildren<EnemyAttackRange>();
        enemyAttack = GetComponentInChildren<EnemyAttack>();
        enemyHealth = GetComponentInChildren<EnemyHealth>();
    }

    public EnemyStats Stats { get => stats; private set => stats = value; }
    public EnemyTargeting EnemyTargeting { get => enemyTargeting; private set => enemyTargeting = value; }
    public EnemyAttackRange EnemyAttackRange { get => enemyAttackRange; private set => enemyAttackRange = value; }
    public Animator Animator { get => animator; private set => animator = value; }
    public EnemyAttack EnemyAttack { get => enemyAttack; private set => enemyAttack = value; }
    public EnemyHealth EnemyHealth { get => enemyHealth; private set => enemyHealth = value; }
}
