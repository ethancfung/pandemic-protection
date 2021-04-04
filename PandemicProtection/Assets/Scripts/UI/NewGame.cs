using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public InventoryScript inventory;
    // Start is called before the first frame update
    public void StartNewGame()
    {
        inventory.Inventory.Clear();
        PlayerPrefs.DeleteAll();
    }
}
