using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSelfAbility : Ability
{
    [SerializeField] private int healingAmount;

    public override void HandleAbility(PlayerController player)
    {
        base.HandleAbility(player);

        player.PlayerHealth.HealPlayer(healingAmount);
    }
}
