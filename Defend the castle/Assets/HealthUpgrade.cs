using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
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
                        ModifierManager.instance.AddMaxHealthModifier(UpgradeManager.healthUpgrade);
                        PlayerController.PlayerHealth.UpdateMaxHealth();
                        PlayerController.PlayerHealth.HealPlayer(1000);
                        this.UpgradeManager.HideAllUpgrades();
                    }
                }
            }
            else
            {
                ModifierManager.instance.AddMaxHealthModifier(UpgradeManager.healthUpgrade);
                PlayerController.PlayerHealth.UpdateMaxHealth();
                PlayerController.PlayerHealth.HealPlayer(1000);
                this.UpgradeManager.HideAllUpgrades();
            }
        }
    }
}
