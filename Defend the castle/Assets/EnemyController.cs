using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private List<Image> healthbars = new List<Image>();

    private SpriteRenderer renderer;

    private EnemyTargeting enemyTargeting;
    private EnemyAttackRange enemyAttackRange;
    private EnemyAttack enemyAttack;

    private Animator animator;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyTargeting = GetComponentInChildren<EnemyTargeting>();
        enemyAttackRange = GetComponentInChildren<EnemyAttackRange>();
        enemyAttack = GetComponentInChildren<EnemyAttack>();
        enemyHealth = GetComponentInChildren<EnemyHealth>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void SetVisible(bool isVisible)
    {
        renderer.enabled = isVisible;

        foreach (Image healthbar in healthbars)
        {
            healthbar.enabled = isVisible;
        }
    }

    public EnemyStats Stats { get => stats; private set => stats = value; }
    public EnemyTargeting EnemyTargeting { get => enemyTargeting; private set => enemyTargeting = value; }
    public EnemyAttackRange EnemyAttackRange { get => enemyAttackRange; private set => enemyAttackRange = value; }
    public Animator Animator { get => animator; private set => animator = value; }
    public EnemyAttack EnemyAttack { get => enemyAttack; private set => enemyAttack = value; }
    public EnemyHealth EnemyHealth { get => enemyHealth; private set => enemyHealth = value; }

    public bool IsVisible { get => renderer.enabled; }
}
