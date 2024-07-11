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

    private void OnEnable()
    {
        GameEvents.OnEquipItem += OnEquipItem;
        GameEvents.OnUnequipItem += OnUnequipItem;
    }

    public void ShowInventory()
    {
        ClearInventory();

        inventoryBackground.SetActive(true);

        //First show all the equippable items
        foreach (Item item in Character_Inventory.customizationItems)
        {
            ItemDisplay itemDisplay = Instantiate(itemDisplayGO, itemsDisplayParent);
            itemDisplay.Initialize(item, OnClickItem);
            instantiatedItems.Add(itemDisplay);
        }

        //Then show the sellable items
        foreach (Item item in Character_Inventory.sellableItems)
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

            //If the selected item is the equipped one, change the button to allow the player to unequip the item
            if (Character_Inventory.CheckEquippedItem(item as Customization_ItemHolder))
                itemSelection.SetUnequipButton();
            else
                itemSelection.SetEquipButton();
        }
        else
        {
            equipButton.interactable = false;
        }

        itemSelection.Select(item);
    }

    //Called when the inventory is closed
    //Just to be sure that there will be no duplicates when opening the inventory
    private void ClearInventory()
    {
        foreach (ItemDisplay item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }

        instantiatedItems = new List<ItemDisplay>();
    }

    public void Close()
    {
        ClearInventory();
        inventoryBackground.SetActive(false);
    }

    private void OnEquipItem(Customization_ItemHolder item)
    {
        itemSelection.Deselect();
    }

    private void OnUnequipItem(Customization_ItemHolder selectedItem)
    {
        itemSelection.Deselect();
    }
    
    private void OnDisable()
    {
        GameEvents.OnEquipItem -= OnEquipItem;
        GameEvents.OnUnequipItem -= OnUnequipItem;
    }

}
