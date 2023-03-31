using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ScriptableItem> inventory; // List of items in the inventory
    public float coinAmount; // Amount of currency

    public void BuyItem(ScriptableItem item)
    {
        // Deduct the item price from the player's coins
        coinAmount -= item.price;

        // Add the item to the inventory
        inventory.Add(item);
    }

    public void SellItem(ScriptableItem item)
    {
        // Add the item price to the player's coins
        coinAmount += item.price;

        // Remove the item from the inventory
        inventory.Remove(item);
    }
}