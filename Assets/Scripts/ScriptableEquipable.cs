using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Equipable")]
public class ScriptableEquipable : ScriptableObject
{
    public ScriptableItem itemData;
    public GameObject skinPrefab;
    public int minLevel = 0;

    public void Equip(PlayerManager player)
    {
        //Destroy(player.equippedItem);
    }
}
