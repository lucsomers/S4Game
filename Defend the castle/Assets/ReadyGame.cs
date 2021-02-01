using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private ClassSelector selector;

    public void StartGame()
    {
        string selectedClassName = selector.CurrentClass.ClassName;

        PlayerPrefs.SetString("SelectedClass", selectedClassName);
        PlayerPrefs.Save();

        //Load next scene
        if (GameData.instance.Multiplayer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameScenesManager.instance.LoadNextScene();
            }
        }
        else
        {
            GameScenesManager.instance.LoadNextScene();
        }
    }
}
