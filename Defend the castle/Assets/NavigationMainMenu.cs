using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationMainMenu : MonoBehaviour
{
    [SerializeField] private int singlePlayerIndex;
    [SerializeField] private int multiplayerIndex;
    [SerializeField] private int optionsIndex;
    [SerializeField] private int characterScreenIndex;

    public void StartSinglePlayer()
    {
        SceneTransition.instance.LoadScene(singlePlayerIndex);
    }

    public void StartMultiplayerGame()
    {
        SceneTransition.instance.LoadScene(multiplayerIndex);
    }

    public void StartOptions()
    {
        SceneTransition.instance.LoadScene(optionsIndex);
    }

    public void StartCharacters()
    {
        SceneTransition.instance.LoadScene(characterScreenIndex);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
