using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : EnemyState
{
    [SerializeField] private LayerMask targetableLayers;

    private bool PlayerInSight = false;

    private EnemyStateMachine enemyStateMachine;

    private const float TimeBetweenRays = 1f;
    private float currentTime = 0;

    public override void StartState()
    {
        base.StartState();

        enemyStateMachine = GetComponentInParent<EnemyStateMachine>();

        PlayerInSight = false;

        Manager.EnemyAnimator.Move(false);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ShootRay();
    }

    private void ShootRay()
    {
        currentTime = 0;

        foreach (PlayerController player in SetupManager.instance.PlayersInGame)
        {
            if (LineOfSight.CanSeePlayer(Manager,Manager.transform.position, player, targetableLayers, Manager.DetectionRange))
            {
                PlayerInSight = true;
                enemyStateMachine.CurrentPlayerFocus = player;
                break;
            }
            else
            {
                PlayerInSight = false;
                enemyStateMachine.CurrentPlayerFocus = null;
            }
        }
    }

    public override bool CheckForStateEnd()
    {
        return PlayerInSight;
    }
}
