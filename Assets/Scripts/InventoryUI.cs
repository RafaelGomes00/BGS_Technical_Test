using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryBackground;
    [SerializeField] ItemSelection itemSelection;
    [SerializeField] Transform itemsDisplayParent;
    [SerializeField] ItemDisplay itemDisplayGO;
    [SerializeField] Button equipButton;

    private List<ItemDisplay> instantiatedItems = new List<ItemDisplay>();

    public void ShowInventory()
    {
        ClearInventory();

        inventoryBackground.SetActive(true);

        foreach (Item item in Character_Inventory.customizationItems)
        {
            ItemDisplay itemDisplay = Instantiate(itemDisplayGO, itemsDisplayParent);
            itemDisplay.Initialize(item, OnClickItem);
            instantiatedItems.Add(itemDisplay);
        }

        foreach (Item item in Character_Inventory.items)
        {
            ItemDisplay itemDisplay = Instantiate(itemDisplayGO, itemsDisplayParent);
            itemDisplay.Initialize(item, OnClickItem);
            instantiatedItems.Add(itemDisplay);
        }
    }

    private void OnClickItem(Item item)
    {
        if (item.CanEquip())
        {
            equipButton.interactable = true;
        }
    
        itemSelection.Select(item);
        itemSelection.EquipItem();
    }

    private void ClearInventory()
    {
        foreach (ItemDisplay item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }

        instantiatedItems = new List<ItemDisplay>();
    }
}
