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
    [SerializeField] Button sellButton;

    private Item selectedItem;

    public void Select(Item item)
    {
        selectionDisplay.Initialize(item);
        selectionName.text = item.name;
        selectionPrice.text = item.value.ToString();

        selectedItem = item;
    }

    public void Sell()
    {
        Character_Inventory.Sell(selectedItem);
        UIManager.Instance.UpdateShop();
    }
}
