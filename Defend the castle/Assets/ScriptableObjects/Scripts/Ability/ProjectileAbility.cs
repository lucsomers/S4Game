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
        Vector3 startpos = player.transform.position;

        Vector3 target = player.PlayerInput.MousePos;

        ProjectileManager.instance.CreateProjectile(startpos, target, projectileStats);
    }
}
