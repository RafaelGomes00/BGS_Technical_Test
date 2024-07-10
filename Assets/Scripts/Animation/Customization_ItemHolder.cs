using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BGS_TechnicalTest/Create customization holder", fileName = "New customization holder")]
public class Customization_ItemHolder : Item
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private AnimationSheet walkAnimationSheet;
    [SerializeField] private AnimationSheet IdleAnimationSheet;

    public AnimationSheet GetAnimation(float moveValue)
    {
        if(moveValue > 0) return walkAnimationSheet;
        return IdleAnimationSheet;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}
