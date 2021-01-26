﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;

    private int currentPlayerHealth = 0;
    private int maxPlayerHealth = 0;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        maxPlayerHealth = playerController.PlayerClass.CurrentPlayerClass.classStats.BaseHealth;
        currentPlayerHealth = maxPlayerHealth;
    }

    public void HealPlayer(int amount)
    {
        currentPlayerHealth += amount;

        NormalizeHealthValue();

        CheckDeath();
    }

    public void DealDamage(int amount)
    {
        currentPlayerHealth -= amount;

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentPlayerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        playerController.gameObject.SetActive(false);
    }

    private void NormalizeHealthValue()
    {
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }

        if (currentPlayerHealth < 0)
        {
            currentPlayerHealth = 0;
        }
    }
}
