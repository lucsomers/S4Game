using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniEnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyController;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        if (slider.maxValue != enemyController.Stats.MaxHealth)
        {
            slider.maxValue = enemyController.Stats.MaxHealth;
            slider.value = slider.maxValue;
        }

        slider.value = enemyController.EnemyHealth.CurrentEnemyHealth;
    }
}
