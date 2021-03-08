using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherClientView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.instance.Multiplayer)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
