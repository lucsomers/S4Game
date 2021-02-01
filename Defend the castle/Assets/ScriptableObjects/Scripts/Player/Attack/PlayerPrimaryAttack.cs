using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerAttack
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

        if (playerController.PlayerInput.LeftMouseButtonDown)
        {
            if (CurrentCooldown <= 0)
            {
                CheckNetworkSync(playerController);
                DoAttack(playerController.PlayerClass.CurrentPlayerClass.PrimaryAttack, playerController);
            }
        }
    }

    private void CheckNetworkSync(PlayerController playerController)
    {
        if (GameData.instance.Multiplayer)
        {
            if (playerController.PlayerNetwork.PV.IsMine)
            {
                playerController.PlayerNetwork.PrimaryAttack();
            }
        }
    }
}
