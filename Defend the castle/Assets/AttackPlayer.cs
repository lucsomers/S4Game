using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : StateMachineBehaviour
{
    private EnemyController enemyController;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyController = animator.GetComponent<EnemyController>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyController.EnemyAttackRange.InRange)
        {
            if (enemyController.EnemyAttack.CurrentCooldown <= 0)
            {
                enemyController.EnemyAttack.SetCooldown(enemyController);
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
