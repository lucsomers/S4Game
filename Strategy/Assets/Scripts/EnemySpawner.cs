using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnLocations = new List<Transform>();
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemyDestination;
    [Header("Spawn")]
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timeBetweenSpeedups;
    [SerializeField] private float timeSpeedUpFactor;

    private float currentSpawnTimer = 0;
    private float currentSpeedupTimer = 0;

    // Update is called once per frame
    void Update()
    {
        //check speedup
        if (currentSpeedupTimer >= timeBetweenSpeedups)
        {
            SpeedUpGame();
            ResetSpeedupTimer();
        }

        //check spawntimer
        if (currentSpawnTimer >= timeBetweenSpawns)
        {
            SpawnOrk();
            ResetSpawnTimer();
        }

        UpTimers();
    }

    private void UpTimers()
    {
        float time = Time.deltaTime;
        currentSpawnTimer += time;
        currentSpeedupTimer += time;
    }

    private void SpeedUpGame()
    {
        timeBetweenSpawns -= timeSpeedUpFactor;
    }

    private void SpawnOrk()
    {
        int randomInt = Random.Range(0,spawnLocations.Count);

        GameObject ork = Instantiate(enemy);
        
        //set random spawnpoint of ork
        ork.transform.position = spawnLocations[randomInt].position;

        //set destination of ork
        ork.GetComponent<OrkMovement>().SetDestination(enemyDestination.position);
    }

    private void ResetSpawnTimer()
    {
        currentSpawnTimer = 0;
    }

    private void ResetSpeedupTimer()
    {
        currentSpeedupTimer = 0;
    }
}
