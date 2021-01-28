using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    private Transform currentTarget;

    private Transform playerTarget;

    private bool getNextTarget = false;

    private int playersInZone = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();


        if (player != null)
        {
            playersInZone++;
            currentTarget = player.PlayerTargetPoints.GetRandomTargetPoint();
            playerTarget = player.transform;
        }
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
            }
            else
            {
                getNextTarget = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (getNextTarget)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                currentTarget = player.PlayerTargetPoints.GetRandomTargetPoint();
                playerTarget = player.transform;
                getNextTarget = false;
            }
        }
    }

    public Transform CurrentTarget { get => currentTarget; private set => currentTarget = value; }
    public Transform PlayerTarget { get => playerTarget; private set => playerTarget = value; }
}