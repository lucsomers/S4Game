using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMPro.TMP_InputField roomJoinTextfield;

    public void JoinARoom()
    {
        PhotonNetwork.JoinRoom(roomJoinTextfield.text);
    }
}
