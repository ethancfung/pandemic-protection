﻿using UnityEngine;

public class JumpPower : MonoBehaviour
{
    public float increase = 7f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<Player>();
            Debug.Log("HIT!");

            if (playerScript)
            {
                playerScript.JumpForce = increase;
                Destroy(gameObject);

            }
            //Debug.Log(playerScript.JumpForce);
        }
    }
}
