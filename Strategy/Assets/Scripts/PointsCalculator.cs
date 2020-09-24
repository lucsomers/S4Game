using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsCalculator : MonoBehaviour
{
    private TMP_Text textField;
    private int TextAmountOfPoints = 0;

    private void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        if (TextAmountOfPoints != ResourceManager.resources.CurrentAmountOfPoints)
        {
            UpdateText(ResourceManager.resources.CurrentAmountOfPoints);
        }
    }

    private void UpdateText(int newAmount)
    {
        textField.text = newAmount.ToString();
        TextAmountOfPoints = newAmount;
    }
}
