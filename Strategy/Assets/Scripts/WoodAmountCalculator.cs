using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodAmountCalculator : MonoBehaviour
{
    private TMP_Text textField;
    private int TextAmountOfWood = 0;

    private void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        if (TextAmountOfWood != ResourceManager.resources.CurrentAmountOfWood)
        {
            UpdateText(ResourceManager.resources.CurrentAmountOfWood);
        }
    }

    private void UpdateText(int newAmount)
    {
        textField.text = newAmount.ToString();
        TextAmountOfWood = newAmount;
    }
}
