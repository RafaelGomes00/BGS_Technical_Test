using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public delegate void HarvestCrop(Item crop);
    public static event HarvestCrop OnHarvestCrop;
    public static void HarvestCropMethod(Item crop)
    {
        OnHarvestCrop?.Invoke(crop);
    }

    public delegate void EquipItem(Customization_ItemHolder item);
    public static event EquipItem OnEquipItem;
    public static void EquipItemMethod(Customization_ItemHolder item)
    {
        OnEquipItem?.Invoke(item);
    }

    public delegate void UnequipItem(Customization_ItemHolder selectedItem);
    public static event UnequipItem OnUnequipItem;
    public static void UnequipItemMethod(Customization_ItemHolder selectedItem)
    {
        OnUnequipItem?.Invoke(selectedItem);
    }

    public delegate void OpenMenu();
    public static event OpenMenu OnOpenMenu;
    public static void OpenMenuMethod()
    {
        OnOpenMenu?.Invoke();
    }

    public delegate void CloseMenu();
    public static event CloseMenu OnCloseMenu;
    public static void CloseMenuMethod()
    {
        OnCloseMenu?.Invoke();
    }
}
