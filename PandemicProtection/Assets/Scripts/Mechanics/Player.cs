using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;

    //NPC Global variables
    public Vector3 NPCPos;
    private float range = 4;
    public static bool withinRange = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        NPCPos = GameObject.Find("NPC").transform.position;
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        float npcDistance = NPCPos.x - transform.position.x;

        if(npcDistance > -range && npcDistance < range )
        {
             withinRange = true;
        }
        else
        {
            withinRange = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Points"))
        {
            PointManager.instance.UpdatePoints(1);
            Destroy(other.gameObject);
        }
    }
}
