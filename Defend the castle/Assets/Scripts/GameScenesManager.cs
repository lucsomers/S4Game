using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{
    #region SingleTon
    public static GameScenesManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private List<int> GameScenes = new List<int>();

    private int currentlyLoadedScene;

    private List<int> alreadyLoadedScenes = new List<int>();
    private bool firstTime = true;

    //TODO: Make this go up when game start so we know how many people are in game 
    private int amountOfPlayersInGame = 0;

    private void Start()
    {
        if (!GameData.instance.Multiplayer)
        {
            amountOfPlayersInGame = 1;
        }
    }

    public void LoadNextScene()
    {
        if (PhotonNetwork.IsMasterClient || !GameData.instance.Multiplayer)
        {
            int indexToLoad = 0;

            if (!firstTime)
            {
                indexToLoad = GameScenes[Random.Range(0, GameScenes.Count)];
            }
            else
            {
                firstTime = false;
                indexToLoad = GameScenes[0];
            }

            currentlyLoadedScene = indexToLoad;

            alreadyLoadedScenes.Add(indexToLoad);

            SceneTransition.instance.LoadScene(indexToLoad);
        }
    }

    public int AmountOfPlayersInGame { get => amountOfPlayersInGame; set => amountOfPlayersInGame = value; }
}
