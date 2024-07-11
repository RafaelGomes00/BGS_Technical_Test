using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BGS_TechnicalTest/Create item", fileName = "New item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float value;
    [SerializeField] private bool canEquip;

    public string GetName()
    {
        return itemName;
    }

    public float GetCost()
    {
        return value;
    }

    public Sprite GetDisplaySprite()
    {
        return sprite;
    }

    public bool CanEquip()
    {
        return canEquip;
    }
}
