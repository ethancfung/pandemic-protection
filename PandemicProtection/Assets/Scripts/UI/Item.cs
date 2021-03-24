using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    public int price = 0;
    public string description;
    public string itemName;
    public bool purchased = false;
}
