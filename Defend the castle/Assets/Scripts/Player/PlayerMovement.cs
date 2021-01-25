using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;

    float x_axis = 0;
    float y_axis = 0;

    float movespeed = 0;

    Rigidbody2D body;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        body = playerController.RigidBody;
        movespeed = playerController.MoveSpeed;
    }

    private void Update()
    {
        x_axis = playerController.PlayerInput.X_axis;
        y_axis = playerController.PlayerInput.Y_axis;
    }

    private void FixedUpdate()
    {
        if (x_axis != 0 && y_axis != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            x_axis *= playerController.DiagnalMovementLimiter;
            y_axis *= playerController.DiagnalMovementLimiter;
        }

        body.velocity = new Vector2(x_axis * movespeed * Time.fixedDeltaTime, y_axis * movespeed * Time.fixedDeltaTime);
    }
}
