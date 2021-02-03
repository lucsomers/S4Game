using UnityEngine;
using System.Collections;

public class SkeletonHealth : EnemyHealth
{
    [SerializeField] private float RespawnTimerMin;
    [SerializeField] private float RespawnTimerMax;

    [SerializeField] private GameObject enemyCorps;
    [SerializeField] private GameObject enemyGraphic;
    [SerializeField] private GameObject canvas;

    [SerializeField] private BoxCollider2D enemyCollider;

    private float currentRespawnTimer;

    private void Update()
    {
        if (IsDeath)
        {
            currentRespawnTimer -= Time.deltaTime;

            if (currentRespawnTimer <= 0)
            {
                Resurect();
                currentRespawnTimer = 0;
            }
        }
    }

    public override void EnemyDeath()
    {
        currentRespawnTimer = Random.Range(RespawnTimerMin, RespawnTimerMax);

        SetEnemyGraphicValue(false);
        enemyCorps.SetActive(true);
        IsDeath = true;
    }

    private void Resurect()
    {
        IsDeath = false;

        CurrentEnemyHealth = MaxEnemyHealth;

        enemyCorps.SetActive(false);
        SetEnemyGraphicValue(true);
    }

    private void SetEnemyGraphicValue(bool value)
    {
        enemyGraphic.SetActive(value);
        canvas.SetActive(value);
        enemyCollider.enabled = value;
    }
}
