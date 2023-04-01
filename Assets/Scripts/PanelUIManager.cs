using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class PanelUIManager : MonoBehaviour
{
    public InventoryManager shopInventory;
    public Transform itemContainer; 
    public GameObject itemPrefab;
    public UnityEvent<int> action;

    void Start()
    {
        TransactionManager.instance.onTransaction.AddListener(UpdateUI);
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < shopInventory.inventory.Count; i++)
        {
            GameObject itemUI = Instantiate(itemPrefab, itemContainer);
            ScriptableItem item = shopInventory.inventory[i];

            itemUI.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            itemUI.transform.Find("Title").GetComponent<Text>().text = item.title;
            itemUI.transform.Find("Price").GetComponent<Text>().text = $"${item.price}";

            int index = i;
            itemUI.transform.Find("ActionButton").GetComponent<Button>().onClick.AddListener(
                delegate { action.Invoke(index); });
        }

        itemContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0,shopInventory.inventory.Count * 117);

        Debug.Log("updated ui");
    }
}