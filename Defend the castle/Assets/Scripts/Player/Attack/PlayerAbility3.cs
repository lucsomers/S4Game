using UnityEngine;
using System.Collections;
using System;

public class PlayerAbility3 : PlayerAttack
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

        if (playerController.PlayerInput.Ability3)
        {
            if (CurrentCooldown <= 0)
            {
                CheckNetworkSync(playerController);
                DoAttack(playerController.PlayerClass.CurrentPlayerClass.Ability3, playerController);
            }
        }
    }

    private void CheckNetworkSync(PlayerController playerController)
    {
        if (GameData.instance.Multiplayer)
        {
            if (playerController.PlayerNetwork.PV.IsMine)
            {
                playerController.PlayerNetwork.Ability3();
            }
        }
    }
}
