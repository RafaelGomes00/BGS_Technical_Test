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
}
