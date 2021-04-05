using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Power Up Inventory")]
public class InventoryScript : ScriptableObject
{
    [SerializeField]
    private List<Item> Inventory;// = new List<Item>();
    
    /*public void AddItem(Item item) 
    {
        Debug.Log(item.purchased);
        if(!item.purchased)
        {
            Inventory.Add(item);
            Debug.Log(Inventory.Count);
        }
    }

    public bool chkItem(Item item) 
    {
        int i = 0;
        bool duplicate = false;

        while(i < Inventory.Count)
        {
            if(Inventory[i] == item)
            {
                Debug.Log("help");
                duplicate = true;
            }
            i++;
        }

        return (!duplicate);
    }*/

    public List<Item> GetInventory()
    {
        return Inventory;
    }
}
