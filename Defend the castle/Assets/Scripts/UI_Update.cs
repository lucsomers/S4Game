using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Moneys")]
    [SerializeField] private TMP_Text moneyText;
    private PlayerController playerController;
    private ClassStats currentPlayerClassStats;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();

        currentPlayerClassStats = playerController.PlayerClass.CurrentPlayerClass.classStats;

        StartupUI();
    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    private void StartupUI()
    {
        //Sprites
        Ability1Icon.sprite = currentPlayerClassStats.Ability1.Icon;
        Ability2Icon.sprite = currentPlayerClassStats.Ability2.Icon;
        Ability3Icon.sprite = currentPlayerClassStats.Ability3.Icon;
        AbilityPrimaryIcon.sprite = currentPlayerClassStats.PrimaryAttack.Icon;
        AbilitySecondaryIcon.sprite = currentPlayerClassStats.SecondaryAttack.Icon;

        //Cooldown
        abilityPrimarySlider.maxValue = currentPlayerClassStats.PrimaryAttack.Cooldown;
        abilitySecondarySlider.maxValue = currentPlayerClassStats.SecondaryAttack.Cooldown;
        ability1Slider.maxValue = currentPlayerClassStats.Ability1.Cooldown;
        ability2Slider.maxValue = currentPlayerClassStats.Ability2.Cooldown;
        ability3Slider.maxValue = currentPlayerClassStats.Ability3.Cooldown;

        //CharacterSprite
        PlayerCharacter.sprite = currentPlayerClassStats.CharacterSprite;

        UpdateMoneyText();
    }

    public void UpdateUI()
    {
        abilityPrimarySlider.value = playerController.PlayerPrimaryAttack.CurrentCooldown;
        abilitySecondarySlider.value = playerController.PlayerSecondaryAttack.CurrentCooldown;

        ability1Slider.value = playerController.PlayerAbility1.CurrentCooldown;
        ability2Slider.value = playerController.PlayerAbility2.CurrentCooldown;
        ability3Slider.value = playerController.PlayerAbility3.CurrentCooldown;

        CheckInvisible();
    }

    private void CheckInvisible()
    {
        if (playerController.Invisible)
        {
            if (PlayerCharacter.color.a != 0.5f)
            {
                PlayerCharacter.color = new Color(PlayerCharacter.color.r, PlayerCharacter.color.g, PlayerCharacter.color.b, 0.5f);
            }
        }
        else
        {
            if (PlayerCharacter.color.a != 1)
            {
                PlayerCharacter.color = new Color(PlayerCharacter.color.r, PlayerCharacter.color.g, PlayerCharacter.color.b, 1);
            }
        }
    }

    public void UpdateMoneyText()
    {
        moneyText.SetText(PlayerPrefs.GetInt("Money").ToString());
    }
}
