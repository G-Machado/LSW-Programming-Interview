using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<ScriptableItem> inventory;
    public float coinAmount; 
    public Text amountText;

    private void Start()
    {
        if (amountText)
            amountText.text = $"${coinAmount}";
    }

    public void BuyItem(ScriptableItem item)
    {
        coinAmount -= item.price;
        if (amountText)
            amountText.text = $"${coinAmount}";

        inventory.Add(item);
    }

    public void SellItem(ScriptableItem item)
    {
        coinAmount += item.price;
        if(amountText)
            amountText.text = $"${coinAmount}";

        inventory.Remove(item);
    }
}