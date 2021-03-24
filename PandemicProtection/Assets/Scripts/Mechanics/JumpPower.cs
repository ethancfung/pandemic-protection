using UnityEngine;

public class JumpPower : MonoBehaviour
{
    public float increase = 7f;
    public Player playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            playerScript = player.GetComponent<Player>();
            Debug.Log("HIT!");

            if (playerScript)
            {
                playerScript.JumpForce = increase;
                Destroy(gameObject);

            }
            //Debug.Log(playerScript.MovementSpeed);
        }
    }

    public void getJumpPower()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.JumpForce = increase;
    }
}
