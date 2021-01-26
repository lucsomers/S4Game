using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float currentCooldown;

    public virtual void Update()
    {
        HandleAttackSpeedTimers();
    }

    private void HandleAttackSpeedTimers()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }
    }

    public void DoAttack(Ability ability, PlayerController playerController)
    {
        ability.HandleAbility(playerController);

        currentCooldown = ability.Stats.Cooldown;
    }

    public float CurrentCooldown { get => currentCooldown; private set => currentCooldown = value; }
}
