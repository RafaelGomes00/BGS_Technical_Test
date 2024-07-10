using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Button button;

    private float value;
    private Sprite sprite;
    private bool canEquip;

    public void Initialize(Item item, Action<Item> onClickItem = null)
    {
        value = item.value;
        sprite = item.sprite;
        canEquip = item.canEquip;

        itemImage.sprite = sprite;

        if (onClickItem == null) button.enabled = false;
        else button.onClick.AddListener(() => onClickItem?.Invoke(item));
    }
}
