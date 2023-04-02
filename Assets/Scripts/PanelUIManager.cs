using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelUIManager : MonoBehaviour
{
    public InventoryManager shopInventory;
    public Transform itemContainer; 
    public GameObject itemPrefab;
    public UnityEvent<int> action;

    private void Awake()
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
            Button[] actionButtons = itemUI.transform.GetComponentsInChildren<Button>();
            for (int j = 0; j < actionButtons.Length; j++)
            {
                if (j < 1) actionButtons[j].gameObject.SetActive(true);
                else actionButtons[j].gameObject.SetActive(false);

                actionButtons[j].onClick.AddListener(
                delegate { action.Invoke(index); });
            }
        }

        itemContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0,shopInventory.inventory.Count * 127);
    }
}