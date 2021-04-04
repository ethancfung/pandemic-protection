using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPower : MonoBehaviour
{
    public Health playerHealth;
    //public SpriteRenderer rend;
    //private Sprite maskSprite;

    void Start()
    {
        
        //maskSprite = Resources.Load<Sprite>("Clothes/Sprite Power Ups"); 
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //increases player's health
            GameObject player = collision.gameObject;
            playerHealth = player.GetComponent<Health>();
            playerHealth.HealPlayer(increase);
            Debug.Log(playerHealth.curHealth);

            //changes sprite
            rend = player.GetComponent<SpriteRenderer>();
            rend.sprite = maskSprite;

            Destroy(gameObject);
        }
    } */
    public void getHealthPower()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.HealPlayer(10);

        //rend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        //rend.sprite = maskSprite;
    }
}
