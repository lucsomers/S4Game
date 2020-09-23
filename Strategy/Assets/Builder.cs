using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [SerializeField] GameObject bluePrint;

    private int WoodCost = 10;
    private int StoneCost = 10;

    private int IncrementStep = 10;

    private void Start()
    {
        UpdateText();
    }

    public void VillageButtton_Clicked()
    {
        if (ResourceManager.resources.CurrentAmountOfWood >= WoodCost && ResourceManager.resources.CurrentAmountOfStone >= StoneCost)
        {
            ResourceManager.resources.SubstractStone(StoneCost);
            ResourceManager.resources.SubstractWood(WoodCost);
            IncrementCost();
            Instantiate(bluePrint);
        }
    }

    private void IncrementCost()
    {
        WoodCost += IncrementStep;
        StoneCost += IncrementStep;

        UpdateText();
    }

    private void UpdateText()
    {
        TMP_Text textbox = GetComponentInChildren<TMP_Text>();

        textbox.text = "Wood: " + WoodCost + " Stone: " + StoneCost;
    }
}
