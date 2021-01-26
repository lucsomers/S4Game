using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    public ClassStats classStats;

    private Ability ability1;
    private Ability ability2;
    private Ability ability3;

    private Ability primaryAttack;
    private Ability secondaryAttack;
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = classStats.MoveSpeed;

        SetupAbilities();
    }

    private void SetupAbilities()
    {
        foreach (Ability ability in GetComponentsInChildren<Ability>())
        {
            switch (ability.Stats.AbilityLetter)
            {
                case AbilityLetter.Q_1:
                    ability1 = ability;
                    break;
                case AbilityLetter.W_2:
                    ability2 = ability;
                    break;
                case AbilityLetter.F_3:
                    ability3 = ability;
                    break;
                case AbilityLetter.Primary:
                    primaryAttack = ability;
                    break;
                case AbilityLetter.Secondary:
                    secondaryAttack = ability;
                    break;
                default:
                    break;
            }

        }
    }

    public Ability Ability1 { get => ability1; private set => ability1 = value; }
    public Ability Ability2 { get => ability2; private set => ability2 = value; }
    public Ability Ability3 { get => ability3; private set => ability3 = value; }
    public Ability PrimaryAttack { get => primaryAttack; private set => primaryAttack = value; }
    public Ability SecondaryAttack { get => secondaryAttack; private set => secondaryAttack = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
}