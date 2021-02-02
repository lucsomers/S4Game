using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectileStats stats;

    private SpriteRenderer spriteRenderer;

    private Vector2 target;

    private bool isMoving = false;

    private ProjectileMover projectileMover;
    private ProjectileSpawner projectileSpawner;
    private ProjectileHitHandler hitHandler;
    private ProjectileAOEHandler aOEHandler;
    private ProjectileCollision projectileCollision;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        projectileMover = GetComponent<ProjectileMover>();
        projectileSpawner = GetComponent<ProjectileSpawner>();
        hitHandler = GetComponent<ProjectileHitHandler>();
        aOEHandler = GetComponentInChildren<ProjectileAOEHandler>();
        projectileCollision = GetComponent<ProjectileCollision>();
    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }

    public void SetStats(ProjectileStats stats)
    {
        this.stats = stats;
        spriteRenderer.sprite = stats.ProjectileSprite;
    }

    private void OnEnable()
    {
        if (Stats != null)
        {
            if (Stats.IsAOE)
            {
                AOEHandler.Turn_On_AOE();
            }
        }
    }

    private void OnDisable()
    {
        if (Stats != null)
        {
            if (Stats.IsAOE)
            {
                AOEHandler.Turn_Off_AOE();
            }
        }
    }

    public ProjectileStats Stats { get => stats; private set => stats = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; private set => spriteRenderer = value; }
    public Vector2 Target { get => target; set => target = value; }
    public bool IsMoving { get => isMoving; private set => isMoving = value; }
    public ProjectileMover ProjectileMover { get => projectileMover; set => projectileMover = value; }
    public ProjectileSpawner ProjectileSpawner { get => projectileSpawner; set => projectileSpawner = value; }
    public ProjectileHitHandler HitHandler { get => hitHandler; set => hitHandler = value; }
    public ProjectileAOEHandler AOEHandler { get => aOEHandler; set => aOEHandler = value; }
    public ProjectileCollision ProjectileCollision { get => projectileCollision; set => projectileCollision = value; }
}