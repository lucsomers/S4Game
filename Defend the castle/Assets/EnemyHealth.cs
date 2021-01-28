using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyController enemyController;

    private int currentEnemyHealth = 0;
    private int maxEnemyHealth = 0;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();

        maxEnemyHealth = enemyController.Stats.MaxHealth;
        currentEnemyHealth = maxEnemyHealth;
    }

    public void HealEnemy(int amount)
    {
        currentEnemyHealth += amount;

        NormalizeHealthValue();

        CheckDeath();
    }

    public void DealDamage(int amount)
    {
        currentEnemyHealth -= amount;

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentEnemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        enemyController.gameObject.SetActive(false);
    }

    private void NormalizeHealthValue()
    {
        if (currentEnemyHealth > maxEnemyHealth)
        {
            currentEnemyHealth = maxEnemyHealth;
        }

        if (currentEnemyHealth < 0)
        {
            currentEnemyHealth = 0;
        }
    }

    public int CurrentEnemyHealth { get => currentEnemyHealth; private set => currentEnemyHealth = value; }
    public int MaxEnemyHealth { get => maxEnemyHealth; private set => maxEnemyHealth = value; }
}