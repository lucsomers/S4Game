using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoneAmountCalculator : MonoBehaviour
{
    private TMP_Text textField;
    private int TextAmountOfStone = 0;

    private void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        if (TextAmountOfStone != ResourceManager.resources.CurrentAmountOfStone)
        {
            UpdateText(ResourceManager.resources.CurrentAmountOfStone);
        }
    }

    private void UpdateText(int newAmount)
    {
        textField.text = newAmount.ToString();
        TextAmountOfStone = newAmount;
    }
}
