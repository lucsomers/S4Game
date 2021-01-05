using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] private float diagnalModifier = 1.2f;
    [SerializeField] private Animator animator;

    private Photon.Pun.PhotonView PV;

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PV = GetComponent<Photon.Pun.PhotonView>();

}

// Update is called once per frame
private void Update()
    {
        if (PV.IsMine)
        {
            if (moveVector.y != 0)
                moveVector.x = Input.GetAxis("Horizontal") / diagnalModifier;
            else
                moveVector.x = Input.GetAxis("Horizontal");

            if (moveVector.x != 0)
                moveVector.y = Input.GetAxis("Vertical") / diagnalModifier;
            else
                moveVector.y = Input.GetAxis("Vertical");

            if (moveVector.y != 0 || moveVector.x != 0)
            {
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.Lerp(rb.position, rb.position + moveVector * moveSpeed * Time.fixedDeltaTime, 5 * Time.fixedDeltaTime));
    }
}
