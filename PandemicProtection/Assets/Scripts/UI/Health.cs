using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DamagePlayer( int damage )
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
   
    public void HealPlayer(int health)
    {
        curHealth += health;
        healthBar.SetHealth(curHealth);
        //maxHealth += health;
        //curHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            DamagePlayer(10);
        }
    }
}
