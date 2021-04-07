using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;
    public bool healthPower;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
        healthPower = false;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    public void newMaxHealth(int hp)
    {
        healthBar.maxValue = hp;
        healthBar.value = hp;
    }
}