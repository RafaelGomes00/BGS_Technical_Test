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

        bodySR.sprite = bodyAnimationHolder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
        torsoSR.sprite = clothingAnimationHolder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
        hairSR.sprite = hairAnimationHolder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
        hatSR.sprite = hatAnimationHolder.GetAnimation(moveValue).frames[frame].GetFrameFromDirection(moveDirection);
    }

    public void SetMoveValue(float value)
    {
        moveValue = Mathf.Clamp(value, 0, 1);
    }

    public void SetDirection(Direction dir)
    {
        moveDirection = dir;
    }
}
