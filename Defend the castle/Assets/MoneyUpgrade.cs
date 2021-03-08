using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpgrade : Upgrade
{
    [SerializeField] private GameObject moneyParticlesPrefab;

    private const int maxAmountInChest = 20;
    private const int minAmountInChest = 10;

    private int amountInChest;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (PlayerController != null)
        {
            if (GameData.instance.Multiplayer)
            {
                if (PV != null)
                {
                    if (PV.IsMine)
                    {
                        HandleCollision();
                    }
                }
            }
            else
            {
                HandleCollision();
            }
        }
        
    }

    private void HandleCollision()
    {
        SetAmountInChest();

        this.UpgradeManager.HideAllUpgrades();
        moneyParticlesPrefab.SetActive(true);
        PlayerController.PlayerMoney.AddPlayerMoney(amountInChest);
    }

    private void SetAmountInChest()
    {
        amountInChest = Random.Range(minAmountInChest * GameScenesManager.instance.AmountOfLevelsCompleted, maxAmountInChest * GameScenesManager.instance.AmountOfLevelsCompleted);
    }
}
