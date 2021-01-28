using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniPlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        if (playerController != null && slider != null)
        {
            if (slider.maxValue != playerController.PlayerHealth.MaxPlayerHealth)
            {
                slider.maxValue = playerController.PlayerHealth.MaxPlayerHealth;
                slider.value = slider.maxValue;
            }

            slider.value = playerController.PlayerHealth.CurrentPlayerHealth;
        }
    }
}
