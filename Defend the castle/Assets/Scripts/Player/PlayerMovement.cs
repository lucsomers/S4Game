﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float maxMoveSpeed = 250;

    private PlayerController playerController;

    private float diagnalMovementLimiter = 0.7f;
    private float x_axis = 0;
    private float y_axis = 0;

    private bool isDashing = false;

    private float movespeed = 0;

    private Rigidbody2D body;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        body = playerController.RigidBody;
    }

    private void Update()
    {
        if (playerController.PlayerNetwork.PV != null || !GameData.instance.Multiplayer)
        {
            if (playerController.PlayerNetwork.PV.IsMine || !GameData.instance.Multiplayer)
            {
                x_axis = playerController.PlayerInput.X_axis;
                y_axis = playerController.PlayerInput.Y_axis;
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerController.PlayerNetwork.PV != null || !GameData.instance.Multiplayer)
        {
            if ((!isDashing && (playerController.PlayerNetwork.PV.IsMine || !GameData.instance.Multiplayer)))
            {
                float movespeed = playerController.PlayerClass.CurrentPlayerClass.MoveSpeed;
                movespeed = ModifierManager.instance.GetModifiedMoveSpeed(movespeed);

                if (movespeed >= maxMoveSpeed)
                {
                    movespeed = maxMoveSpeed;
                }

                if (x_axis != 0)
                {
                    playerController.PlayerAnimator.IsMoving(true);
                }
                else if(y_axis != 0)
                {
                    playerController.PlayerAnimator.IsMoving(true);
                }
                else
                {
                    playerController.PlayerAnimator.IsMoving(false);
                }



                if (x_axis != 0 && y_axis != 0) // Check for diagonal movement
                {
                    // limit movement speed diagonally, so you move at 70% speed
                    x_axis *= diagnalMovementLimiter;
                    y_axis *= diagnalMovementLimiter;
                }

                body.velocity = new Vector2(x_axis * movespeed * Time.fixedDeltaTime, y_axis * movespeed * Time.fixedDeltaTime);
            }
        }
    }

    public void DashPlayer(float dashPower, float dashDistance)
    {
        StartCoroutine(Dash(x_axis, y_axis, dashPower, dashDistance));
    }

    private IEnumerator Dash(float xpos, float ypos, float dashPower, float dashDistance)
    {
        float dashtime = 0;
        isDashing = true;

        while (dashtime < dashDistance)
        {
            body.velocity = new Vector2(xpos * dashPower * Time.fixedDeltaTime, ypos * dashPower * Time.fixedDeltaTime);
            dashtime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        isDashing = false;
    }
}
