using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingManager : MonoBehaviour
{
    public Transform skinHolder;
    public GameObject equippedItem;
    public ScriptableItem nakedSkin;
    public string equippedTitle;

    public void EquipItem(int index)
    {
        ScriptableItem item = PlayerManager.instance.inventory.inventory[index];
        if(item.title == equippedTitle)
        {
            item = nakedSkin;
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
}
