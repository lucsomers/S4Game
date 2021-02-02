using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController enemyController;
    private float currentCooldown;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    public void Update()
    {
        HandleAttackSpeedTimers();
    }

    private void HandleAttackSpeedTimers()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }
    }

    public void SetCooldown(EnemyController enemyController)
    {
        currentCooldown = enemyController.Stats.AttackSpeed;
        enemyController.Stats.EnemyAbility.HandleAbility(enemyController);
    }

    public float CurrentCooldown { get => currentCooldown; private set => currentCooldown = value; }
}
