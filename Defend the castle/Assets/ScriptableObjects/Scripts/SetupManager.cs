using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour
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

    public List<PlayerController> PlayersInGame { get => playersInGame; private set => playersInGame = value; }
}
