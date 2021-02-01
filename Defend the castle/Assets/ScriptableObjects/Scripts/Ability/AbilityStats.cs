using UnityEngine;

[CreateAssetMenu(fileName = "New Ability stat", menuName = "Ability/New AbilityStats")]
public class AbilityStats : ScriptableObject
{
    [Header("Ability info")]
    [SerializeField] private string abilityName;
    [SerializeField] private string abilityDescription;
    [SerializeField] private AbilityLetter abilityLetter;

    [Header("Stats")]
    [SerializeField] private float cooldown;

    [Header("Image")]
    [SerializeField] private Sprite icon;

    public string AbilityName { get => abilityName; private set => abilityName = value; }
    public string AbilityDescription { get => abilityDescription; private set => abilityDescription = value; }
    public Sprite Icon { get => icon; private set => icon = value; }
    public AbilityLetter AbilityLetter { get => abilityLetter; private set => abilityLetter = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
}