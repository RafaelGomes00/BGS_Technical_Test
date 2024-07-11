using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    public override void Interact()
    {
        UIManager.Instance.ShowSellShop();
    }
}
