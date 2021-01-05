using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        //Documention photon https://doc.photonengine.com/en-us/

        //create connection with master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We connected to: " + PhotonNetwork.CloudRegion);
    }
}
