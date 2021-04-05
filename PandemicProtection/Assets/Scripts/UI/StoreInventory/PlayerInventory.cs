using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public InventoryScript inventoryScript;
    private List<Item> PurchasedItems;
    public static PlayerInventory instance;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start() 
    {
        if (instance == null)
        {
            instance = this;
        }
        PurchasedItems = inventoryScript.GetInventory();
        Debug.Log(PurchasedItems.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item) 
    {
        Debug.Log(item.purchased);
        if(!item.purchased)
        {
            PurchasedItems.Add(item);
            Debug.Log(PurchasedItems.Count);
        }
    }

    public bool chkItem(Item item) 
    {
        int i = 0;
        bool duplicate = false;

        while(i < PurchasedItems.Count)
        {
            if(PurchasedItems[i] == item)
            {
                Debug.Log("help");
                duplicate = true;
            }
            i++;
        }

        return (!duplicate);
    }

    public List<Item> GetInventory()
    {
        return inventoryScript.GetInventory();
    }
    
}
