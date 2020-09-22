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

    private bool LeftMouseButtonDown = false;
    private bool RightMouseButtonDown = false;

    private Vector2 lastClickMousePos;

    CharacterMovementHandler movementHandler = new CharacterMovementHandler();
    CharacterGraphicHandler GraphicsHandler = new CharacterGraphicHandler();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetSelection();
            LeftMouseButtonDown = true;
            SaveLastClickPos();
            HandleLeftMouseButton();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightMouseButtonDown = true;
            SaveLastClickPos();
            HandleRightMouseButton();
        }

        if (Input.GetMouseButtonUp(0))
        {
            LeftMouseButtonDown = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            RightMouseButtonDown = false;
        }
    }

    private void SaveLastClickPos()
    {
        lastClickMousePos = Input.mousePosition;
        lastClickMousePos = cam.ScreenToWorldPoint(lastClickMousePos);
    }

    private void HandleLeftMouseButton()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(lastClickMousePos, lastClickMousePos);

        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                Character selectedCharacter = collider.GetComponentInParent<Character>();
                GraphicsHandler.SelectCharacter(selectedCharacter);
                _CurrentSelectedCharacters.Add(selectedCharacter);
            }
        }
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
