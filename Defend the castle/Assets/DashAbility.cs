using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;

    public override void HandleAbility(PlayerController player)
    {
        base.HandleAbility(player);

        player.PlayerMovement.DashPlayer(dashPower, dashTime);
    }
}
