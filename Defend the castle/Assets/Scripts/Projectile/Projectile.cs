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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        projectileMover = GetComponent<ProjectileMover>();
        projectileSpawner = GetComponent<ProjectileSpawner>();
        hitHandler = GetComponent<ProjectileHitHandler>();
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

    public ProjectileStats Stats { get => stats; private set => stats = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; private set => spriteRenderer = value; }
    public Vector2 Target { get => target; set => target = value; }
    public bool IsMoving { get => isMoving; private set => isMoving = value; }
    public ProjectileMover ProjectileMover { get => projectileMover; set => projectileMover = value; }
    public ProjectileSpawner ProjectileSpawner { get => projectileSpawner; set => projectileSpawner = value; }
    public ProjectileHitHandler HitHandler { get => hitHandler; set => hitHandler = value; }
}