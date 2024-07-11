using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crop : Interactable
{
    [SerializeField] Item item;
    [SerializeField] SpriteRenderer image;
    [SerializeField] Sprite doneSprite;
    [SerializeField] Sprite seedsSprite;
    [SerializeField] private float harvestCooldown;

    private float cooldown; 

    public override bool IsInteractable()
    {
        if (cooldown <= 0) return true;
        return false;
    }

    public override void Interact()
    {
        if (cooldown <= 0)
        {
            GameEvents.HarvestCropMethod(item);
            image.sprite = seedsSprite;
            cooldown = harvestCooldown;
        }
    }

    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (image.sprite != doneSprite)
            image.sprite = doneSprite;
    }
}
