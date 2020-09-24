using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutterCollector : MonoBehaviour
{
    [SerializeField] private float TimeToChop;
    [Header("Collection Number")]
    [SerializeField] private GameObject CollectionNumber;
    [SerializeField] private Transform CollectionNumberSpawnPoint;

    private float currentTimeChopping = 0;

    private void Update()
    {
        if (TimeToChop > currentTimeChopping)
        {
            //Keep chopping
            currentTimeChopping += Time.deltaTime;
        }
        else
        {
            //CollectStone
            CollectWood();
        }
    }

    private void CollectWood()
    {
        //Create floating number
        GameObject tempCollectionNumber = Instantiate(CollectionNumber);
        tempCollectionNumber.transform.position = CollectionNumberSpawnPoint.position;

        //Up the amount of Stone
        ResourceManager.resources.AddWood(1);

        //Reset timer
        ResetTimer();
    }

    private void ResetTimer()
    {
        currentTimeChopping = 0;
    }
}
