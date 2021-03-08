using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUpgrade : Upgrade
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
                        ModifierManager.instance.AddMoveSpeedModifier(UpgradeManager.moveSpeedUpgrade);
                        this.UpgradeManager.HideAllUpgrades();
                    }
                }
            }
            else
            {
                ModifierManager.instance.AddMoveSpeedModifier(UpgradeManager.moveSpeedUpgrade);
                this.UpgradeManager.HideAllUpgrades();
            }
        }
    }
}
