using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCaveHealth : MonoBehaviour
{
    [SerializeField] private int health;

    [HideInInspector] public bool IsDestroyed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Destroy(collision.gameObject);
            SubstractHealth(1);
        }
    }

    private void SubstractHealth(int v)
    {
        if (health - v >= 0)
        {
            health -= 0;
        }

        if (health <= 0)
        {
            //death
            IsDestroyed = true;
            gameObject.SetActive(false);
            EnemySpawner.spawner.UpdateSpawnList();
        }
    }
}
