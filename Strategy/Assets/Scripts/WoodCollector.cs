﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollector : MonoBehaviour
{
    [SerializeField] private float TimeToChop;
    [SerializeField] private float AmountInPool;
    [Header("Collection Number")]
    [SerializeField] private GameObject CollectionNumber;
    [SerializeField] private Transform CollectionNumberSpawnPoint;

    private float currentTimeChopping = 0;

    private bool characterInRange = false;

    private void Update()
    {
        if (characterInRange)
        {
            //there is a character in range to chop wood
            if (TimeToChop > currentTimeChopping)
            {
                //Keep chopping
                currentTimeChopping += Time.deltaTime;
            }
            else
            {
                //CollectWood
                CollectWood();
            }
        }
        else
        {
            //reset timer
            ResetTimer();
        }

        if (AmountInPool <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CollectWood()
    {
        //Create floating number
        GameObject tempCollectionNumber = Instantiate(CollectionNumber);
        tempCollectionNumber.transform.position = CollectionNumberSpawnPoint.position;

        AmountInPool -= 1;

        //Up the amount of wood
        ResourceManager.resources.AddWood(1);

        //Reset timer
        ResetTimer();
    }

    private void ResetTimer()
    {
        currentTimeChopping = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            characterInRange = false;
            ActionHandler action = collision.GetComponentInChildren<ActionHandler>();
            action.EndChopWood();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            collision.GetComponent<Character>().SetKeepMoving(false);
            ActionHandler action = collision.GetComponentInChildren<ActionHandler>();
            action.StartChopWood();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            characterInRange = true;
        }
    }
}
