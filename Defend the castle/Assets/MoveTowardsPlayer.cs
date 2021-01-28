using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : StateMachineBehaviour
{
    private EnemyController enemyController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyController = animator.GetComponent<EnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //IF target is in range we move towards it
        if (enemyController.EnemyTargeting.CurrentTarget != null)
        {
            Transform currentTarget = enemyController.EnemyTargeting.CurrentTarget;

            animator.transform.position = Vector3.MoveTowards(animator.transform.position, currentTarget.position, enemyController.Stats.MoveSpeed * Time.deltaTime);
        }
    }
}
