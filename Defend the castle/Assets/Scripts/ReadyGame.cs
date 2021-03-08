using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private ClassSelector selector;
    [SerializeField] private GameObject readyButton;
    [SerializeField] private ClassSelector classSelector;

    public static bool readyPlayer = false;

    private void Start()
    {
        if (GameData.instance.Multiplayer)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                readyButton.SetActive(true);
            }
        }
    }

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
                if (readyPlayer)
                {
                    GameScenesManager.instance.LoadNextScene();
                }
            }
            else
            {
                photonView.RPC("Ready", RpcTarget.MasterClient, classSelector.CurrentClassIndex);
            }
        }
        else
        {
            GameScenesManager.instance.LoadNextScene();
        }
    }

    [PunRPC]
    public void Ready(int classIndex)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            readyPlayer = true;
            readyButton.SetActive(true);
            
            classSelector.SetOtherClass(classIndex);
            Locker.instance.UpdateLockedState(classSelector.CurrentClass);
        }
    }
}
