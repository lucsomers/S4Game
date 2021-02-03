using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : EnemyState
{
    [SerializeField] private LayerMask targetableLayers;

    private bool OutSideOfAttackRange = false;

    private PlayerController currentPlayerFocus;

    private float currentCooldown = 0;

    public override void StartState()
    {
        base.StartState();

        currentPlayerFocus = GetComponentInParent<EnemyStateMachine>().CurrentPlayerFocus;

        OutSideOfAttackRange = false;

    }

    public override void UpdateState()
    {
        base.UpdateState();

        bool seeplayer = SeePlayer();

        if (seeplayer)
        {
            Manager.EnemyAnimator.Attack();
            //We see player in attack range
            Attack();
        }

        if (PlayerOutsideOfAttackRange() || !seeplayer)
        {
            //Player is out of range
            OutSideOfAttackRange = true;
        }
    }

    public override bool CheckForStateEnd()
    {
        //If we are outside of attackrange we go back to moving towards player
        return OutSideOfAttackRange;
    }

    private bool PlayerOutsideOfAttackRange()
    {
        bool playerOutsideRange = true;
        RaycastHit2D[] hits = Physics2D.RaycastAll(Manager.transform.position, currentPlayerFocus.transform.position - Manager.transform.position, Manager.AttackRange, targetableLayers);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player") && !currentPlayerFocus.Invisible)
            {
                playerOutsideRange = false;
                break;
            }
        }

        return playerOutsideRange;
    }

    private void Attack()
    {
        if (Manager.CurrentCooldown == 0)
        {
            Manager.CurrentCooldown = Manager.Stats.AttackSpeed;

            Vector3 Target = CalculateAimOfset();

            Manager.Attack(Target);
        }
    }

    private Vector3 CalculateAimOfset()
    {
        Vector3 playerTargetPos = currentPlayerFocus.transform.position;

        float x_offset = UnityEngine.Random.Range(Manager.Stats.Min_offset, Manager.Stats.Max_offset);
        float y_offset = UnityEngine.Random.Range(Manager.Stats.Min_offset, Manager.Stats.Max_offset);

        return new Vector3(playerTargetPos.x + x_offset, playerTargetPos.y + y_offset, playerTargetPos.z);
    }

    private bool SeePlayer()
    {
        return (LineOfSight.CanSeePlayer(Manager,Manager.transform.position, currentPlayerFocus, targetableLayers, Manager.AttackRange));
    }
}
