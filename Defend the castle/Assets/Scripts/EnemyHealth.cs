using Photon.Pun;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviourPunCallbacks
{
    private const float animationWaitTime = 1f;

    private EnemyManager enemyController;

    private int currentEnemyHealth = 0;
    private int maxEnemyHealth = 0;

    private PhotonView PV;

    [HideInInspector]
    public bool IsDeath = false;

    public void Start()
    {
        enemyController = GetComponentInParent<EnemyManager>();

        maxEnemyHealth = enemyController.EnemyScaler.GetEnemyMaxHealth((float)enemyController.Stats.MaxHealth);
        currentEnemyHealth = maxEnemyHealth;

        PV = GetComponent<PhotonView>();
    }

    public void HealEnemy(int amount)
    {
        if (GameData.instance.Multiplayer && PV.IsMine)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PV.RPC("HealEnemyRPC", RpcTarget.All, currentEnemyHealth + amount);
            }
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
        enemyController.EnemyAnimator.Damaged();

        currentEnemyHealth = amount;

        CheckDeath();
    }

    public void DealDamage(int amount)
    {
        if (GameData.instance.Multiplayer && PV.IsMine)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PV.RPC("DealDamageRPC", RpcTarget.All, currentEnemyHealth - amount);
            }
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
            enemyController.EnemyAnimator.Death();
            EnemyDeath();
        }
    }

    public virtual void EnemyDeath()
    {
        IsDeath = true;

        if (gameObject.activeSelf)
        {
            StartCoroutine(AnimationDelay());

            if (GameData.instance.Multiplayer)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    EnemiesInSceneController.instance.EnemyInLevelCount--;
                }
            }
            else
            {
                EnemiesInSceneController.instance.EnemyInLevelCount--;
            }
        }
    }

    private IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(animationWaitTime);
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

    public int CurrentEnemyHealth { get => currentEnemyHealth; set => currentEnemyHealth = value; }
    public int MaxEnemyHealth { get => maxEnemyHealth; private set => maxEnemyHealth = value; }
}