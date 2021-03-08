using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disconnector : MonoBehaviour
{
    public void DisconnectFromPhoton()
    {
        PhotonNetwork.Disconnect();
    }
}
