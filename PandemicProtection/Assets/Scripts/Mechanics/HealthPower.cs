using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPower : MonoBehaviour
{
    public int increase = 20;
    public Health playerHealth;
    private SpriteRenderer rend;
    private Sprite regSprite, maskSprite;

    private void Start()
    {
        maskSprite = Resources.Load<Sprite>("Clothes/Hexagon"); // TODO change hexagon to mask sprite
    }

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
    }
    public void getHealthPower()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.HealPlayer(increase);
        rend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        rend.sprite = maskSprite;
    }
}
