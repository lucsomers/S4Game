using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionHandler : MonoBehaviour
{
    public static List<Character> _CurrentSelectedCharacters;

    #region singleTon
    private void Start()
    {
        if (_CurrentSelectedCharacters == null)
        {
            _CurrentSelectedCharacters = new List<Character>();
        }
    }

    #endregion

    [SerializeField] private Camera cam;
    [SerializeField] private Transform selectionAreaTransform;

    private bool LeftMouseButtonDown = false;
    private bool RightMouseButtonDown = false;

    private Vector2 lastClickMousePos;

    CharacterMovementHandler movementHandler = new CharacterMovementHandler();
    CharacterGraphicHandler GraphicsHandler = new CharacterGraphicHandler();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //left button is pressed
            LeftMouseButtonDown = true;
            SaveLastClickPos();
        }

        if (Input.GetMouseButton(0))
        {
            CreateSelectionArea();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //right button is pressed
            SaveLastClickPos();
            RightMouseButtonDown = true;
            HandleRightMouseButton();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetSelection();
            LeftMouseButtonDown = false;
            HandleLeftButtonUp();
        }

        if (Input.GetMouseButtonUp(1))
        {
            RightMouseButtonDown = false;
        }

        if (LeftMouseButtonDown)
        {
            selectionAreaTransform.gameObject.SetActive(true);
        }
        else
        {
            selectionAreaTransform.gameObject.SetActive(false);
        }
    }

    private void CreateSelectionArea()
    {
        //calculate lower left pos
        Vector3 CurrentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lowerLeft = new Vector3(
                Mathf.Min(lastClickMousePos.x, CurrentMousePos.x),
                Mathf.Min(lastClickMousePos.y, CurrentMousePos.y)
            );

        //calculate upperright pos
        Vector3 upperRight = new Vector3(
                Mathf.Max(lastClickMousePos.x, CurrentMousePos.x),
                Mathf.Max(lastClickMousePos.y, CurrentMousePos.y)
            );

        selectionAreaTransform.position = lowerLeft;
        selectionAreaTransform.localScale = upperRight - lowerLeft;
    }

    private void HandleLeftButtonUp()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(lastClickMousePos, cam.ScreenToWorldPoint(Input.mousePosition));

        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                Character selectedCharacter = collider.GetComponentInParent<Character>();

                if (selectedCharacter != null)
                {
                    GraphicsHandler.SelectCharacter(selectedCharacter);
                    _CurrentSelectedCharacters.Add(selectedCharacter);
                }
            }
        }
    }

    private void SaveLastClickPos()
    {
        lastClickMousePos = Input.mousePosition;
        lastClickMousePos = cam.ScreenToWorldPoint(lastClickMousePos);
    }

    private void ResetSelection()
    {
        foreach (Character character in _CurrentSelectedCharacters)
        {
            GraphicsHandler.DeselectCharacter(character);
        }
        _CurrentSelectedCharacters.Clear();
    }

    private void HandleRightMouseButton()
    {
        Vector2 Destination = lastClickMousePos;
        if (_CurrentSelectedCharacters.Count > 0)
        {
            movementHandler.MoveAllSelectedUnits(Destination);
        }
    }
}
