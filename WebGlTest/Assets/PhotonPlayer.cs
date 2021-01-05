using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView pv;
    private GameObject MyAvatar;

    void Start()
    {
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            CreateAvatar();
        }
    }

    public void CreateAvatar()
    {
        int spawnIndex = Random.Range(0, GameSetupController.instance.SpawnPoints.Count);
        MyAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), GameSetupController.instance.SpawnPoints[spawnIndex].position, Quaternion.identity);
        Debug.Log("Creating Avatar");

        //Source: https://www.youtube.com/watch?v=SNhWbHqFUbU&ab_channel=InfoGamer
    }
}
