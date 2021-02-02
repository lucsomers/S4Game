using System;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private AbilityStats stats;

    private float currentCooldown;

    public virtual void HandleAbility(PlayerController player)
    {
        StartCooldown();
    }

    public virtual void Update()
    {
        UpdateCooldown();
    }

    private void StartCooldown()
    {
        currentCooldown = stats.Cooldown;
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
    public AbilityStats Stats { get => stats; private set => stats = value; }
}