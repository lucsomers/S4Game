using UnityEngine;

[CreateAssetMenu(fileName = "New Ability stat", menuName ="New AbilityStats")]
public class AbilityStats : ScriptableObject
{
    [Header("Ability info")]
    [SerializeField] private string abilityName;
    [SerializeField] private string abilityDescription;

    [Header("Stats")]
    [SerializeField] private float cooldown;

    [Header("Image")]
    [SerializeField] private Sprite icon;

    public string AbilityName { get => abilityName; private set => abilityName = value; }
    public string AbilityDescription { get => abilityDescription; private set => abilityDescription = value; }
    public float Cooldown { get => cooldown; private set => cooldown = value; }
    public Sprite Icon { get => icon; private set => icon = value; }
}