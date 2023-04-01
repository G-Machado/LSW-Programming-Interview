using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public List<Button> tabButtons;
    public List<GameObject> tabPanels; 

    private int currentTabIndex = 0; 

    void Start()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            int index = i;
            tabButtons[i].onClick.AddListener(() => SelectTab(index));
        }

        SelectTab(0);
    }

    public void SelectTab(int index)
    {
        DeselectTab(currentTabIndex);

        currentTabIndex = index;
        tabButtons[currentTabIndex].interactable = false;
        tabPanels[currentTabIndex].SetActive(true);
    }

    private void DeselectTab(int index)
    {
        tabButtons[index].interactable = true;
        tabPanels[index].SetActive(false);
    }
}