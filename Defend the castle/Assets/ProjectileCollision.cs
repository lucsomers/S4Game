using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private Projectile projectile;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(projectile.Stats.TargetAbleTags))
        {
            HandleHit(other);

            if (projectile.Stats.SpawnObjectAtCollision)
            {
                projectile.ProjectileSpawner.SpawnObject();
            }

            if (projectile.Stats.DestroyOnImpact)
            {
                projectile.DestroySelf();
            }
        }
    }

    private void HandleHit(Collider2D other)
    {
        PlayerController playerHit = other.GetComponent<PlayerController>();
        EnemyController enemyHit = other.GetComponent<EnemyController>();

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
}
