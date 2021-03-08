using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{
    [SerializeField] private ProjectileStats projectileStats;

    public override void HandleAbility(PlayerController player)
    {
        player.PlayerAnimator.Attack();

        base.HandleAbility(player);

        StartCoroutine(DelayedAttack(player));
    }

    private IEnumerator DelayedAttack(PlayerController player)
    {
        yield return new WaitForSeconds(player.PlayerClass.CurrentPlayerClass.classStats.AttackDelay);
        FireProjectile(player);
    }

    private void FireProjectile(PlayerController player)
    {
        Vector3 startpos = player.transform.position;
        Vector3 target;

        if (player.PlayerNetwork.PV.IsMine || !GameData.instance.Multiplayer)
        {
            target = player.PlayerInput.MousePos;
        }
        else
        {
            target = player.PlayerInput.LastGivenMousePos;
        }

        ProjectileManager.instance.CreateProjectile(startpos, target, projectileStats);
    }
}
