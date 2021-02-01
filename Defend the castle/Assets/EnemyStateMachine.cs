using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private List<EnemyState> enemyStates = new List<EnemyState>();

    private EnemyState currentState;

    private PlayerController currentPlayerFocus;

    // Start is called before the first frame update
    void Start()
    {
        SetupEnemyStateList();

        currentState = enemyStates[0];
        currentState.StartState();
    }

    private void SetupEnemyStateList()
    {
        foreach (EnemyState state in GetComponentsInChildren<EnemyState>())
        {
            enemyStates.Add(state);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update the current state
        currentState.UpdateState();

        //Check for if we move on to the next state
        CheckForCurrentStateEnd();
    }

    private void CheckForCurrentStateEnd()
    {
        if (currentState.CheckForStateEnd())
        {
            //We end the current state
            currentState.EndState();

            if (currentState.NextState != null)
            {
                //we have a next state so we move on
                currentState = currentState.NextState;
            }
            else
            {
                //no state defined so back to default state
                currentState = enemyStates[0];
            }

            //We start the next state
            currentState.StartState();
        }
    }

    public PlayerController CurrentPlayerFocus { get => currentPlayerFocus; set => currentPlayerFocus = value; }
}
