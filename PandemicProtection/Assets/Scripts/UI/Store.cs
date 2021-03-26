using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public TextMeshProUGUI points;

    public int playerPoints = 10;
    public Button [] btns;
    public InventoryScript inventory;

    // Start is called before the first frame update
    void Start()
    {
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
            if(inventory.AddItem(item.powerup))
            {
                inventory.AddItem(item.powerup);
                playerPoints = playerPoints - item.powerup.price;
                item.powerup.purchased = true;
            }
        }
        else 
        {
            Debug.Log("Not enough funds");
        }
    }

    // Update is called once per frame
    void Update()
    {
        points.text = playerPoints.ToString();
    }

    private void OnApplicationQuit() 
    {
        inventory.Inventory.Clear();
    }
}
