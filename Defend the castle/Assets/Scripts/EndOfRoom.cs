using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoom : MonoBehaviour
{
    int playersAtEnd = -1;

    bool firstime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (firstime)
            {
                playersAtEnd = 0;
                firstime = false;
            }

            playersAtEnd += 1;
        }
    }

    private void Update()
    {
        if (GameData.instance.Multiplayer)
        {
            if (!firstime)
            {
                if (playersAtEnd >= GameScenesManager.instance.AmountOfPlayersInGame)
                {
                    GameScenesManager.instance.LoadNextScene();
                }
            }
        }
        else
        {
            if (playersAtEnd >= 1)
            {
                GameScenesManager.instance.LoadNextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersAtEnd -= 1;
        }
    }
}
