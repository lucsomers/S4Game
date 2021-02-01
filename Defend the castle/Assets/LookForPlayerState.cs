using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : EnemyState
{
    [SerializeField] private LayerMask targetableLayers;

    private bool PlayerInSight = false;

    private EnemyStateMachine enemyStateMachine;

    public override void StartState()
    {
        base.StartState();

        enemyStateMachine = GetComponentInParent<EnemyStateMachine>();

        PlayerInSight = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ShootRay();
    }

    private void ShootRay()
    {
        foreach (PlayerController player in SetupManager.instance.PlayersInGame)
        {
            RaycastHit2D hit = Physics2D.Raycast(Manager.transform.position, player.transform.position - Manager.transform.position, Manager.DetectionRange, targetableLayers);
            
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player") && !player.Invisible)
                {
                    PlayerInSight = true;
                    Manager.SetVisible(true);
                    enemyStateMachine.CurrentPlayerFocus = player;
                }
                else
                {
                    PlayerInSight = false;

                    if (!player.Invisible)
                    {
                        Manager.SetVisible(false);
                    }
                    enemyStateMachine.CurrentPlayerFocus = null;
                }
            }
        }
    }

    public override bool CheckForStateEnd()
    {
        return PlayerInSight;
    }
}
