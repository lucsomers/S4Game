using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private int multiplayerLobbySceneIndex = 0;

    [SerializeField] List<GameObject> networkObjects = new List<GameObject>();
    [SerializeField] GameObject stillConnectingSign;

    private int roomCode = 1000;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateARoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            roomCode = getRandomRoomCode();

            PhotonNetwork.CreateRoom(roomCode.ToString());
        }
    }

    public override void OnConnectedToMaster()
    {
       

        stillConnectingSign.SetActive(false);

        foreach (GameObject gameObject in networkObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PhotonNetwork.AutomaticallySyncScene = true;
        
        if (PhotonNetwork.IsMasterClient)
        {
            PlayerPrefs.SetString("RoomCode", roomCode.ToString());
            PlayerPrefs.Save();

           // SceneTransition.instance.LoadScene(multiplayerLobbySceneIndex);
            PhotonNetwork.LoadLevel(multiplayerLobbySceneIndex);
        }
    }

    private int getRandomRoomCode()
    {
        return Random.Range(1000, 9999);
    }
}
