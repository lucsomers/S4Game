using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    [SerializeField] private SpriteRenderer PlayerCharacter;

    [Header("Ability icons")]
    [SerializeField] private Image Ability1Icon;
    [SerializeField] private Image Ability2Icon;
    [SerializeField] private Image Ability3Icon;
    [SerializeField] private Image AbilityPrimaryIcon;
    [SerializeField] private Image AbilitySecondaryIcon;

    [Header("Cooldowns")]
    [SerializeField] private Slider ability1Slider;
    [SerializeField] private Slider ability2Slider;
    [SerializeField] private Slider ability3Slider;
    [SerializeField] private Slider abilityPrimarySlider;
    [SerializeField] private Slider abilitySecondarySlider;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        StartupUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void StartupUI()
    {
        //Sprites
        Ability1Icon.sprite = playerController.StartClass.classStats.Ability1.Icon;
        Ability2Icon.sprite = playerController.StartClass.classStats.Ability2.Icon;
        Ability3Icon.sprite = playerController.StartClass.classStats.Ability3.Icon;
        AbilityPrimaryIcon.sprite = playerController.StartClass.classStats.PrimaryAttack.Icon;
        AbilitySecondaryIcon.sprite = playerController.StartClass.classStats.SecondaryAttack.Icon;

        //Cooldown
        abilityPrimarySlider.maxValue = playerController.StartClass.classStats.PrimaryAttack.Cooldown;
        abilitySecondarySlider.maxValue = playerController.StartClass.classStats.SecondaryAttack.Cooldown;
        ability1Slider.maxValue = playerController.StartClass.classStats.Ability1.Cooldown;
        ability2Slider.maxValue = playerController.StartClass.classStats.Ability2.Cooldown;
        ability3Slider.maxValue = playerController.StartClass.classStats.Ability3.Cooldown;

        //CharacterSprite
        PlayerCharacter.sprite = playerController.StartClass.classStats.CharacterSprite;
    }

    public void UpdateUI()
    {
        abilityPrimarySlider.value = playerController.PlayerPrimaryAttack.CurrentCooldown;
        abilitySecondarySlider.value = playerController.PlayerSecondaryAttack.CurrentCooldown;

        ability1Slider.value = playerController.PlayerAbility1.CurrentCooldown;
        ability2Slider.value = playerController.PlayerAbility2.CurrentCooldown;
        ability3Slider.value = playerController.PlayerAbility3.CurrentCooldown;
    }
}
