using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;
    public Image image;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth == 0)
        {
            LevelLoader.instance.LoadNextLevel("GameOver");
        }
    }

    public void DamagePlayer(int damage)
    {
        if(healthBar.healthPower == true)
        {
            curHealth = 110;
        }

        curHealth -= damage;
        healthBar.healthPower = false;

        if(curHealth == 100) {
            image.GetComponent<Image>().color = new Color(255, 0, 0);
        }

        healthBar.SetHealth(curHealth);
    }
   
    public void HealPlayer(int health)
    {
        curHealth = 110;
        healthBar.SetHealth(curHealth);
        healthBar.newMaxHealth(curHealth);
        healthBar.healthPower = true;
        image.GetComponent<Image>().color = new Color(0, 0, 225);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            DamagePlayer(10);
        }
    }
}
