using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelector : MonoBehaviour
{
    [Header("Class stats")]
    [SerializeField] private List<ClassStats> availableClassStats = new List<ClassStats>();

    [Header("Main")]
    [SerializeField] private Image classImage;
    [SerializeField] private TMP_Text classNameTextField;
    [SerializeField] private TMP_Text classDescriptionField;

    [Header("Ability names")]
    [SerializeField] private TMP_Text Ability1NameTextField;
    [SerializeField] private TMP_Text Ability2NameTextField;
    [SerializeField] private TMP_Text Ability3NameTextField;
    [SerializeField] private TMP_Text AbilityPrimaryNameTextField;
    [SerializeField] private TMP_Text AbilitySecondaryNameTextField;

    [Header("Ability Description")]
    [SerializeField] private TMP_Text Ability1DescriptionTextField;
    [SerializeField] private TMP_Text Ability2DescriptionTextField;
    [SerializeField] private TMP_Text Ability3DescriptionTextField;
    [SerializeField] private TMP_Text AbilityPrimaryDescriptionTextField;
    [SerializeField] private TMP_Text AbilitySecondaryDescriptionTextField;

    [Header("Ability icons")]
    [SerializeField] private Image Ability1Icon;
    [SerializeField] private Image Ability2Icon;
    [SerializeField] private Image Ability3Icon;
    [SerializeField] private Image AbilityPrimaryIcon;
    [SerializeField] private Image AbilitySecondaryIcon;

    private int currentClassIndex = 0;
    private int lastIndexInList = 0;

    private void Start()
    {
        lastIndexInList = availableClassStats.Count - 1;
        UpdateSelectedClass();
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
        
        classNameTextField.SetText(stats.ClassName);
        classDescriptionField.SetText(stats.ClassInfo);

        Ability1NameTextField.SetText(stats.Ability1.AbilityName);
        Ability2NameTextField.SetText(stats.Ability2.AbilityName);
        Ability3NameTextField.SetText(stats.Ability3.AbilityName);
        AbilityPrimaryNameTextField.SetText(stats.PrimaryAttack.AbilityName);
        AbilitySecondaryNameTextField.SetText(stats.SecondaryAttack.AbilityName);

        Ability1DescriptionTextField.SetText(stats.Ability1.AbilityDescription);
        Ability2DescriptionTextField.SetText(stats.Ability2.AbilityDescription);
        Ability3DescriptionTextField.SetText(stats.Ability3.AbilityDescription);
        AbilityPrimaryDescriptionTextField.SetText(stats.PrimaryAttack.AbilityDescription);
        AbilitySecondaryDescriptionTextField.SetText(stats.SecondaryAttack.AbilityDescription);

        Ability1Icon.sprite = stats.Ability1.Icon;
        Ability2Icon.sprite = stats.Ability2.Icon;
        Ability3Icon.sprite = stats.Ability3.Icon;
        AbilityPrimaryIcon.sprite = stats.PrimaryAttack.Icon;
        AbilitySecondaryIcon.sprite = stats.SecondaryAttack.Icon;
    }
}
