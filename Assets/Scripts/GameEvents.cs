using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public delegate void HarvestCrop(Crop crop);
    public static event HarvestCrop OnHarvestCrop;
    public static void HarvestCropMethod(Crop crop)
    {
        OnHarvestCrop?.Invoke(crop);
    }
}
