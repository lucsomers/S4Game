using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
       // movespeed = 80;
        movespeed = playerController.PlayerClass.CurrentPlayerClass.MoveSpeed;
    }

    private void Update()
    {
        x_axis = playerController.PlayerInput.X_axis;
        y_axis = playerController.PlayerInput.Y_axis;
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            float movespeed = playerController.PlayerClass.CurrentPlayerClass.MoveSpeed;

            if (x_axis != 0 && y_axis != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                x_axis *= diagnalMovementLimiter;
                y_axis *= diagnalMovementLimiter;
            }

            body.velocity = new Vector2(x_axis * movespeed * Time.fixedDeltaTime, y_axis * movespeed * Time.fixedDeltaTime);
        }
    }

    public void DashPlayer(float dashPower, float dashDistance)
    {
        Vector3 normalizeDirection = ((Vector3)playerController.PlayerInput.MousePos - transform.position).normalized;

        StartCoroutine(Dash(normalizeDirection.x, normalizeDirection.y, dashPower, dashDistance));
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
