using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager shopInventory;
    public GameObject shopPanel;
    public Animator keeperAnim;
    public Animator uiAnim;
    private float animFactor;
    private void Start()
    {
        keeperAnim = GetComponentInChildren<Animator>();
    }

    public void ProcessPurchase(int index)
    {
        animFactor = 1;
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
        animFactor = 1;
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

    public bool isOpened = false;

    public void OpenShop()
    {
        uiAnim.SetBool("opened", true);
        animFactor = 1;
        isOpened = true;
    }

    public void CloseShop()
    {
        uiAnim.SetBool("opened", false);
        isOpened = false;
    }

    public void TriggerShop()
    {
        if (isOpened) CloseShop();
        else OpenShop();
    }

    private void FixedUpdate()
    {
        animFactor *= .9f;
        keeperAnim.SetFloat("MovementBlend",animFactor);
    }
}
