using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageSpawner : MonoBehaviour
{
    [SerializeField] private float SpawnTimer = 0;
    [SerializeField] private GameObject Soldier;

    private float currentTimeOnTimer;

    // Update is called once per frame
    void Update()
    {
        currentTimeOnTimer += Time.deltaTime;

        if (currentTimeOnTimer >= SpawnTimer)
        {
            currentTimeOnTimer = 0;
            SpawnNewSoldier();
        }
    }

    private void SpawnNewSoldier()
    {
        GameObject tempSoldier = Instantiate(Soldier);

        tempSoldier.transform.position = transform.position;
    }
}
