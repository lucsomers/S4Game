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

        currentCooldown = 0;

        OutSideOfAttackRange = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        HandleCoolDown();

        bool seeplayer = SeePlayer();

        if (seeplayer)
        {
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

    private void HandleCoolDown()
    {
        if (currentCooldown != 0)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }
    }

    private void Attack()
    {
        if (currentCooldown == 0)
        {
            currentCooldown = Manager.Stats.AttackSpeed;

            Vector3 Target = CalculateAimOfset();

            ProjectileManager.instance.CreateProjectile(Manager.transform.position, Target, Manager.Stats.ProjectileStats);
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
        bool playerInLineOfSight = false;

        RaycastHit2D hit = Physics2D.Raycast(Manager.transform.position, currentPlayerFocus.transform.position - Manager.transform.position, Manager.AttackRange, targetableLayers);
        
        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Player") && !currentPlayerFocus.Invisible)
            {
                playerInLineOfSight = true;
                Manager.SetVisible(true);
            }
            else
            {
                playerInLineOfSight = false; 

                if (!currentPlayerFocus.Invisible)
                {
                    Manager.SetVisible(false);
                }
            }
        }

        return playerInLineOfSight;
    }
}
