using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<PlayerController>();

        animator.runtimeAnimatorController = player.PlayerClass.CurrentPlayerClass.classStats.Animator;
    }

    public void IsMoving(bool value)
    {
        animator.SetBool("Moving", value);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Damaged()
    {
        animator.SetTrigger("Damaged");
    }
}
