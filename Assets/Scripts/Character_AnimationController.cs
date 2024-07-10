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
    [SerializeField] private AnimationHolder bodyAnimationHolder;
    [SerializeField] private AnimationHolder clothingAnimationHolder;
    [SerializeField] private AnimationHolder hairAnimationHolder;
    [SerializeField] private AnimationHolder hatAnimationHolder;

    [Header("References")]
    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer torsoSR;
    [SerializeField] private SpriteRenderer hairSR;
    [SerializeField] private SpriteRenderer hatSR;

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

    private void SetAnimationSprite(SpriteRenderer renderer, AnimationHolder holder, int frame, float moveValue, Direction moveDirection)
    {
        if (holder != null)
        {
            renderer.gameObject.SetActive(true);
            renderer.sprite = holder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
        }
        else
            renderer.gameObject.SetActive(false);
    }
}
