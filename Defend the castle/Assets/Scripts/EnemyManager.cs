using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private List<Image> healthbars = new List<Image>();

    [SerializeField] private float attackRange;
    [SerializeField] private float detectionRange;

    private float currentCooldown = 0;

    private EnemyHealth enemyHealth;
    private SpriteRenderer spriteRenderer;

    private PhotonView pv;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        HandleCoolDown();
    }

    private void HandleCoolDown()
    {
        if (currentCooldown != 0)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void SetVisible(bool isVisible)
    {
        spriteRenderer.enabled = isVisible;

        foreach (Image healthbar in healthbars)
        {
            healthbar.enabled = isVisible;
        }
    }

    public EnemyStats Stats { get => stats; private set => stats = value; }
    public float AttackRange { get => attackRange; private set => attackRange = value; }
    public float DetectionRange { get => detectionRange; private set => detectionRange = value; }
    public EnemyHealth EnemyHealth { get => enemyHealth; set => enemyHealth = value; }

    public float CurrentCooldown { get => currentCooldown; set => currentCooldown = value; }
    public PhotonView PV { get => pv; private set => pv = value; }
}
