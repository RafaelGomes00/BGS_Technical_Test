using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character_AnimationController : MonoBehaviour
{
    public Direction moveDirection { get; private set; }
    public float moveValue { get; private set; }

    [Header("Animation Sheet")]
    [SerializeField] private Customization_ItemHolder bodyAnimationHolder;
    [SerializeField] private Customization_ItemHolder clothingAnimationHolder;
    [SerializeField] private Customization_ItemHolder hairAnimationHolder;
    [SerializeField] private Customization_ItemHolder hatAnimationHolder;

    [Header("References")]
    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer torsoSR;
    [SerializeField] private SpriteRenderer hairSR;
    [SerializeField] private SpriteRenderer hatSR;

    private void OnEnable()
    {
        GameEvents.OnEquipItem += OnEquipItem;
    }

    private void OnEquipItem(Customization_ItemHolder item)
    {
        switch (item.GetItemType())
        {
            case ItemType.Hair:
                hairAnimationHolder = item;
                break;
            case ItemType.Outfit:
                clothingAnimationHolder = item;
                break;
            case ItemType.Hat:
                hatAnimationHolder = item;
                break;
        }
    }

    private void Update()
    {
        int frame = (int)(Time.time * bodyAnimationHolder.GetAnimation(moveValue).frameDelay);
        frame = frame % bodyAnimationHolder.GetAnimation(moveValue).frames.Length;

        SetAnimationSprite(bodySR, bodyAnimationHolder, frame, moveValue, moveDirection);
        SetAnimationSprite(torsoSR, clothingAnimationHolder, frame, moveValue, moveDirection);
        SetAnimationSprite(hairSR, hairAnimationHolder, frame, moveValue, moveDirection);
        SetAnimationSprite(hatSR, hatAnimationHolder, frame, moveValue, moveDirection);
    }

    public void SetMoveValue(float value)
    {
        moveValue = Mathf.Clamp(value, 0, 1);
    }

    public void SetDirection(Direction dir)
    {
        moveDirection = dir;
    }

    private void SetAnimationSprite(SpriteRenderer renderer, Customization_ItemHolder holder, int frame, float moveValue, Direction moveDirection)
    {
        if (holder != null)
        {
            renderer.gameObject.SetActive(true);
            renderer.sprite = holder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
        }
        else
            renderer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.OnEquipItem -= OnEquipItem;
    }
}
