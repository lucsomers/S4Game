using UnityEngine;

public class ClassStats : ScriptableObject
{
    [Header("String info")]
    [SerializeField] private string className;
    [SerializeField] private string classInfo;
    [SerializeField] private string classTag;
    [Header("Stats")]
    [SerializeField] private float attackSpeed;
    [SerializeField] private float moveSpeed;
    [Header("Abilities")]
    [SerializeField] private Ability ability1;
    [SerializeField] private Ability ability2;
    [SerializeField] private Ability ability3;
    [SerializeField] private Ability primaryAttack;
    [SerializeField] private Ability secondaryAttack;
    [Header("Image")]
    [SerializeField] private Sprite characterSprite;

    public string ClassName { get => className; private set => className = value; }
    public string ClassInfo { get => classInfo; private set => classInfo = value; }
    public string ClassTag { get => classTag; private set => classTag = value; }
    public float AttackSpeed { get => attackSpeed; private set => attackSpeed = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public Ability Ability1 { get => ability1; private set => ability1 = value; }
    public Ability Ability2 { get => ability2; private set => ability2 = value; }
    public Ability Ability3 { get => ability3; private set => ability3 = value; }
    public Sprite CharacterSprite { get => characterSprite; private set => characterSprite = value; }
    public Ability PrimaryAttack { get => primaryAttack; private set => primaryAttack = value; }
    public Ability SecondaryAttack { get => secondaryAttack; private set => secondaryAttack = value; }
}