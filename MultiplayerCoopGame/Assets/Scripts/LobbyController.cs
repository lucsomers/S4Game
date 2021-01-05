using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    //If we are connected to master server
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void TryJoinRandomRoom()
    {
        //try to join random room
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CustomConsoleText.instance.text.text += "Failed to join room";
        Debug.Log("Failed to join room");
        CreateRoom();
    }

    public void CreateRoom(int roomid = -1)
    {
        int finalRoomName = GetFinalRoomId(roomid);

        RoomOptions roomOps = new RoomOptions();

        //try to create a new room
        PhotonNetwork.CreateRoom("Room" + finalRoomName, roomOps);

        CustomConsoleText.instance.text.text += "|| Created room with id " + finalRoomName;
        Debug.Log("Created room with id " + finalRoomName);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CustomConsoleText.instance.text.text += "|| Room creation failed trying to connect to a different room";
        Debug.Log("Room creation failed trying to connect to a different room");
        //Try to connect to a different random room
        CreateRoom();
    }

    public void LeaveCurrentRoom()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            PhotonNetwork.LeaveRoom();
            CustomConsoleText.instance.text.text += "|| Left current room";
            Debug.Log("Left current room");
        }
    }

    private int GetFinalRoomId(int roomid)
    {
        int finalRoomName = roomid;

        CustomConsoleText.instance.text.text += "|| Creating a room";
        Debug.Log("Creating a room");

        if (finalRoomName < 0)
            finalRoomName = Random.Range(0, 99999);
        return finalRoomName;
    }
}
