using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomManagerClient : MonoBehaviourPunCallbacks
{
    //Client callbacks
    public override void OnJoinedRoom()
    {
        CustomConsoleText.instance.text.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / 4";
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //join
    public void JoinRoom()
    {
        string roomCode = RoomCodeText.instance.Text;

        CustomConsoleText.instance.text.text += "|| Join room with id: " + RoomCodeText.instance.Text;
        Debug.Log("Join room with id: " + RoomCodeText.instance.Text);
        PhotonNetwork.JoinRoom(RoomCodeText.instance.Text);
    }
}
