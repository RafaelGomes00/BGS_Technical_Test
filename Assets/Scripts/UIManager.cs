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
    [SerializeField] GameObject shopPanel;
    [SerializeField] ItemSelection itemSelection;
    [SerializeField] ItemDisplay itemDisplayGO;
    [SerializeField] TextMeshProUGUI coinsText;

    [Header("Buy panel")]
    [SerializeField] GameObject buyPanel;
    [SerializeField] Transform availableItemsParent;
    [SerializeField] List<Customization_ItemHolder> purchasableItems;

    [Header("Sell panel")]
    [SerializeField] GameObject sellPanel;
    [SerializeField] Transform itemDisplayParent;

    [Header("Inventory")]
    [SerializeField] InventoryUI inventoryUI;

    private List<GameObject> instantiatedItems = new List<GameObject>();

#region Buy
    public void ShowBuyPanel()
    {
        darkBackground.SetActive(true);
        sellPanel.SetActive(false);
        shopPanel.SetActive(true);
        buyPanel.SetActive(true);

        UpdateBuyShop();
    }

    public void UpdateBuyShop()
    {
        UpdateCoins();
        ClearElements();
        itemSelection.gameObject.SetActive(false);

        foreach (Customization_ItemHolder customizationItem in purchasableItems)
        {
            if (!Character_Inventory.customizationItems.Contains(customizationItem))
            {
                ItemDisplay newItem = Instantiate(itemDisplayGO, availableItemsParent);
                newItem.Initialize(customizationItem, OnBuyingItem);
                instantiatedItems.Add(newItem.gameObject);
            }
        }
    }

    public void OnBuyingItem(Item item)
    {
        itemSelection.Select(item);
        itemSelection.BuyItem();
        itemSelection.gameObject.SetActive(true);
    }

#endregion

#region Sell
    public void ShowSellPanel()
    {
        darkBackground.SetActive(true);
        shopPanel.SetActive(true);
        sellPanel.SetActive(true);
        buyPanel.SetActive(false);

        UpdateSellShop();
    }

    public void OnSellingItem(Item item)
    {
        itemSelection.Select(item);
        itemSelection.SellItem();
        itemSelection.gameObject.SetActive(true);
    }

    public void UpdateSellShop()
    {
        UpdateCoins();
        ClearElements();
        itemSelection.gameObject.SetActive(false);

        foreach (Item item in Character_Inventory.items)
        {
            ItemDisplay newItem = Instantiate(itemDisplayGO, itemDisplayParent);
            newItem.Initialize(item, OnSellingItem);
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

#endregion
    
    private void UpdateCoins()
    {
        coinsText.text = Character_Inventory.moneyQuantity.ToString();
    }

    public void ShowInventory()
    {
        inventoryUI.ShowInventory();
    }
}
