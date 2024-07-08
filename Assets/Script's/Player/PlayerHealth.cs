using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    // create a public method which reduces hitpoints by amount of damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void IncreaseHealth(float amount)
    {
        if (health < 100)
            health += amount;
    }

    void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        // converting the float into a string
        healthText.text = health.ToString();
    }
}
