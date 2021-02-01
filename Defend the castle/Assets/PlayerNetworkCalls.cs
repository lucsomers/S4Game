using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkCalls : MonoBehaviourPunCallbacks
{
    private PlayerController playerController;
    private PhotonView pv;
    private string classToChangeTo = "";

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        pv = GetComponent<PhotonView>();

        if (GameData.instance.Multiplayer)
        {
            if (PV.IsMine)
            {
               playerController.Cam.gameObject.SetActive(true);
            }
        }
        else
        {
            playerController.Cam.gameObject.SetActive(true);
        }

        string selectedClassName = PlayerPrefs.GetString("SelectedClass");

        if (GameData.instance.Multiplayer)
        {
            playerController.PlayerNetwork.SetClass(selectedClassName);
        }

        if (!pv.IsMine)
        {
            playerController.PlayerClass.ChangePlayerClass(ClassManager.instance.GetStartingClass(classToChangeTo));
        }
    }
    
    public void SetClass(string selectedClassName)
    {
        pv.RPC("SetClassRPC", RpcTarget.Others, selectedClassName);
    }

    public void PrimaryAttack()
    {
        pv.RPC("PrimaryAttackRPC", RpcTarget.Others, playerController.PlayerInput.MousePos);
    }

    public void SecondaryAttack()
    {
        pv.RPC("SecondaryAttackRPC", RpcTarget.Others, playerController.PlayerInput.MousePos);
    }

    public void Ability1()
    {
        pv.RPC("Ability1RPC", RpcTarget.Others, playerController.PlayerInput.MousePos);
    }

    public void Ability2()
    {
        pv.RPC("Ability2RPC", RpcTarget.Others, playerController.PlayerInput.MousePos);
    }

    public void Ability3( )
    {
        pv.RPC("Ability3RPC", RpcTarget.Others, playerController.PlayerInput.MousePos);
    }

    [PunRPC]
    public void PrimaryAttackRPC(Vector2 mousepos)
    {
        SaveMousePos(mousepos);
        playerController.PlayerPrimaryAttack.DoAttack(playerController.PlayerClass.CurrentPlayerClass.PrimaryAttack, playerController);
    }

    [PunRPC]
    public void SecondaryAttackRPC(Vector2 mousepos)
    {
        SaveMousePos(mousepos);
        playerController.PlayerSecondaryAttack.DoAttack(playerController.PlayerClass.CurrentPlayerClass.SecondaryAttack, playerController);
    }

    [PunRPC]
    public void Ability1RPC(Vector2 mousepos)
    {
        SaveMousePos(mousepos);
        playerController.PlayerAbility1.DoAttack(playerController.PlayerClass.CurrentPlayerClass.Ability1, playerController);
    }

    [PunRPC]
    public void Ability2RPC(Vector2 mousepos)
    {
        SaveMousePos(mousepos);
        playerController.PlayerAbility2.DoAttack(playerController.PlayerClass.CurrentPlayerClass.Ability2, playerController);
    }

    [PunRPC]
    public void Ability3RPC(Vector2 mousepos)
    {
        SaveMousePos(mousepos);
        playerController.PlayerAbility3.DoAttack(playerController.PlayerClass.CurrentPlayerClass.Ability3, playerController);
    }

    [PunRPC]
    public void SetClassRPC(string selectedClassName)
    {
        classToChangeTo = selectedClassName;
    }

    private void SaveMousePos(Vector2 mousepos)
    {
        playerController.PlayerInput.LastGivenMousePos = mousepos;
    }

    public PhotonView PV { get => pv; private set => pv = value; }
}