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

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private List<int> GameScenes = new List<int>();
    [SerializeField] private int UpgradeSceneIndex;

    private int amountOfLevelsCompleted = 0;

    private int currentlyLoadedScene;

    private List<int> alreadyLoadedScenes = new List<int>();
    private bool firstTime = true;

    //TODO: Make this go up when game start so we know how many people are in game 
    private int amountOfPlayersInGame = 0;
    private bool inUpgradeScene = true;

    private void Start()
    {
        if (!GameData.instance.Multiplayer)
        {
            amountOfPlayersInGame = 1;
        }

        inUpgradeScene = true;
    }

    public void LoadNextScene()
    {
        if (PhotonNetwork.IsMasterClient || !GameData.instance.Multiplayer)
        {
            int indexToLoad = 0;

            if (!inUpgradeScene)
            {
                //We have upgraded so we move on to next scene
                inUpgradeScene = true;
                indexToLoad = UpgradeSceneIndex;
                amountOfLevelsCompleted++;
            }
            else if (!firstTime)
            {
                indexToLoad = GameScenes[Random.Range(0, GameScenes.Count)];
                //next scene should be upgrade scene
                inUpgradeScene = false;
            }
            else
            {
                firstTime = false;
                indexToLoad = GameScenes[0];
                //Next scene should be upgrade scene
                inUpgradeScene = false;
            }
            
            currentlyLoadedScene = indexToLoad;

            alreadyLoadedScenes.Add(indexToLoad);

            SceneTransition.instance.LoadScene(indexToLoad);
        }
    }

    public int AmountOfPlayersInGame { get => amountOfPlayersInGame; set => amountOfPlayersInGame = value; }
    public int AmountOfLevelsCompleted { get => amountOfLevelsCompleted; private set => amountOfLevelsCompleted = value; }
}
