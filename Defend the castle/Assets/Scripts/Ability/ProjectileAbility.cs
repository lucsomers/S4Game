using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{
    [SerializeField] private ProjectileStats projectileStats;

    public override void HandleAbility(PlayerController player)
    {
        base.HandleAbility(player);

        FireProjectile(player);
    }

    private void FireProjectile(PlayerController player)
    {
        Projectile ToFire = ProjectileManager.instance.GetAvailableProjectile();

        //Set pos
        ToFire.transform.position = player.transform.position;

        //Set active
        ToFire.gameObject.SetActive(true);

        //Set stats for collision
        ToFire.SetStats(projectileStats);
        
        //Set target for our projectile
        ToFire.ProjectileMover.SetTarget(player.PlayerInput.MousePos);
    }
}
