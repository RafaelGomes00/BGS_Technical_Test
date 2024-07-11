using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BGS_TechnicalTest/Create customization holder", fileName = "New customization holder")]
public class Customization_ItemHolder : Item
{
    [Header("Animation sheets")]
    [SerializeField] private Customization_ItemHolder defaultOption;
    [SerializeField] private AnimationSheet walkAnimationSheet;
    [SerializeField] private AnimationSheet idleAnimationSheet;
    [SerializeField] private AnimationSheet dragAnimationSheet;

    [Header("Item types")]
    [SerializeField] private ItemType itemType;

    //On the used sprites, the hairs and the hats will clip out of each other
    //This field makes sure that there will be only one item, for preventing clipping
    [SerializeField] private ItemType incompatibleItemType;

    public bool resolveItemIncompatibility;

    public AnimationSheet GetAnimation(float moveValue, bool dragging)
    {
        if (dragging) return dragAnimationSheet;
        if (moveValue > 0) return walkAnimationSheet;
        return idleAnimationSheet;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
    
    public ItemType GetItemIncompatibility()
    {
        return incompatibleItemType;
    }

    public Customization_ItemHolder GetDefaultOption()
    {
        return defaultOption;
    }
}
