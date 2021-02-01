using System;
using UnityEngine;

public class ProjectileHitHandler : MonoBehaviour
{
    private Projectile projectile;

    private void Start()
    {
        projectile = GetComponentInParent<Projectile>();
    }

    public void HandlePlayerHit(PlayerController playerController, Projectile projectile)
    {
        if (projectile.Stats.IsHealing)
        {
            playerController.PlayerHealth.HealPlayer(projectile.Stats.Damage);
        }
        else
        {
            playerController.PlayerHealth.DealDamage(projectile.Stats.Damage);
        }
    }

    public void HandleEnemyHit(EnemyManager enemyController, Projectile projectile)
    {
        if (projectile.Stats.IsHealing)
        {
            enemyController.EnemyHealth.HealEnemy(projectile.Stats.Damage);
        }
        else
        {
            enemyController.EnemyHealth.DealDamage(projectile.Stats.Damage);
        }
    }
}