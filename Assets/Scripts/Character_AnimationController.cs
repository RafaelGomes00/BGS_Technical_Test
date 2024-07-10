using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character_AnimationController : MonoBehaviour
{
    [SerializeField] private Direction debugDir;

    public Direction moveDirection { get; private set; }
    public float moveValue { get; private set; }

    [SerializeField] private AnimationSheet bodyAnimationSheet;
    [SerializeField] private AnimationSheet clothingAnimationSheet;
    [SerializeField] private AnimationSheet hairAnimationSheet;
    [SerializeField] private AnimationSheet hatAnimationSheet;

    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer torsoSR;
    [SerializeField] private SpriteRenderer hairSR;
    [SerializeField] private SpriteRenderer hatSR;

    private void Update()
    {
        int frame = (int)(Time.time * bodyAnimationSheet.frameDelay);
        frame = frame % bodyAnimationSheet.frames.Length;

        bodySR.sprite = bodyAnimationSheet.frames[frame].GetFrameFromDirection(debugDir);
        torsoSR.sprite = clothingAnimationSheet.frames[frame].GetFrameFromDirection(debugDir);
        hairSR.sprite = hairAnimationSheet.frames[frame].GetFrameFromDirection(debugDir);
        hatSR.sprite = hatAnimationSheet.frames[frame].GetFrameFromDirection(debugDir);
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
