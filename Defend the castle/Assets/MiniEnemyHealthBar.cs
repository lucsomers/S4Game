using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniEnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyController playerController;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();


    }

    private void LateUpdate()
    {
        if (slider.maxValue != playerController.Stats.MaxHealth)
        {
            slider.maxValue = playerController.Stats.MaxHealth;
            slider.value = slider.maxValue;
        }

        slider.value = playerController.EnemyHealth.CurrentEnemyHealth;
    }
}
