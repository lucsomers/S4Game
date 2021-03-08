using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    #region SingleTon
    public static ModifierManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private const float maxCDR = 80;

    private List<float> moveSpeedModifiers = new List<float>();
    private List<float> attackSpeedModifiers = new List<float>();
    private List<float> cooldownModifiers = new List<float>();

    private List<float> maxHealthModifiers = new List<float>();

    public void AddMoveSpeedModifier(float value) { moveSpeedModifiers.Add(value); }
    public void AddAttackSpeedModifier(float value) { attackSpeedModifiers.Add(value); }
    public void AddCooldownModifier(float value) { cooldownModifiers.Add(value); }
    public void AddMaxHealthModifier(float value) { maxHealthModifiers.Add(value); }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private float GetModifier(List<float> looplist)
    {
        float modifier = 0;

        foreach (float mod in looplist)
        {
            modifier += mod;
        }

        return modifier;
    }

    public float GetModifiedAttackSpeed(float currentCooldown)
    {
        return CalculateModifiedFloat(currentCooldown, attackSpeedModifiers);
    }

    public float GetModifiedCooldown(float currentCooldown)
    {
        return CalculateModifiedFloat(currentCooldown, cooldownModifiers);
    }

    public float GetModifiedMoveSpeed(float currentMoveSpeed)
    {
        return CalculateModifiedMoveSpeed(currentMoveSpeed, moveSpeedModifiers);
    }

    public int GetModifiedHealth(int maxHealth)
    {
        return CalculateModifiedInt(maxHealth,maxHealthModifiers);
    }

    private float CalculateModifiedFloat(float defaultFloat, List<float> modifiers)
    {
        float toReturn = defaultFloat;

        float modifier = GetModifier(modifiers);

        if (modifier > maxCDR)
        {
            modifier = maxCDR;
        }

        toReturn = defaultFloat - ((defaultFloat / 100) * modifier);

        return toReturn;
    }

    private float CalculateModifiedMoveSpeed(float defaultFloat, List<float> modifiers)
    {
        float toReturn = defaultFloat;

        float modifier = GetModifier(modifiers);

        toReturn = defaultFloat + ((defaultFloat / 100) * modifier);

        return toReturn;
    }


    private int CalculateModifiedInt(int defaultInt, List<float> modifiers)
    {
        int toReturn = defaultInt;

        float modifier = GetModifier(modifiers);

        int toadd = (int)(((float)defaultInt / 100) * modifier);

        toReturn = defaultInt + toadd;

        return toReturn;
    }
}
