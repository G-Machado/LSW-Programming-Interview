using UnityEngine;
using UnityEngine.UI;

public class SwitchTitles : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private bool isTitle1Active = true;

    void Start()
    {
        button1.onClick.AddListener(SwitchTitle);
        button2.onClick.AddListener(SwitchTitle);
        UpdateTitleAndButtons();
    }

    void SwitchTitle()
    {
        isTitle1Active = !isTitle1Active;
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