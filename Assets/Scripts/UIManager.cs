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
    [SerializeField] TextMeshProUGUI coinsText;

    [Header("Shop")]
    [SerializeField] ShopUI shopUI;

    [Header("Inventory")]
    [SerializeField] InventoryUI inventoryUI;


    public void Close()
    {
        darkBackground.SetActive(false);
        inventoryUI.Close();
        shopUI.Close();
    }

    public void ShowInventory()
    {
        darkBackground.SetActive(true);
        inventoryUI.ShowInventory();
    }

    public void ShowSellShop()
    {
        darkBackground.SetActive(true);
        shopUI.ShowSellPanel();
    }

    public void ShowBuyShop()
    {
        darkBackground.SetActive(true);
        shopUI.ShowBuyPanel();
    }

    public void UpdateSellShop()
    {
        UpdateCoins();
        shopUI.UpdateSellShop();
    }

    public void UpdateBuyShop()
    {
        UpdateCoins();
        shopUI.UpdateBuyShop();
    }

    private void UpdateCoins()
    {
        coinsText.text = Character_Inventory.moneyQuantity.ToString();
    }
}
