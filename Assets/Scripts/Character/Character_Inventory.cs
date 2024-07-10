using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Inventory : MonoBehaviour
{
    public int moneyQuantity { get; private set; }
    public List<Item> items { get; private set; }

    static Character_Inventory instance;
    public static Character_Inventory Instance => instance ?? FindObjectOfType<Character_Inventory>();

    private void OnEnable()
    {
        items = new List<Item>();
        GameEvents.OnHarvestCrop += OnHarvestCrop;
    }

    private void OnHarvestCrop(Crop crop)
    {
        items.Add(new Item(crop.GetValue(), false, crop.GetSprite()));
        Debug.Log(items.Count);
    }

    private void OnDisable()
    {
        GameEvents.OnHarvestCrop -= OnHarvestCrop;
    }
}
