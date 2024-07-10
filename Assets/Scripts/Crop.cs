using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : Interactable
{
    [SerializeField] private string cropName;
    [SerializeField] private float value;
    [SerializeField] private float harvestCooldown;
    [SerializeField] private Sprite sprite;

    private float cooldown; 

    public override void Interact()
    {
        if (cooldown <= 0)
        {
            GameEvents.HarvestCropMethod(this);
            cooldown = harvestCooldown;
        }
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

    public string GetName()
    {
        return cropName;
    }
}
