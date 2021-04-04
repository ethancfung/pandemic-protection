using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
    public float MovementSpeed = 100;
    private Rigidbody2D _rigidbody;
    public SpriteRenderer sprite; 
    //public SelectionMenu menu;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        //menu = GetComponent<SelectionMenu>();
    }
    
    void Update()
    {
        //NPCPos = GameObject.FindGameObjectWithTag("NPC").transform.position;
        var hmovement = Input.GetAxis("Horizontal");
        var vmovement = Input.GetAxis("Vertical");
        if(hmovement > 0.0f)
        {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }

        transform.position += new Vector3(hmovement, vmovement, 0) * Time.deltaTime * MovementSpeed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("HomeDoor"))
        {
            //open popup menu
            SoundManager.PlaySound("exit");
            SelectionMenu.instance.OpenMenu();
        }
    }
}