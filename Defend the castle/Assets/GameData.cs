using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    private bool multiplayer = false;

    public bool Multiplayer { get => multiplayer; set => multiplayer = value; }

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
}
