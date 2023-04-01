using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Events;

public class TransactionManager : MonoBehaviour
{
    public static TransactionManager instance;
    private void Awake()
    {
        instance = this;
    }

    public UnityEvent onTransaction;

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

            instance.onTransaction.Invoke();
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

            instance.onTransaction.Invoke();
        }
    }
}
