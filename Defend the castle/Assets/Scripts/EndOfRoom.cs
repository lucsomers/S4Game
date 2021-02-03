using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoom : MonoBehaviour
{
    int playersAtEnd = -1;

    bool firstime = true;

    bool loadingNewLevel = false;

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
            if (PhotonNetwork.IsMasterClient)
            {
                if (!firstime)
                {
                    if (playersAtEnd >= GameScenesManager.instance.AmountOfPlayersInGame)
                    {
                        if (!loadingNewLevel)
                        {
                            loadingNewLevel = true;
                            GameScenesManager.instance.LoadNextScene();
                        }
                    }
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
