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

    private void Update()
    {
        Debug.Log(playersInGame.Count);
    }

    private void SpawnInPlayers()
    {
        PhotonNetwork.Instantiate(Path.Combine("Player"), spawnPoints[0].position, Quaternion.identity);
    }

    public List<PlayerController> PlayersInGame { get => playersInGame; private set => playersInGame = value; }
}
