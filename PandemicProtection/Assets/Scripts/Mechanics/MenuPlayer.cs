using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPlayer : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer sprite; 
    public TextMeshProUGUI nameInput;
    public Image warningBg;
    public TextMeshProUGUI warning;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (SelectionMenu.SelectionIsOpen)
        {
            SelectionMenu.instance.CloseMenu();
        }
        warningBg.enabled = false;
        warning.enabled = false;
    }
    
    void Update()
    {
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

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
        PlayerInventory.instance.GetInventory().Clear();
    }

    public void StartNewGame()
    {
        Debug.Log("Starting new game with " + nameInput.text);
        ClearData();
        PlayerPrefs.SetString("Name", nameInput.text);
        SelectionMenu.instance.CloseMenu();
        LevelLoader.instance.LoadNextLevel("Home");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SoundManager.PlaySound("hit");
        if (other.gameObject.name == "Load") // load game
        {
            if (!PlayerPrefs.HasKey("Name"))
            {
                // no loaded game
                //Debug.Log("No saved game!");
                warningBg.enabled = true;
                warning.enabled = true;

            }else 
            {
                //Debug.Log("Loading " + PlayerPrefs.GetString("Name") + " \'s game!");
                LevelLoader.instance.LoadNextLevel("Home");
            }
        }
        else if (other.gameObject.name == "New") 
        {
            SelectionMenu.instance.OpenMenu();
        }
        else if (other.gameObject.CompareTag("DeathZone")) // player falls into death zones -- easter egg
        {
            LevelLoader.instance.LoadNextLevel("Credits");
        }
    }
}
