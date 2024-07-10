using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance ?? FindObjectOfType<UIManager>();

    [SerializeField] GameObject darkBackground;

    [Header("Sell panel")]
    [SerializeField] GameObject sellPanel;
    [SerializeField] Transform itemDisplayParent;
    [SerializeField] ItemSelection itemSelection;
    [SerializeField] ItemDisplay itemDisplayGO;
    private List<GameObject> instantiatedItems = new List<GameObject>();

    public void ShowSellPanel()
    {
        darkBackground.SetActive(true);
        sellPanel.SetActive(true);

        UpdateShop();
    }

    public void OnClickItem(Item item)
    {
        itemSelection.Select(item);
        itemSelection.gameObject.SetActive(true);
    }

    public void UpdateShop()
    {
        ClearElements();
        itemSelection.gameObject.SetActive(false);


        foreach (Item item in Character_Inventory.items)
        {
            ItemDisplay newItem = Instantiate(itemDisplayGO, itemDisplayParent);
            newItem.Initialize(item, OnClickItem);
            instantiatedItems.Add(newItem.gameObject);
        }
    }

    private void ClearElements()
    {
        foreach (GameObject obj in instantiatedItems)
        {
            Destroy(obj);
        }
        instantiatedItems = new List<GameObject>();
    }

}
