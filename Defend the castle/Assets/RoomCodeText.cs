using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCodeText : MonoBehaviour
{
    [SerializeField] private Text textField;

    public void SetText(string newText)
    {
        textField.text = newText;
    }
}
