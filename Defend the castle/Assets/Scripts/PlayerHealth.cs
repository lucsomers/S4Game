using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;

    private int currentPlayerHealth = 0;
    private int maxPlayerHealth = 0;
    private PhotonView PV;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        PV = GetComponent<PhotonView>();

        maxPlayerHealth = playerController.PlayerClass.CurrentPlayerClass.classStats.BaseHealth;
        currentPlayerHealth = maxPlayerHealth;
    }

    public void HealPlayer(int amount)
    {
        if (GameData.instance.Multiplayer)
        {
            if (PV.IsMine)
            {
                PV.RPC("HealPlayerRPC", RpcTarget.All, currentPlayerHealth + amount);
            }
        }
        else
        {
            HealPlayerRPC(currentPlayerHealth + amount);
        }
    }

    public void DealDamage(int amount)
    {
        if (GameData.instance.Multiplayer)
        {
            if (PV.IsMine)
            {
                PV.RPC("DealDamageRPC", RpcTarget.All, currentPlayerHealth - amount);
            }
        }
        else
        {
            DealDamageRPC(currentPlayerHealth - amount);
        }
    }
    
    [PunRPC]
    public void HealPlayerRPC(int amount)
    {
        currentPlayerHealth = amount;

        NormalizeHealthValue();

        CheckDeath();
    }

    [PunRPC]
    public void DealDamageRPC(int amount)
    {
        currentPlayerHealth = amount;

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentPlayerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        if (GameData.instance.Multiplayer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                SceneTransition.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            SceneTransition.instance.LoadScene(0);
        }
    }

    private void NormalizeHealthValue()
    {
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }

        if (currentPlayerHealth < 0)
        {
            currentPlayerHealth = 0;
        }
    }

    public int CurrentPlayerHealth { get => currentPlayerHealth; private set => currentPlayerHealth = value; }
    public int MaxPlayerHealth { get => maxPlayerHealth; private set => maxPlayerHealth = value; }
}
