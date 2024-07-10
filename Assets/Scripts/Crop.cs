using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : Interactable
{
    [SerializeField] Item item;
    [SerializeField] private float harvestCooldown;

    private float cooldown; 

    public override void Interact()
    {
        if (cooldown <= 0)
        {
            GameEvents.HarvestCropMethod(item);
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
}
