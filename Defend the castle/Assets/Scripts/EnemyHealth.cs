using Photon.Pun;
using UnityEngine;

public class EnemyHealth : MonoBehaviourPunCallbacks
{
    private EnemyManager enemyController;

    private int currentEnemyHealth = 0;
    private int maxEnemyHealth = 0;

    private PhotonView PV;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyManager>();

        maxEnemyHealth = enemyController.Stats.MaxHealth;
        currentEnemyHealth = maxEnemyHealth;

        PV = GetComponent<PhotonView>();
    }

    public void HealEnemy(int amount)
    {
        if (GameData.instance.Multiplayer)
        {
            currentEnemyHealth += amount;
            PV.RPC("HealEnemyRPC", RpcTarget.All, currentEnemyHealth);
        }
        else
        {
            HealEnemyRPC(currentEnemyHealth + amount);
        }
    }

    [PunRPC]
    public void HealEnemyRPC(int amount)
    {
        currentEnemyHealth = amount;

        NormalizeHealthValue();

        CheckDeath();
    }

    [PunRPC]
    public void DealDamageRPC(int amount)
    {
        currentEnemyHealth = amount;

        CheckDeath();
    }

    public void DealDamage(int amount)
    {
        if (GameData.instance.Multiplayer)
        {
            PV.RPC("DealDamageRPC", RpcTarget.All, currentEnemyHealth - amount);
        }
        else
        {
            DealDamageRPC(currentEnemyHealth - amount);
        }
    }

    private void CheckDeath()
    {
        if (currentEnemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        enemyController.gameObject.SetActive(false);
    }

    private void NormalizeHealthValue()
    {
        if (currentEnemyHealth > maxEnemyHealth)
        {
            currentEnemyHealth = maxEnemyHealth;
        }

        if (currentEnemyHealth < 0)
        {
            currentEnemyHealth = 0;
        }
    }

    public int CurrentEnemyHealth { get => currentEnemyHealth; private set => currentEnemyHealth = value; }
    public int MaxEnemyHealth { get => maxEnemyHealth; private set => maxEnemyHealth = value; }
}