using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoom : MonoBehaviour
{
    int playersAtEnd = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersAtEnd += 1;
        }
    }

    private void Update()
    {
        if (playersAtEnd >= GameScenesManager.instance.AmountOfPlayersInGame)
        {
            GameScenesManager.instance.LoadNextScene();
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
