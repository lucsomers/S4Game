using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController playerController;

    private PlayerClass playerClass;

    private float attackSpeedTimer;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        playerClass = playerController.PlayerClass;
    }

    void Update()
    {
        HandleAttackSpeedTimer();

        if (playerController.PlayerInput.LeftMouseButtonDown)
        {
            if (attackSpeedTimer <= 0)
            {
                DoBasicAttack();
            }
        }

    }

    private void HandleAttackSpeedTimer()
    {
        attackSpeedTimer -= Time.deltaTime;

        if (attackSpeedTimer < 0)
        {
            attackSpeedTimer = 0;
        }
    }

    private void DoBasicAttack()
    {
        playerClass.CurrentPlayerClass.PrimaryAttack.HandleAbility();

        attackSpeedTimer = playerClass.CurrentPlayerClass.AttackSpeed;
    }
}
