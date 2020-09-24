using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    #region singleton

    public static EnemySpawner spawner;

    private void Start()
    {
        if (spawner == null)
        {
            spawner = new EnemySpawner();
            CaveCounter = currentSpawnPoints.Count;
        }
    }

    #endregion

    public int CaveCounter = 0;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemyDestination;
    [Header("Spawn")]
    [SerializeField] private List<Transform> spawnLocations = new List<Transform>();
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timeBetweenSpeedups;
    [SerializeField] private float timeSpeedUpFactor;

    private float currentSpawnTimer = 0;
    private float currentSpeedupTimer = 0;

    private List<GoblinCaveHealth> currentSpawnPoints = new List<GoblinCaveHealth>();

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
        int randomInt = Random.Range(0,currentSpawnPoints.Count);

        GameObject ork = Instantiate(enemy);
        
        //set random spawnpoint of ork
        ork.transform.position = currentSpawnPoints[randomInt].transform.position;

        //set destination of ork
        ork.GetComponent<OrkMovement>().SetDestination(enemyDestination.position);
    }

    public void UpdateSpawnList()
    {
        CaveCounter = 0;

        foreach (Transform point in spawnLocations)
        {
            GoblinCaveHealth tempCave = point.GetComponent<GoblinCaveHealth>();
            if (!tempCave.IsDestroyed)
            {
                currentSpawnPoints.Add(tempCave);
                CaveCounter++;
            }
        }

        if (CaveCounter == 0)
        {
            //game over you won
            //TODO: Make game winnable
            SceneManager.LoadScene(1);
        }
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
