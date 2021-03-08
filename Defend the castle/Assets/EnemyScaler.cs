using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaler : MonoBehaviour
{
    public const float MoveSpeedScalingFactor = 2;
    public const float AttackSpeedScalingFactor = 2;
    public const float HealthScalingFactor = 10;

    public const float MaxMoveSpeedScalingFactor = 35;
    public const float MaxAttackSpeedScalingFactor = 80;
    public const float MaxHealthScalingFactor = 2000;

    public int GetEnemyMaxHealth(float baseMaxHealth)
    {
        return (int)CalculateModifiedValue(baseMaxHealth, HealthScalingFactor, MaxHealthScalingFactor);
    }

    public float GetEnemyAttackSpeed(float baseAttackSpeed)
    {
        return CalculateModifiedAttackSpeedValue(baseAttackSpeed, AttackSpeedScalingFactor, MaxAttackSpeedScalingFactor);
    }

    public float GetEnemyMoveSpeed(float baseSpeed)
    {
        return CalculateModifiedValue(baseSpeed, MoveSpeedScalingFactor, MaxMoveSpeedScalingFactor);
    }

    private float CalculateModifiedValue(float baseValue, float ScalingFactor, float Maximum)
    {
        float finalScalingFactor = ScalingFactor * (float)GameScenesManager.instance.AmountOfLevelsCompleted + 1;

        float onePrecent = baseValue / 100;

        if (finalScalingFactor > Maximum)
        {
            finalScalingFactor = Maximum;
        }

        return (baseValue + (onePrecent * finalScalingFactor));
    }

    private float CalculateModifiedAttackSpeedValue(float baseValue, float ScalingFactor, float Maximum)
    {
        float finalScalingFactor = ScalingFactor * GameScenesManager.instance.AmountOfLevelsCompleted + 1;

        float onePrecent = baseValue / 100;

        if (finalScalingFactor > Maximum)
        {
            finalScalingFactor = Maximum;
        }

        return (baseValue - (onePrecent * finalScalingFactor));
    }
}
