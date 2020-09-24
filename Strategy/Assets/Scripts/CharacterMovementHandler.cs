using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementHandler
{
    public void MoveAllSelectedUnits(Vector2 positionToMoveTo)
    {
        foreach (Character character in PlayerSelectionHandler._CurrentSelectedCharacters)
        {
            if (character != null)
            {
                character.StartMove(positionToMoveTo);
            }
        }
    }
}
