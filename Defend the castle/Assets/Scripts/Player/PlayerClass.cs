using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    private CharacterClass currentPlayerClass;

    public void ChangePlayerClass(CharacterClass newClass)
    {
        currentPlayerClass = newClass;
    }

    public CharacterClass CurrentPlayerClass { get => currentPlayerClass; private set => currentPlayerClass = value; }
}