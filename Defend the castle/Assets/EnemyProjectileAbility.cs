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
        //Calculate the aimofset of the enemy
        Vector3 target = CalculateAimOfset(enemyController);

        ProjectileManager.instance.CreateProjectile(enemyController.transform.position, target,enemyController.Stats.ProjectileStats);
    }

    

    private Vector3 CalculateAimOfset(EnemyController enemyController)
    {
        Vector3 playerTargetPos = enemyController.EnemyTargeting.PlayerTarget.position;

        float x_offset = UnityEngine.Random.Range(enemyController.Stats.Min_offset, enemyController.Stats.Max_offset);
        float y_offset = UnityEngine.Random.Range(enemyController.Stats.Min_offset, enemyController.Stats.Max_offset);

        return new Vector3(playerTargetPos.x + x_offset, playerTargetPos.y + y_offset, playerTargetPos.z);
    }
}
