using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAbility : EnemyAbility
{
    public override void HandleAbility(EnemyController enemyController)
    {
        base.HandleAbility(enemyController);

        FireProjectile(enemyController);
    }

    private void FireProjectile(EnemyController enemyController)
    {
        Projectile ToFire = ProjectileManager.instance.GetAvailableProjectile();

        //Set pos
        ToFire.transform.position = enemyController.transform.position;

        //Set active
        ToFire.gameObject.SetActive(true);

        //Set stats for collision
        ToFire.SetStats(enemyController.Stats.ProjectileStats);

        //Calculate the aimofset of the enemy
        Vector3 aimpoint = CalculateAimOfset(enemyController);

        //Set target for our projectile
        ToFire.ProjectileMover.SetTarget(aimpoint);
    }

    private Vector3 CalculateAimOfset(EnemyController enemyController)
    {
        Vector3 playerTargetPos = enemyController.EnemyTargeting.PlayerTarget.position;

        float x_offset = UnityEngine.Random.Range(enemyController.Stats.Min_offset, enemyController.Stats.Max_offset);
        float y_offset = UnityEngine.Random.Range(enemyController.Stats.Min_offset, enemyController.Stats.Max_offset);

        return new Vector3(playerTargetPos.x + x_offset, playerTargetPos.y + y_offset, playerTargetPos.z);
    }
}
