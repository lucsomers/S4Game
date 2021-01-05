using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    #region Singleton
    public static NetworkController instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    //Documention photon https://doc.photonengine.com/en-us/
    private void Start()
    {
        ConnectToMaster();
    }

    private void ConnectToMaster()
    {
        //create connection with master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        EnableButtons();

        CustomConsoleText.instance.text.text += "|| We connected to: " + PhotonNetwork.CloudRegion;
        Debug.Log("We connected to: " + PhotonNetwork.CloudRegion);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void EnableButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }
}
