using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_AnimationController : MonoBehaviour
{
    public Direction moveDirection { get; private set; }
    public float moveValue { get; private set; }

    [Header("Animations Sheet")]
    [SerializeField] private Customization_ItemHolder bodySpriteHolder;
    [SerializeField] private Customization_ItemHolder clothingSpriteHolder;
    [SerializeField] private Customization_ItemHolder hairSpriteHolder;
    [SerializeField] private Customization_ItemHolder hatSpriteHolder;

    [Header("References")]
    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer torsoSR;
    [SerializeField] private SpriteRenderer hairSR;
    [SerializeField] private SpriteRenderer hatSR;

    private bool dragging;

    private void OnEnable()
    {
        GameEvents.OnEquipItem += OnEquipItem;
        GameEvents.OnUnequipItem += OnUnequipItem;
    }

    private void OnUnequipItem(Customization_ItemHolder item)
    {
        switch (item.GetItemType())
        {
            case ItemType.Hair:
                hairSpriteHolder = item.GetDefaultOption();
                break;
            case ItemType.Outfit:
                clothingSpriteHolder = item.GetDefaultOption();
                break;
            case ItemType.Hat:
                hatSpriteHolder = item.GetDefaultOption();
                break;
        }
    }

    private void OnEquipItem(Customization_ItemHolder item)
    {
        switch (item.GetItemType())
        {
            case ItemType.Hair:
                hairSpriteHolder = item;
                break;
            case ItemType.Outfit:
                clothingSpriteHolder = item;
                break;
            case ItemType.Hat:
                hatSpriteHolder = item;
                break;
        }

        //Can be changed on purchasable items holder
        if (item.resolveItemIncompatibility)
        {
            switch (item.GetItemIncompatibility())
            {
                case ItemType.Hair:
                    hairSpriteHolder = null;
                    break;
                case ItemType.Outfit:
                    clothingSpriteHolder = null;
                    break;
                case ItemType.Hat:
                    hatSpriteHolder = null;
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        //Get wich frame index should be placed on the Sprite Renderer component
        int frame = (int)(Time.time * bodySpriteHolder.GetAnimation(moveValue, dragging).frameDelay);
        //Get the frame of the current animation sheet using the index above
        frame = frame % bodySpriteHolder.GetAnimation(moveValue, dragging).frames.Length;

        //Set sprites
        SetAnimationSprite(bodySR, bodySpriteHolder, frame, moveValue, moveDirection, dragging);
        SetAnimationSprite(torsoSR, clothingSpriteHolder, frame, moveValue, moveDirection, dragging);
        SetAnimationSprite(hairSR, hairSpriteHolder, frame, moveValue, moveDirection, dragging);
        SetAnimationSprite(hatSR, hatSpriteHolder, frame, moveValue, moveDirection, dragging);
    }

    public void SetMoveValue(float value)
    {
        moveValue = Mathf.Clamp(value, 0, 1);
    }

    public void SetDirection(Direction dir)
    {
        moveDirection = dir;
    }

    private void SetAnimationSprite(SpriteRenderer renderer, Customization_ItemHolder holder, int frame, float moveValue, Direction moveDirection, bool dragging)
    {
        if (holder != null)
        {
            renderer.gameObject.SetActive(true);
            renderer.sprite = holder.GetAnimation(moveValue, dragging).frames[frame].GetFrameFromDirection(moveDirection);
        }
        else
            renderer.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Draggable"))
            dragging = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        dragging = false;
    }

    private void OnDisable()
    {
        GameEvents.OnEquipItem -= OnEquipItem;
        GameEvents.OnUnequipItem -= OnUnequipItem;
    }
}
