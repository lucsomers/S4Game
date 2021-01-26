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
    }
    #endregion

    private List<CharacterClass> availableCharacterClasses = new List<CharacterClass>();

    // Start is called before the first frame update
    void Start()
    {
        SetupClassesList();
    }

    private void SetupClassesList()
    {
        foreach (CharacterClass characterClass in GetComponentsInChildren<CharacterClass>())
        {
            availableCharacterClasses.Add(characterClass);
        }
    }
}
