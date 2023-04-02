using UnityEngine;
using UnityEngine.UI;

public class SwitchTitles : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private bool isTitle1Active = true;

    void Start()
    {
        button1.onClick.AddListener(SwitchTitle2);
        button2.onClick.AddListener(SwitchTitle1);
        UpdateTitleAndButtons();

        EquippingManager.instance.onEquip.AddListener(DefaultTitle);
    }

    void SwitchTitle1()
    {
        isTitle1Active = true;
        UpdateTitleAndButtons();
    }
    void SwitchTitle2()
    {
        isTitle1Active = false;
        UpdateTitleAndButtons();
    }

    void DefaultTitle()
    {
        isTitle1Active = true;
        UpdateTitleAndButtons();
    }

    void UpdateTitleAndButtons()
    {
        if (isTitle1Active)
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