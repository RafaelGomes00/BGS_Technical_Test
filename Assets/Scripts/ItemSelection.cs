using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    [SerializeField] ItemDisplay selectionDisplay;
    [SerializeField] TextMeshProUGUI selectionName;
    [SerializeField] TextMeshProUGUI selectionPrice;
    [SerializeField] Button confirmButton;
    [SerializeField] TextMeshProUGUI confirmButtonText;

    private Item selectedItem;

    public void Select(Item item)
    {
        selectionDisplay.Initialize(item);
        selectionName.text = item.GetName();
        selectionPrice.text = item.GetCost().ToString();

        selectedItem = item;
    }

    public void SellItem()
    {
        confirmButtonText.text = "Sell";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            Character_Inventory.Sell(selectedItem);
            UIManager.Instance.UpdateSellShop();
        });
    }

    public void BuyItem()
    {
        confirmButtonText.text = "Buy";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(delegate
        {
            Character_Inventory.Buy(selectedItem);
            UIManager.Instance.UpdateBuyShop();
        }
        );
    }
}
