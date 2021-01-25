using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterClass : MonoBehaviour
{
    public ClassStats classStats;

    public Ability Ability1;
    public Ability Ability2;
    public Ability Ability3;

    public Ability PrimaryAttack;
    public Ability SecondaryAttack;

    public float AttackSpeed;
    public float MoveSpeed;

    private void Start()
    {
        Ability1 = new Ability(classStats.Ability1);
        Ability2 = new Ability(classStats.Ability2);
        Ability3 = new Ability(classStats.Ability3);
        AttackSpeed = classStats.AttackSpeed;
        MoveSpeed = classStats.MoveSpeed;
        PrimaryAttack = new Ability(classStats.PrimaryAttack);
        SecondaryAttack = new Ability(classStats.SecondaryAttack);
    }
}