using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    [SerializeField] GameObject errorText;
    [SerializeField] Button confirmButton;
    [SerializeField] ItemDisplay selectionDisplay;
    [SerializeField] TextMeshProUGUI selectionName;
    [SerializeField] TextMeshProUGUI selectionPrice;
    [SerializeField] TextMeshProUGUI confirmButtonText;

    private Item selectedItem;

    public void Select(Item item)
    {
        gameObject.SetActive(true);
        errorText?.SetActive(false);
        selectionDisplay.Initialize(item);
        selectionName.text = item.GetName();
        selectionPrice.text = item.GetCost().ToString();

        selectedItem = item;
    }

    public void SetEquipButton()
    {
        confirmButtonText.text = "Equip";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            if (selectedItem.GetType() == typeof(Customization_ItemHolder))
                Character_Inventory.Equip((Customization_ItemHolder)selectedItem);
        });
    }

    public void SetUnequipButton()
    {
        confirmButtonText.text = "Unequip";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            if (selectedItem.GetType() == typeof(Customization_ItemHolder))
                Character_Inventory.Unequip((Customization_ItemHolder)selectedItem);
        });
    }

    public void SetSellButton()
    {
        confirmButtonText.text = "Sell";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            Character_Inventory.Sell(selectedItem);
            UIManager.Instance.UpdateSellShop();
        });
    }

    public void SetBuyButton()
    {
        confirmButtonText.text = "Buy";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            if (!Character_Inventory.Buy(selectedItem)) errorText.SetActive(true);
            else
            {
                errorText.SetActive(false);
                UIManager.Instance.UpdateBuyShop();
            }
        }
        );
    }

    public void Deselect()
    {
        selectedItem = null;
        gameObject.SetActive(false);
    }
}
