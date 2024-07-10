using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] Image itemImage;

    private float value;
    private Sprite sprite;
    private bool canEquip;

    public void Initialize(Item item)
    {
        value = item.value;
        sprite = item.sprite;
        canEquip = item.canEquip;

        itemImage.sprite = sprite;
    }
}
