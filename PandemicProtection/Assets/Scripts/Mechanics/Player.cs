using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public SpriteRenderer sprite; 

    //NPC Global variables
    public Vector3 NPCPos;
    private float range = 4;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        Debug.Log(MovementSpeed);
        Debug.Log(JumpForce);
        //NPCPos = GameObject.FindGameObjectWithTag("NPC").transform.position;
        var movement = Input.GetAxis("Horizontal");
        if(movement > 0.0f)
        {
            sprite.flipX = true;
        }
        else {
             sprite.flipX = false;
        }
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collision");
        if (other.gameObject.CompareTag("Points")) // protection points
        {
            PointManager.instance.UpdatePoints(1);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("DeathZone")) // player falls into death zones
        {
            Debug.Log("Death");
            // go home
        }
        else if(other.gameObject.CompareTag("NPC")) 
        {
            Debug.Log("NPC");
        }
        else if (other.gameObject.CompareTag("VictoryZone"))
        {
            Debug.Log("Victory");
        }
    }
}
