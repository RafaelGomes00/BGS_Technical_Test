using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Character_Inventory
{
    public static float moneyQuantity { get; private set; }
    public static List<Item> items { get; private set; }
    public static List<Item> customizationItems { get; private set; }

    public static void OnEnable()
    {
        items = new List<Item>();
        customizationItems = new List<Item>();
        GameEvents.OnHarvestCrop += OnHarvestCrop;
    }

    private static void OnHarvestCrop(Item crop)
    {
        items.Add(crop);
    }

    public static void OnDisable()
    {
        GameEvents.OnHarvestCrop -= OnHarvestCrop;
    }

    public static void Sell(Item itemToSell)
    {
        if(items.Contains(itemToSell))
        {
            moneyQuantity += itemToSell.GetCost();
            items.Remove(itemToSell);

            Debug.Log($"Item {itemToSell.name} succesfully sold for {itemToSell.GetCost()} coins");
        }
        else
        {
            Debug.LogError("Item does not exist");
        }
    }

    public static bool Buy(Item selectedItem)
    {
        if(moneyQuantity >= selectedItem.GetCost())
        {
            moneyQuantity -= selectedItem.GetCost();
            customizationItems.Add(selectedItem);

            Debug.Log($"Item {selectedItem.name} succesfully bought for {selectedItem.GetCost()} coins");
            return true;
        }
        else
        {
            Debug.LogError("Not enough coins");
            return false;
        }
    }

    public static void Equip(Customization_ItemHolder selectedItem)
    {
        GameEvents.EquipItemMethod(selectedItem);
    }
}
