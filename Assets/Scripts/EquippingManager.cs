using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class EquippingManager : MonoBehaviour
{
    public static EquippingManager instance;
    private void Awake()
    {
        instance = this;
    }

    public Transform skinHolder;
    public GameObject equippedItem;
    public ScriptableItem nakedSkin;
    public string equippedTitle;
    public Animator inventoryUIAnim;

    public UnityEvent onEquip;

    private void Start()
    {
        TransactionManager.instance.onSell.AddListener(CheckSellUnEquip);
    }

    private void CheckSellUnEquip(ScriptableItem item)
    {
        if(item.title == equippedTitle)
        {
            EquipNaked();
        }
    }

    public void EquipItem(int index)
    {
        onEquip.Invoke();

        ScriptableItem item = PlayerManager.instance.inventory.inventory[index];
        if(item.title == equippedTitle)
        {
            EquipNaked();
            return;
        }

        for (int i = 0; i < skinHolder.childCount; i++)
        {
            Destroy(skinHolder.GetChild(i).gameObject);
        }

        equippedTitle = item.title;
        GameObject skinPrefab = Instantiate(item.prefab, skinHolder);
        PlayerManager.instance.anim = skinPrefab.GetComponent<Animator>();
        equippedItem = skinPrefab;

    }

    public void EquipNaked()
    {
        for (int i = 0; i < skinHolder.childCount; i++)
        {
            Destroy(skinHolder.GetChild(i).gameObject);
        }

        equippedTitle = nakedSkin.title;
        GameObject skinPrefab = Instantiate(nakedSkin.prefab, skinHolder);
        PlayerManager.instance.anim = skinPrefab.GetComponent<Animator>();
        equippedItem = skinPrefab;
    }
}
