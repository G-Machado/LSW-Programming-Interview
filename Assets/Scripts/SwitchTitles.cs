using UnityEngine;
using UnityEngine.UI;

public class SwitchTitles : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private bool isButton1Active = true;

    void Start()
    {
        button1.onClick.AddListener(SwitchButton2);
        button2.onClick.AddListener(SwtichButton1);
        UpdateButtons();

        EquippingManager.instance.onEquip.AddListener(DefaultTitle);
    }

    void SwtichButton1()
    {
        isButton1Active = true;
        UpdateButtons();
    }
    void SwitchButton2()
    {
        isButton1Active = false;
        UpdateButtons();
    }

    void DefaultTitle()
    {
        isButton1Active = true;
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (isButton1Active)
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(false);
        }
        else
        {
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(true);
        }
    }
}