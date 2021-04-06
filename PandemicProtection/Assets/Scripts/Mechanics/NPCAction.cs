using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    public float min ;
    public float max;
    private SpriteRenderer sprite; 
    private float speed;
    private float prevX;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 3f);
        min = transform.position.x;
        max = transform.position.x+3;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        prevX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.PingPong(Time.time*speed,max-min);
        transform.position = new Vector3(newX+min, transform.position.y, transform.position.z);
        if (newX < prevX)
        {
            sprite.flipX = true;
        }else
        {
            sprite.flipX = false;
        }
        prevX = newX;

    }
}
