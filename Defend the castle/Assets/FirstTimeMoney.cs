using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 200);
            PlayerPrefs.Save();
        }
    }
}
