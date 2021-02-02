using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetupManager : MonoBehaviourPunCallbacks
{
    #region SingleTon
    public static SetupManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    private List<PlayerController> playersInGame = new List<PlayerController>();

    [SerializeField] private PlayerController offlinePlayer;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        if (GameData.instance.Multiplayer)
        {
            SpawnInPlayers();

            offlinePlayer.gameObject.SetActive(false);
        }
    }

    public void SpawnInEnemy(Vector3 pos, string enemyName)
    {
        PhotonNetwork.Instantiate(Path.Combine(enemyName), pos, Quaternion.identity);
    }

    private void SpawnInPlayers()
    {
        PhotonNetwork.Instantiate(Path.Combine("Player"), spawnPoints[0].position, Quaternion.identity);
        //PhotonNetwork.Instantiate(Path.Combine("AllEnemiesInSceneManager"), Vector3.zero, Quaternion.identity);
    }

    public List<PlayerController> PlayersInGame { get => playersInGame; private set => playersInGame = value; }
}
