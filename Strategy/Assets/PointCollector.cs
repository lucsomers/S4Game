﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private GameObject deadParticles;
    [Header("Collection Number")]
    [SerializeField] private GameObject CollectionNumber;
    [SerializeField] private Transform CollectionNumberSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            Vector3 spawnPos = collision.transform.position;

            Destroy(collision.gameObject);

            GameObject blood = Instantiate(deadParticles);
            blood.transform.position = spawnPos;

            GameObject number = Instantiate(CollectionNumber);
            number.transform.position = CollectionNumberSpawnPoint.position;

            ResourceManager.resources.AddPoints(1);
        }

        if (collision.CompareTag("Ork"))
        {
            PlayerPrefs.SetInt("Score", ResourceManager.resources.CurrentAmountOfPoints);
            SceneManager.LoadScene(1);
        }
    }
}
