using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassManager : MonoBehaviour
{
    #region SingleTon
    public static ClassManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }

        SetupClassesList();
    }
    #endregion

    private List<CharacterClass> availableCharacterClasses = new List<CharacterClass>();
    
    public CharacterClass GetStartingClass()
    {
        CharacterClass cToReturn = null;

        string selectedClassName = PlayerPrefs.GetString("SelectedClass");

        PlayerPrefs.DeleteKey("SelectedClass");
        PlayerPrefs.Save();

        foreach (CharacterClass characterClass in availableCharacterClasses)
        {
            if (characterClass.classStats.ClassName == selectedClassName)
            {
                cToReturn = characterClass;
                break;
            }
        }

        if (cToReturn == null)
        {
            return availableCharacterClasses[0];
        }

        return cToReturn;
    }

    private void SetupClassesList()
    {
        foreach (CharacterClass characterClass in GetComponentsInChildren<CharacterClass>())
        {
            availableCharacterClasses.Add(characterClass);
        }
    }
}
