using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Character_Inventory
{
    public static float moneyQuantity { get; private set; }
    public static List<Item> items { get; private set; }

    public static void OnEnable()
    {
        items = new List<Item>();
        GameEvents.OnHarvestCrop += OnHarvestCrop;
    }

    private static void OnHarvestCrop(Crop crop)
    {
        items.Add(new Item(crop.GetValue(), false, crop.GetSprite(), crop.GetName()));
    }

    public static void OnDisable()
    {
        GameEvents.OnHarvestCrop -= OnHarvestCrop;
    }

    public static void Sell(Item itemToSell)
    {
        if(items.Contains(itemToSell))
        {
            moneyQuantity += itemToSell.value;
            items.Remove(itemToSell);

            Debug.Log($"Item {itemToSell.name} succesfully sold for {itemToSell.value} coins");
        }
        else
        {
            Debug.LogError("Item does not exist");
        }
    }
}
