using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager shopInventory;
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ProcessPurchase(ScriptableItem item)
    {
        TransactionManager.PurchaseTransaction(
            PlayerManager.instance.inventory,
            shopInventory,
            item);
    }
    public void ProcessSell(ScriptableItem item)
    {
        TransactionManager.SellTransaction(
            shopInventory,
            PlayerManager.instance.inventory,
            item);
    }

    //

    public bool isOpened = false;

    public void OpenShop()
    {
        isOpened = true;
    }

    public void CloseShop()
    {
        isOpened = false;
    }

    public void TriggerShop()
    {
        if (isOpened) CloseShop();
        else OpenShop();
    }
}
