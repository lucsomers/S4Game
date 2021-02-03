using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private const string DamagedTrigger = "Damaged";
    private const string DeathTrigger = "Death";
    private const string AttackTrigger = "Attack";
    private const string MoveBool = "Moving";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Damaged()
    {
        if (animator != null)
        {
            animator.SetTrigger(DamagedTrigger);
        }
    }

    public void Death()
    {
        if (animator != null)
        {
            animator.SetTrigger(DeathTrigger);
        }
    }

    public void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger(AttackTrigger);
        }
    }

    public void Move(bool value)
    {
        if (animator != null)
        {
            animator.SetBool(MoveBool, value);
        }
    }
}