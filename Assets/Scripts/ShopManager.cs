using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopManager : MonoBehaviour
{
    public InventoryManager shopInventory;
    public GameObject shopPanel;
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ProcessPurchase(int index)
    {
        TransactionManager.PurchaseTransaction(
            PlayerManager.instance.inventory,
            shopInventory,
            shopInventory.inventory[index]);
    }
    public void ProcessPurchase(ScriptableItem item)
    {
        TransactionManager.PurchaseTransaction(
            PlayerManager.instance.inventory,
            shopInventory,
            item);
    }
    public void ProcessSell(int index)
    {
        TransactionManager.SellTransaction(
            shopInventory,
            PlayerManager.instance.inventory,
            PlayerManager.instance.inventory.inventory[index]);
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
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        isOpened = false;
        shopPanel.SetActive(false);
    }

    public void TriggerShop()
    {
        if (isOpened) CloseShop();
        else OpenShop();
    }
}
