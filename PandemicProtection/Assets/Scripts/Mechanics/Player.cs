using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer sprite; 

    public SpeedPower speedPower; //NULL REFERENCES
    public JumpPower jumpPower;
    public HealthPower healthPower;
    //public InventoryScript inventory;
    public Image jump;
    public Image speed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        speed.enabled = false;
        jump.enabled = false;

        List<Item> PurchasedItems = PlayerInventory.instance.GetInventory();

        if(PurchasedItems.Count != 0)
        {
            for(int i = 0; i < PurchasedItems.Count; i++)
            {
                if(PurchasedItems[i].itemName == "Coffee")
                {
                    //speed up power up applied
                    speed.enabled = true;
                    speedPower.getSpeedPower();
                }   
                if(PurchasedItems[i].itemName == "Mask")
                {
                    //mask power up applied
                    PutOnMask();
                    healthPower.getHealthPower();
                }
                if(PurchasedItems[i].itemName == "Sneakers")
                {
                    //jump power up applied
                    jump.enabled = true;
                    jumpPower.getJumpPower();
                }
            }
        }
    }
    
    void Update()
    {
        //Debug.Log(MovementSpeed);
        //Debug.Log(JumpForce);
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
            SoundManager.PlaySound("jump");
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

    }

    private void PutOnMask()
    {
        Sprite maskSprite = Resources.Load<Sprite>("Clothes/Sprite Power Ups"); 
        sprite.sprite = maskSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collision");
        if (other.gameObject.CompareTag("Points")) // protection points
        {
            SoundManager.PlaySound("coin");
            PointManager.instance.UpdatePoints(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("DeathZone")) // player falls into death zones
        {
            //Debug.Log("Death");
            LevelLoader.instance.LoadNextLevel("GameOver");
        }
        else if (other.gameObject.CompareTag("NPC")) 
        {
            SoundManager.PlaySound("hit");
            //Debug.Log("NPC");
        }
        else if (other.gameObject.CompareTag("VictoryZone"))
        {
            Debug.Log("Victory");
            Scene scene = SceneManager.GetActiveScene();
            string level = "";
            if (scene.name == "Level1")
            {
                level = "Groceries";
            }else if (scene.name == "Level2")
            {
                level = "Bank Appointment";
            }else
            {
                level = "Annual Checkup";
            }

            Health health = gameObject.GetComponent<Health>();

            PlayerPrefs.SetInt("Points", PointManager.instance.GetPoints());
            PlayerPrefs.SetString("Level", level);
            PlayerPrefs.SetFloat("Time", PlayTime.time);
            PlayerPrefs.SetInt("Score", SafetyScore.instance.GetScore());
            PlayerPrefs.SetInt("Health", health.curHealth);
            
            LevelLoader.instance.LoadNextLevel("Victory");
        }
    }
}
