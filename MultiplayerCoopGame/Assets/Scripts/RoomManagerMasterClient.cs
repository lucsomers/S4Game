using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomManagerMasterClient : MonoBehaviourPunCallbacks
{
    [SerializeField] private int lobbySceneNumber;

    private int roomID = 0;

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            //Set room id
            SetRandomRoomID();
            //Create room with given room id
            CustomConsoleText.instance.text.text += "|| try to create a room with number: " + RoomCodeText.instance.Text;
            Debug.Log("try to create a room with number: " + RoomCodeText.instance.Text);

            RoomOptions ro = new RoomOptions();

            ro.MaxPlayers = 4;

            PhotonNetwork.CreateRoom(RoomCodeText.instance.Text, ro);
        }
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.IsMasterClient)
        PhotonNetwork.LoadLevel(lobbySceneNumber);
    } 

    public override void OnCreatedRoom()
    {
        CustomConsoleText.instance.text.text += "|| Created a room with number: " + PhotonNetwork.CurrentRoom.Name;
        Debug.Log("Created a room with number: " + PhotonNetwork.CurrentRoom.Name);

        CustomConsoleText.instance.text.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / 4";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CustomConsoleText.instance.text.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / 4";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //If create room has failed we try again with a different number
        CustomConsoleText.instance.text.text += "|| failed to create a room with number: " + roomID;

        // CreateRoom();
    }

    private void SetRandomRoomID()
    {
        roomID = Random.Range(1000, 9999);
    }

    public int RoomID { get => roomID; private set => roomID = value; }
}