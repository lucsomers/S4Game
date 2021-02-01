using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability stat", menuName = "Ability/New ProjectileAbilityStats")]
public class ProjectTileShootAbilityStats : AbilityStats
{
    [Header("Projectile")]
    [SerializeField] private ProjectileStats ProjectileToFire;
}
