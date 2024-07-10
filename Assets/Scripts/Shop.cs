using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] private float value;
    [SerializeField] private float harvestCooldown;
    [SerializeField] private Sprite sprite;

    private float cooldown; 

    public override void Interact()
    {
        UIManager.Instance.ShowSellPanel(Character_Inventory.Instance.items);
    }

    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public float GetValue()
    {
        return value;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}
