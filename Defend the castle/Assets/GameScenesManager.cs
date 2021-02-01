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

    //TODO: Make this go up when game start so we know how many people are in game 
    private int amountOfPlayersInGame = 1;

    public void LoadNextScene()
    {
        int indexToLoad = 0;

        for (int i = 0; i < 100; i++)
        {
            indexToLoad = GameScenes[Random.Range(0, GameScenes.Count)];

            if (!alreadyLoadedScenes.Contains(indexToLoad))
            {
                break;
            }
        }

        currentlyLoadedScene = indexToLoad;

        alreadyLoadedScenes.Add(indexToLoad);

        SceneTransition.instance.LoadScene(indexToLoad);
    }

    public int AmountOfPlayersInGame { get => amountOfPlayersInGame; set => amountOfPlayersInGame = value; }
}
