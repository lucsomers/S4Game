﻿using Photon.Pun;
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

        UpdateMaxHealth();

        currentPlayerHealth = maxPlayerHealth;
    }

    public void UpdateMaxHealth()
    {
        maxPlayerHealth = ModifierManager.instance.GetModifiedHealth(playerController.PlayerClass.CurrentPlayerClass.classStats.BaseHealth);
    }

    public void HealPlayer(int amount)
    {
        if (GameData.instance.Multiplayer)
        {
            if (PhotonNetwork.IsMasterClient)
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
            if (PhotonNetwork.IsMasterClient)
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

        playerController.PlayerAnimator.Damaged();

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
                PV.RPC("EndGame", RpcTarget.All);
            }
        }
        else
        {
            Destroy(GameScenesManager.instance);
            Destroy(ModifierManager.instance);
            Destroy(GameData.instance);
            SceneTransition.instance.LoadScene(0);
        }
    }

    [PunRPC]
    public void EndGame()
    {
        Destroy(GameScenesManager.instance);
        Destroy(ModifierManager.instance);
        Destroy(GameData.instance);
        SceneTransition.instance.LoadScene(0);
        StartCoroutine(Disconnect());
    }

    IEnumerator Disconnect()
    {
        yield return new WaitForSeconds(3);

        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
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
