using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassSelector : MonoBehaviour
{
    [Header("Class stats")]
    [SerializeField] private List<ClassStats> availableClassStats = new List<ClassStats>();

    [Header("Main")]
    [SerializeField] private SpriteRenderer classImage;
    [SerializeField] private TMP_Text classNameTextField;

    [Header("Ability names")]
    [SerializeField] private TMP_Text Ability1NameTextField;
    [SerializeField] private TMP_Text Ability2NameTextField;
    [SerializeField] private TMP_Text Ability3NameTextField;

    [Header("Ability Description")]
    [SerializeField] private TMP_Text Ability1DescriptionTextField;
    [SerializeField] private TMP_Text Ability2DescriptionTextField;
    [SerializeField] private TMP_Text Ability3DescriptionTextField;

    [Header("Ability icons")]
    [SerializeField] private SpriteRenderer Ability1Icon;
    [SerializeField] private SpriteRenderer Ability2Icon;
    [SerializeField] private SpriteRenderer Ability3Icon;

    private int currentClassIndex = 0;
    private int lastIndexInList = 0;

    private void Start()
    {
        lastIndexInList = availableClassStats.Count - 1;
    }

    public void PreviousClass()
    {
        currentClassIndex--;

        if (currentClassIndex < 0)
        {
            currentClassIndex = lastIndexInList;
        }

        UpdateSelectedClass();
    }

    public void NextClass()
    {
        currentClassIndex++;

        if (currentClassIndex > lastIndexInList)
        {
            currentClassIndex = 0;
        }

        UpdateSelectedClass();
    }

    private void UpdateSelectedClass()
    {
        ClassStats stats = availableClassStats[currentClassIndex];

        classImage.sprite = stats.CharacterSprite;

        classNameTextField.text = stats.ClassName;

        Ability1NameTextField.text = stats.Ability1.AbilityName;
        Ability2NameTextField.text = stats.Ability2.AbilityName;
        Ability3NameTextField.text = stats.Ability3.AbilityName;

        Ability1DescriptionTextField.text = stats.Ability1.AbilityDescription;
        Ability2DescriptionTextField.text = stats.Ability2.AbilityDescription;
        Ability3DescriptionTextField.text = stats.Ability3.AbilityDescription;

        Ability1Icon.sprite = stats.Ability1.Icon;
        Ability2Icon.sprite = stats.Ability2.Icon;
        Ability3Icon.sprite = stats.Ability3.Icon;
    }
}
