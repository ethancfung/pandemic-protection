using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Power Up Inventory")]
public class InventoryScript : ScriptableObject
{
    public List<Item> Inventory = new List<Item>();
    
    public bool AddItem(Item item) 
    {
        int i = 0;
        bool duplicate = false;

        
        while(i < Inventory.Count)
        {
            if(Inventory[i] == item)
            {
                duplicate = true;
            }
            i++;
        }
        Debug.Log(item.purchased);
        if(item.purchased && !duplicate)
        {
            Inventory.Add(item);
            return true;
        }
        return false;
    }
}
