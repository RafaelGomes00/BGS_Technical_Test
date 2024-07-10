using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BGS_TechnicalTest/Create Animation holder", fileName = "New animation holder")]
public class AnimationHolder : ScriptableObject
{
    [SerializeField] private AnimationSheet walkAnimationSheet;
    [SerializeField] private AnimationSheet IdleAnimationSheet;

    public AnimationSheet GetAnimation(float moveValue)
    {
        if(moveValue > 0) return walkAnimationSheet;
        return IdleAnimationSheet;
    }
}
