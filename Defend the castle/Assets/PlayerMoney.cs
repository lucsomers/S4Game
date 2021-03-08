using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private PlayerController playerController;
    private int amountOfPlayerMoney = 0;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        AmountOfPlayerMoney = PlayerPrefs.GetInt("Money");

        playerController.Ui_update.UpdateMoneyText();
    }

    public void AddPlayerMoney(int amount)
    {
        AmountOfPlayerMoney += amount;
        SaveMoney();
    }

    public void SubstractPlayerMoney(int amount)
    {
        AmountOfPlayerMoney -= amount;
        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", AmountOfPlayerMoney);
        PlayerPrefs.Save();
        playerController.Ui_update.UpdateMoneyText();
    }

    public int AmountOfPlayerMoney { get => amountOfPlayerMoney; private set => amountOfPlayerMoney = value; }
}
