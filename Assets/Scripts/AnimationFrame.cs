using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AnimationFrame
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;

    public Sprite GetFrameFromDirection(Direction dir)
    {
        switch(dir)
        {
            case Direction.Up:
                return upSprite;
            case Direction.Down:
                return downSprite;
            case Direction.Right:
                return rightSprite;
            case Direction.Left:
                return leftSprite;
            default:
                Debug.LogError("Invalid direction given, returning null");
                return null;
        }
    }
}