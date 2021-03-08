using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMoneyUpdate : MonoBehaviour
{
    [SerializeField]TMPro.TMP_Text moneyTextField;

    // Start is called before the first frame update
    void Start()
    {
        moneyTextField.SetText(PlayerPrefs.GetInt("Money").ToString());
    }

    private void Update()
    {
        moneyTextField.SetText(PlayerPrefs.GetInt("Money").ToString());
    }
}
