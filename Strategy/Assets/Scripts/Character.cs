using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float stepTimer;
    [SerializeField] private float stepSize;
    [SerializeField] private SpriteRenderer SelectedSprite;
    [SerializeField] private GameObject movementIndicator;

    private Animator animator;

    private Vector2 currentDestination;

    private bool selected = false;
    private bool KeepMoving = true;

    private GameObject CurrentMovementIndicator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartMove(Vector2 newDestination)
    {
        ResetDestination(newDestination);
        KeepMoving = true;
        StartCoroutine(StepTowardsDestination());
        CreateMovementIndicatorPos(newDestination);
        SetWalkAnimation(true);
    }

    private void SetWalkAnimation(bool isMoving)
    {
        animator.SetBool("Move", isMoving);
    }

    private void CreateMovementIndicatorPos(Vector2 pos)
    {
        if (CurrentMovementIndicator == null)
        {
            CurrentMovementIndicator = Instantiate(movementIndicator);
        }

        CurrentMovementIndicator.transform.position = pos;
    }

    private IEnumerator StepTowardsDestination()
    {
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
        while (mypos != currentDestination && KeepMoving)
        {
            mypos = new Vector2(transform.position.x, transform.position.y);
            mypos = Vector2.MoveTowards(mypos, currentDestination, stepSize * Time.deltaTime);
            transform.position = mypos;

            yield return stepTimer;
        }
        SetWalkAnimation(false);
    }

    

    private void ResetDestination(Vector2 newDestination)
    {
        currentDestination = newDestination;
        KeepMoving = false;
        SetWalkAnimation(false);
        StopAllCoroutines();
    }

    public void SetKeepMoving(bool value)
    {
        KeepMoving = value;
    }

    private void SelectedChanged(bool newValue)
    {
        selected = newValue;
        if (SelectedSprite != null)
        {
            if (selected)
            {
                //select
                SelectedSprite.enabled = true;
            }
            else
            {
                //deselect
                SelectedSprite.enabled = false;
            }
        }
    }

    public bool Selected { get => selected; 
        set => SelectedChanged(value);
    }
}
