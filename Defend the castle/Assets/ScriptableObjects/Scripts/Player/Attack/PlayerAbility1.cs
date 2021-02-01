using UnityEngine;
using System.Collections;

public class PlayerAbility1 : PlayerAttack
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

        if (playerController.PlayerInput.Ability1)
        {
            if (CurrentCooldown <= 0)
            {
                CheckNetworkSync(playerController);
                DoAttack(playerController.PlayerClass.CurrentPlayerClass.Ability1, playerController);
            }
        }
    }

    private void CheckNetworkSync(PlayerController playerController)
    {
        if (GameData.instance.Multiplayer)
        {
            if (playerController.PlayerNetwork.PV.IsMine)
            {
                playerController.PlayerNetwork.Ability1();
            }
        }
    }
}
