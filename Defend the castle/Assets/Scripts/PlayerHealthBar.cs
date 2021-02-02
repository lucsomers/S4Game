using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Slider slider;
    private TMP_Text textField;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        textField = GetComponentInChildren<TMP_Text>();

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (slider.maxValue != playerController.PlayerHealth.MaxPlayerHealth)
        {
            slider.maxValue = playerController.PlayerHealth.MaxPlayerHealth;
            slider.value = slider.maxValue;
        }

        slider.value = playerController.PlayerHealth.CurrentPlayerHealth;
        textField.SetText( playerController.PlayerHealth.CurrentPlayerHealth.ToString());
    }
}
