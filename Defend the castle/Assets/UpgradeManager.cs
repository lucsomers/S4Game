using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public const int healthUpgrade = 40;
    public const float cooldownUpgrade = 20f;
    public const float attackSpeedUpgrade = 20f;
    public const float moveSpeedUpgrade = 25f;

    private List<Upgrade> allUpgrades = new List<Upgrade>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Upgrade upgrade in GetComponentsInChildren<Upgrade>())
        {
            allUpgrades.Add(upgrade);
        }
    }

    public void HideAllUpgrades()
    {
        foreach (Upgrade upgrade in allUpgrades)
        {
            upgrade.gameObject.SetActive(false);
        }
    }
}
