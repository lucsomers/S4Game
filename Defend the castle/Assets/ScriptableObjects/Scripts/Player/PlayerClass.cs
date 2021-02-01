using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    [SerializeField] private CharacterClass currentPlayerClass;
    
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        
        string selectedClassName = PlayerPrefs.GetString("SelectedClass");

        currentPlayerClass = ClassManager.instance.GetStartingClass(selectedClassName);
    }

    public void ChangePlayerClass(CharacterClass newClass)
    {
        currentPlayerClass = newClass;
    }

    public CharacterClass CurrentPlayerClass { get => currentPlayerClass; private set => currentPlayerClass = value; }
}