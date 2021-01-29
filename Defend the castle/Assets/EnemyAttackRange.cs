using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    private EnemyController enemyController;

    private bool inRange = false;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetAnimatorBool(collision, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SetAnimatorBool(collision, enemyController.EnemyTargeting.CanShoot);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetAnimatorBool(collision, false);
    }

    private void SetAnimatorBool(Collider2D collision, bool value)
    {
        if (collision.CompareTag(enemyController.Stats.TargetTag) && enemyController.EnemyTargeting.CurrentTarget != null)
        {
            inRange = value;
            enemyController.Animator.SetBool("InRange", inRange);
        }
    }

    public bool InRange { get => inRange; private set => inRange = value; }
}

