using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private const float minimumCooldown = 0.2f;

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

        currentCooldown = getModifiedCooldown(ability);
    }

    private float getModifiedCooldown(Ability ability)
    {
        float toReturn = ability.Stats.Cooldown;

        switch (ability.Stats.AbilityLetter)
        {
            case AbilityLetter.Q_1:
            case AbilityLetter.W_2:
            case AbilityLetter.F_3:
                toReturn = ModifierManager.instance.GetModifiedCooldown(ability.CurrentCooldown);
                break;
            case AbilityLetter.Primary:
            case AbilityLetter.Secondary:
                toReturn = ModifierManager.instance.GetModifiedAttackSpeed(ability.CurrentCooldown);
                break;
        }

        if (toReturn < minimumCooldown)
        {
            toReturn = minimumCooldown;
        }

        return toReturn;
    }

    public float CurrentCooldown { get => currentCooldown; private set => currentCooldown = value; }
}
