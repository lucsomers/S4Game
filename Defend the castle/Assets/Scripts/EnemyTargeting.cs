using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    [SerializeField] private LayerMask ignoredLayers;

    private EnemyController enemyController;

    private Transform currentTarget;
    private Transform playerTarget;

    private int playersInZone = 0;
    
    private bool playerInSight = false;
    private bool canShoot;
    private bool getNextTarget = false;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            playersInZone--;

            if (playersInZone <= 0)
            {
                playersInZone = 0;
                currentTarget = null;
                playerTarget = null;
                playerInSight = false;
                enemyController.SetVisible(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            CheckIfPlayerInSight(player);

            if (playerInSight)
            {
                if (currentTarget == null || currentTarget.CompareTag("Node"))
                {
                    currentTarget = player.PlayerTargetPoints.GetRandomTargetPoint();
                    playerTarget = player.transform;
                    canShoot = true;
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    if (!currentTarget.CompareTag("Node"))
                    {
                        currentTarget = AINodeManager.instance.GetClosesedNode(player.transform);
                        playerTarget = player.transform;
                    }
                }
            }
        }
    }

    private void CheckIfPlayerInSight(PlayerController player)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 100f, ignoredLayers);

        if (hit.transform.CompareTag("Player") && !player.Invisible)
        {
            playerInSight = true;
            enemyController.SetVisible(true);
        }
        else
        {
            playerInSight = false;
            canShoot = false;
            if (!player.Invisible)
            {
                enemyController.SetVisible(false);
            }
        }
    }

    public Transform CurrentTarget { get => currentTarget; private set => currentTarget = value; }
    public Transform PlayerTarget { get => playerTarget; private set => playerTarget = value; }
    public bool CanShoot { get => canShoot; private set => canShoot = value; }
}