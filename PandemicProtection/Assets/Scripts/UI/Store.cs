using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public TextMeshProUGUI points;

    private int playerPoints;
    public Button [] btns;
    public InventoryScript inventory;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Total Points"))
        {
            playerPoints = PlayerPrefs.GetInt("Total Points");
        }else 
        {
            PlayerPrefs.SetInt("Total Points", 0);
            playerPoints = 0;
        }
        points = GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < btns.Length; i++)
        {
            int closureIndex = i ; // Prevents the closure problem
            btns[closureIndex].onClick.AddListener( () => TaskOnClick( closureIndex ) );
        }
    }

    void TaskOnClick(int buttonIndex) {
        var item = btns[buttonIndex].GetComponent<PowerUp>();

        Debug.Log(item.powerup.price);

        if((playerPoints - item.powerup.price) >= 0)
        {
            SoundManager.PlaySound("buy");
            if (inventory.chkItem(item.powerup))
            {
                Debug.Log("yes, hello");
                inventory.AddItem(item.powerup);
                playerPoints = playerPoints - item.powerup.price;
                item.powerup.purchased = true;
            }
            else {
                Debug.Log("Power up purchased");
            }
        }
        else 
        {
            SoundManager.PlaySound("hit");
            Debug.Log("Not enough funds");
        }
    }

    // Update is called once per frame
    void Update()
    {
        points.text = playerPoints.ToString();
        PlayerPrefs.SetInt("Total Points", playerPoints);
    }

    private void OnApplicationQuit() 
    {
        inventory.Inventory.Clear();
    }

}
