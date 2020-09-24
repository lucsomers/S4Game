using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollector : MonoBehaviour
{
    [SerializeField] private float TimeToChop;
    [Header("Collection Number")]
    [SerializeField] private GameObject CollectionNumber;
    [SerializeField] private Transform CollectionNumberSpawnPoint;

    private float currentTimeChopping = 0;

    private bool characterInRange = false;

    private void Update()
    {
        if (characterInRange)
        {
            //there is a character in range to chop stone
            if (TimeToChop > currentTimeChopping)
            {
                //Keep chopping
                currentTimeChopping += Time.deltaTime;
            }
            else
            {
                //CollectStone
                CollectStone();
            }
        }
        else
        {
            //reset timer
            ResetTimer();
        }
    }

    private void CollectStone()
    {
        //Create floating number
        GameObject tempCollectionNumber = Instantiate(CollectionNumber);
        tempCollectionNumber.transform.position = CollectionNumberSpawnPoint.position;

        //Up the amount of Stone
        ResourceManager.resources.AddStone(1);

        //Reset timer
        ResetTimer();
    }

    private void ResetTimer()
    {
        currentTimeChopping = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            collision.GetComponent<Character>().SetKeepMoving(false);
            ActionHandler action = collision.GetComponentInChildren<ActionHandler>();
            action.StartChopStone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            characterInRange = false;
            ActionHandler action = collision.GetComponentInChildren<ActionHandler>();
            action.EndChopStone();
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
