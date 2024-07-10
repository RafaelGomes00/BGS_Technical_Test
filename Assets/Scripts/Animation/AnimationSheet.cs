using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BGS_TechnicalTest/Create Animation Sheet", fileName = "New animation sheet")]
public class AnimationSheet : ScriptableObject
{
    public int frameDelay;
    public AnimationFrame[] frames;
}
