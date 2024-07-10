using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Button button;

    public void Initialize(Item item, Action<Item> onClickItem = null)
    {
        itemImage.sprite = item.GetDisplaySprite();
        button.enabled = onClickItem != null;
        button.onClick.AddListener(() => onClickItem?.Invoke(item));
    }
}
