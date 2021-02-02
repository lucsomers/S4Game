using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : Ability
{
    private GameObject Shield;

    [SerializeField] private float shieldMaxUpTime;

    private PlayerController player;

    private bool ShieldIsUp = false;

    private float currentShieldUpTime = 0;

    public override void Update()
    {
        base.Update();

        if (ShieldIsUp)
        {
            //Turn shield to mouse
            if (player != null)
            {
                TurnShieldTowardsMouse();
                CheckShieldDown();
            }
        }
    }

    private void CheckShieldDown()
    {
        currentShieldUpTime += Time.deltaTime;
        if (currentShieldUpTime >= shieldMaxUpTime)
        {
            currentShieldUpTime = 0;
            ShieldIsUp = false;
            Shield.SetActive(false);
        }
    }

    private void TurnShieldTowardsMouse()
    {
        Vector3 target;

        if (player.PlayerNetwork.PV.IsMine || !GameData.instance.Multiplayer)
        {
            target = player.PlayerInput.MousePos;
        }
        else
        {
            target = player.PlayerInput.LastGivenMousePos;
        }

        target = new Vector3(target.x, target.y, 0);

        var dir = target - Shield.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Shield.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public override void HandleAbility(PlayerController player)
    {
        base.HandleAbility(player);

        Shield = player.ShieldObject;
        this.player = player;

        if (ShieldIsUp)
        {
            //We put it away
            currentShieldUpTime = 0;
            ShieldIsUp = false;
            Shield.SetActive(false);
        }
        else
        {
            //we put shield up
            Shield.SetActive(true);
            ShieldIsUp = true;
        }
    }
}
