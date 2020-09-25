using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoblinCaveHealth : MonoBehaviour
{
    [SerializeField] private int health;

    [HideInInspector] public bool IsDestroyed = false;

    private TMP_Text textbox;

    private int damagePerUnit = 1;

    private void Start()
    {
        textbox = GetComponentInChildren<TMP_Text>();
        textbox.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Destroy(collision.gameObject);
            SubstractHealth(damagePerUnit);
        }
    }

    private void SubstractHealth(int v)
    {
        if (health > 0)
        {
            health -= v;
            textbox.text = health.ToString();
        }

        if (health <= 0)
        {
            //death
            IsDestroyed = true;
            gameObject.SetActive(false);
            EnemySpawner._instance.UpdateSpawnList();
        }
    }
}
