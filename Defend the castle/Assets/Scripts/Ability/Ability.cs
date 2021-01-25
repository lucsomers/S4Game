﻿using System;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private AbilityStats stats;

    [HideInInspector]
    public string AbilityName;
    [HideInInspector]
    public string AbilityDescription;
    [HideInInspector]
    public float Cooldown;
    [HideInInspector]
    public Sprite Icon;

    private float currentCooldown;

    public Ability(AbilityStats stats)
    {
        this.stats = stats;
        AbilityName = stats.AbilityName;
        AbilityDescription = stats.AbilityDescription;
        Cooldown = stats.Cooldown;
        Icon = stats.Icon;
    }

    public virtual void HandleAbility()
    {
        StartCooldown();
    }

    public virtual void Update()
    {
        UpdateCooldown();
    }

    private void StartCooldown()
    {
        currentCooldown = Cooldown;
    }

    private void UpdateCooldown()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }
    }

    public float CurrentCooldown { get => currentCooldown; private set => currentCooldown = value; }
}