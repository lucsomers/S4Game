using Photon.Pun;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    #region SingleTon

    public static GameSetupController instance;

    private void OnEnable()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private List<Transform> SpawnPoints = new List<Transform>();

    [HideInInspector]
    public List<GameObject> lstPlayersInGame = new List<GameObject>();

    private void Start()
    {
       CreatePlayer();
    }

    public void CreatePlayer()
    { 
        GameObject go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), GetSpawnPoint(), Quaternion.identity);

        lstPlayersInGame.Add(go);

        Debug.Log("Creating player");

        //TODO: start the game and try connection
        //https://www.youtube.com/watch?v=SNhWbHqFUbU&ab_channel=InfoGamer
        //Test how to create a new game
    }

    public Vector3 GetSpawnPoint()
    {
        return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)].position;
    }
}
