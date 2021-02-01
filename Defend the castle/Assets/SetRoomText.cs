using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoomText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string code = PlayerPrefs.GetString("RoomCode");

        PlayerPrefs.DeleteKey("RoomCode");

        GetComponent<TMPro.TMP_Text>().text = code;
    }
}
