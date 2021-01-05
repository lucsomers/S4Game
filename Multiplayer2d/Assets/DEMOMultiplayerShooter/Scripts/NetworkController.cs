using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button startGameButton;

    private void Start()
    {
        //Documention photon https://doc.photonengine.com/en-us/

        //create connection with master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We connected to: " + PhotonNetwork.CloudRegion);
        startGameButton.interactable = true;
        startGameButton.GetComponentInChildren<Text>().text = "Start game";
    }
}
