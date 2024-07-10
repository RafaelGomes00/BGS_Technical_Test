using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance ?? FindObjectOfType<UIManager>();

    [SerializeField] GameObject darkBackground;
    [SerializeField] GameObject sellPanel;
    [SerializeField] GameObject close;
    [SerializeField] Transform itemDisplayParent;

    [SerializeField] ItemDisplay itemDisplayGO;

    public void ShowSellPanel(List<Item> items)
    {
        darkBackground.SetActive(true);
        sellPanel.SetActive(true);

        foreach (Item item in items)
        {
            Instantiate(itemDisplayGO, itemDisplayParent).Initialize(item);
        }
    }
}
