using Photon.Pun;
using System.Collections;
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

    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
       CreatePlayer();
    }

    public void CreatePlayer()
    { 
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        Debug.Log("Creating player");

        //TODO: start the game and try connection
        //https://www.youtube.com/watch?v=SNhWbHqFUbU&ab_channel=InfoGamer
        //Test how to create a new game
    }

    public List<Transform> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
}
