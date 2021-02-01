using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayerState : EnemyState
{
    [SerializeField] private LayerMask targetableLayers;

    private bool InAttackRange = false;
    private bool playerOutSideOfDetectionRange = false;

    private PlayerController currentPlayerFocus;

    Transform closestNode = null;

    private Transform pointToMoveTowards;

    private EnemyState savedNextState;

    public override void StartState()
    {
        base.StartState();

        currentPlayerFocus = GetComponentInParent<EnemyStateMachine>().CurrentPlayerFocus;

        pointToMoveTowards = currentPlayerFocus.PlayerTargetPoints.GetRandomTargetPoint();

        playerOutSideOfDetectionRange = false;
        InAttackRange = false;
        GoToDefaultState = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector3 posToMoveTo;

        bool inSight = PlayerInSight();

        float DistancePlayerEnemy = Vector3.Distance(currentPlayerFocus.transform.position, Manager.transform.position);

        //Check if we are in attack range
        if (DistancePlayerEnemy <= Manager.AttackRange)
        {
            if (inSight)
            {
                //We are in attack range
                InAttackRange = true;
            }
        }
        //Check if player is outside of detection range
        else if (DistancePlayerEnemy > Manager.DetectionRange)
        {
            playerOutSideOfDetectionRange = true;
        }

        //Check if we can see player
        if (inSight)
        {
            //Move enemy towards playerPos because we see player within range
            closestNode = null;
            posToMoveTo = Vector3.MoveTowards(Manager.transform.position, pointToMoveTowards.position, Manager.Stats.MoveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //Move enemy towards closest node because we are not seeing him
            if (closestNode == null)
            {
                closestNode = AINodeManager.instance.GetClosesedNode(currentPlayerFocus.transform);
            }

            posToMoveTo = Vector3.MoveTowards(Manager.transform.position, closestNode.position, Manager.Stats.MoveSpeed * Time.fixedDeltaTime);
        }

        posToMoveTo = new Vector3(posToMoveTo.x, posToMoveTo.y, 0);

        Manager.transform.position = posToMoveTo;
    }

    private bool PlayerInSight()
    {
        return (CanSeePlayer(Manager.transform.position, currentPlayerFocus, targetableLayers, Manager.DetectionRange));
    }

    public override bool CheckForStateEnd()
    {
        if (playerOutSideOfDetectionRange)
        {
            //if player is outside of range we start with default state again
            GoToDefaultState = true;
            return playerOutSideOfDetectionRange;
        }
        else
        {
            //Player is in attack range so we move on to next state
            return InAttackRange;
        }
    }
}
