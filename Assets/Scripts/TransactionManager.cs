using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public static class TransactionManager
{
    public static void PurchaseTransaction(
        InventoryManager buyer,
        InventoryManager seller,
        ScriptableItem Item
        )
    {
       if(buyer.coinAmount > Item.price &&
            seller.inventory.Contains(Item))
        {
            buyer.BuyItem(Item);
            seller.SellItem(Item);
        }
    }

    public static void SellTransaction(
        InventoryManager buyer,
        InventoryManager seller,
        ScriptableItem Item
        )
    {
        if(seller.inventory.Contains(Item))
        {
            buyer.BuyItem(Item);
            seller.SellItem(Item);
        }
    }
}
