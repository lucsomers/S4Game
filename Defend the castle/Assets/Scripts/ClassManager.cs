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
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetupClassesList();
    }
    #endregion

    private List<CharacterClass> availableCharacterClasses = new List<CharacterClass>();
    
    public CharacterClass GetStartingClass(string className)
    {
        CharacterClass cToReturn = null;

        foreach (CharacterClass characterClass in availableCharacterClasses)
        {
            if (characterClass.classStats.ClassName == className)
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("SelectedClass");
        PlayerPrefs.Save();
    }
}
