using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private Projectile projectile;

    private Collider2D collider;

    private float timeBetweenCollisions = 0.3f;
    private float currentTimeBetweenCollisions = 0f;

    private bool canCollide = true;
    private bool isColliding = false;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!canCollide)
        {
            currentTimeBetweenCollisions += Time.deltaTime;

            if (currentTimeBetweenCollisions >= timeBetweenCollisions)
            {
                currentTimeBetweenCollisions = 0;
                canCollide = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other, false);
    }

    public void HandleCollision(Collider2D other, bool FromAOE)
    {
        if (canCollide && !projectile.Stats.IsAOE || FromAOE)
        {
            if (other.CompareTag(projectile.Stats.TargetAbleTags))
            {
                if (projectile.Stats.DestroyOnImpact)
                {
                    canCollide = false;
                    projectile.DestroySelf();
                }

                HandleHit(other);

                if (projectile.Stats.SpawnObjectAtCollision)
                {
                    projectile.ProjectileSpawner.SpawnObject();
                }
            }

            if (other.CompareTag("Wall") || other.CompareTag("Obstacle"))
            {
                if (!projectile.Stats.IgnoresWalls)
                {
                    projectile.DestroySelf();
                }
                               
                if (projectile.Stats.SpawnObjectAtCollision)
                {
                    projectile.ProjectileSpawner.SpawnObject();
                }
            }
        }
    }

    private void HandleHit(Collider2D other)
    {
        PlayerController playerHit = other.GetComponent<PlayerController>();
        EnemyManager enemyHit = other.GetComponent<EnemyManager>();

        if (playerHit != null)
        {
            //Player has been hit
            projectile.HitHandler.HandlePlayerHit(playerHit, projectile);
        }
        else if (enemyHit != null)
        {
            //Enemy has been hit
            projectile.HitHandler.HandleEnemyHit(enemyHit, projectile);
        }
    }

    public void SetActiveCollider(bool value)
    {
        collider.enabled = value;
    }
}
