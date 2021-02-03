using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    private PlayerController playerController;

    private void Start()
    {
        upgradeManager = GetComponentInParent<UpgradeManager>();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController tempController = collision.GetComponent<PlayerController>();

        if (tempController != null)
        {
            playerController = tempController;
        }
    }

    public UpgradeManager UpgradeManger { get => upgradeManager; private set => upgradeManager = value; }
    public PlayerController PlayerController { get => playerController; private set => playerController = value; }
}
