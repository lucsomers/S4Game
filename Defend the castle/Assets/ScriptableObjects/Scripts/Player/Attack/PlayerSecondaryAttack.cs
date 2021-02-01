using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondaryAttack : PlayerAttack
{
    private PlayerController playerController;

    private PlayerClass currentPlayerClass;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        currentPlayerClass = playerController.PlayerClass;
    }

    public override void Update()
    {
        base.Update();
        
        if (playerController.PlayerInput.RightMouseButtonDown)
        {
            if (CurrentCooldown <= 0)
            {
                DoAttack(playerController.PlayerClass.CurrentPlayerClass.SecondaryAttack, playerController);
            }
        }
    }
}
