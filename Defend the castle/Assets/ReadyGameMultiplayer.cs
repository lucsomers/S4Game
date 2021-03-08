using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyGameMultiplayer : MonoBehaviourPunCallbacks
{
    [SerializeField] private ClassSelector selector;

    public void Start()
    {

    }

    public void StartGame()
    {
        string selectedClassName = selector.CurrentClass.ClassName;

        PlayerPrefs.SetString("SelectedClass", selectedClassName);
        PlayerPrefs.Save();

        if (PhotonNetwork.IsMasterClient)
        {
                GameScenesManager.instance.LoadNextScene();
        }
    }
}
