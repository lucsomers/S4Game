using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class villageHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private TMP_Text textBox;

    private void Start()
    {
        textBox = GetComponentInChildren<TMP_Text>();
        UpdateTextBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ork"))
        {
            Destroy(collision.gameObject);

            health -= 1;

            UpdateTextBox();

            

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void UpdateTextBox()
    {
        textBox.text = health.ToString();
    }
}
