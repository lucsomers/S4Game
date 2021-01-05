using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementspeed;

    private PhotonView photonView;

    private Vector2 movementVector = Vector2.zero;

    private void Start()
    {
        photonView = GetComponentInParent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (movementVector.y == 0)
            {
                movementVector.x = Input.GetAxisRaw("Horizontal");
            }
            
            if (movementVector.x == 0)
            {
                movementVector.y = Input.GetAxisRaw("Vertical");
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 v3 = movementVector;
        rb.MovePosition(rb.position + v3 * movementspeed * Time.deltaTime);
    }
}
