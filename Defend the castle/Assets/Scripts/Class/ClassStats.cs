using UnityEngine;

[CreateAssetMenu(fileName = "New ClassInfo", menuName = "New ClassInfo")]
public class ClassStats : ScriptableObject
{
    [Header("String info")]
    [SerializeField] private string className;
    [SerializeField] private string classInfo;
    [SerializeField] private string classTag;
    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int baseHealth;
    [Header("Abilities")]
    [SerializeField] private AbilityStats ability1;
    [SerializeField] private AbilityStats ability2;
    [SerializeField] private AbilityStats ability3;
    [SerializeField] private AbilityStats primaryAttack;
    [SerializeField] private AbilityStats secondaryAttack;
    [Header("Image")]
    [SerializeField] private Sprite characterSprite;

    public string ClassName { get => className; private set => className = value; }
    public string ClassInfo { get => classInfo; private set => classInfo = value; }
    public string ClassTag { get => classTag; private set => classTag = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public AbilityStats Ability1 { get => ability1; private set => ability1 = value; }
    public AbilityStats Ability2 { get => ability2; private set => ability2 = value; }
    public AbilityStats Ability3 { get => ability3; private set => ability3 = value; }
    public AbilityStats PrimaryAttack { get => primaryAttack; private set => primaryAttack = value; }
    public AbilityStats SecondaryAttack { get => secondaryAttack; private set => secondaryAttack = value; }
    public Sprite CharacterSprite { get => characterSprite; private set => characterSprite = value; }
    public int BaseHealth { get => baseHealth; private set => baseHealth = value; }
}